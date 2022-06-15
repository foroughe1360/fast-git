using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using DomainModel.Models;

namespace Bussiness
{
    public class ListLearningAssistToolProvider : IListLearningAssistToolProvider
    {
        private ListLearningAssistToolDAC _ListLearningAssistToolDAC;
        public ListLearningAssistToolProvider()
        {
            _ListLearningAssistToolDAC = new ListLearningAssistToolDAC();
        }
        public int Add(ListLearningAssistToolEntity Current)
        {
            ListLearningAssistTool _ListLearningAssistTool = new ListLearningAssistTool(Current.DesignTrainingCourseId,Current.LearningAssistToolId);
            return _ListLearningAssistToolDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListLearningAssistToolDAC.Delete(ID);
        }

        public bool Edit(ListLearningAssistToolEntity Current)
        {
            ListLearningAssistTool _ListLearningAssistTool = new ListLearningAssistTool();
            _ListLearningAssistTool.ListLearningAssistToolId = Current.ListLearningAssistToolId;
            _ListLearningAssistTool.DesignTrainingCourseId = Current.DesignTrainingCourseId;
            _ListLearningAssistTool.TimeLastModified = DateTime.Now;
            _ListLearningAssistTool.Hidden = false;
            return _ListLearningAssistToolDAC.Edit(_ListLearningAssistTool);
        }

        public ListLearningAssistToolEntity Get(int ID)
        {
            ListLearningAssistToolEntity _ListLearningAssistToolEntity = new ListLearningAssistToolEntity();
            var q = _ListLearningAssistToolDAC.Get(ID);
            if (q != null)
            {
                _ListLearningAssistToolEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListLearningAssistToolEntity.LearningAssistToolId = q.LearningAssistToolId;
                _ListLearningAssistToolEntity.ListLearningAssistToolId = q.ListLearningAssistToolId;
            }
            else
            {
                _ListLearningAssistToolEntity = null;
            }
            return _ListLearningAssistToolEntity;
        }

        public ListLearningAssistToolEntity GetLearningAssistTool(int designtrainingcourseid, int learningassisttoolid)
        {
            ListLearningAssistToolEntity _ListLearningAssistToolEntity = new ListLearningAssistToolEntity();
            var q = _ListLearningAssistToolDAC.GetLearningAssistTool(designtrainingcourseid, learningassisttoolid);
            if (q != null)
            {
                _ListLearningAssistToolEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListLearningAssistToolEntity.LearningAssistToolId = q.LearningAssistToolId;
                _ListLearningAssistToolEntity.ListLearningAssistToolId = q.ListLearningAssistToolId;
            }
            else
            {
                _ListLearningAssistToolEntity = null;
            }
            return _ListLearningAssistToolEntity;
        }

        public ListLearningAssistToolEntity GetDeleteLearningAssistTool(int designtrainingcourseid, int learningassisttoolid)
        {
            ListLearningAssistToolEntity _ListLearningAssistToolEntity = new ListLearningAssistToolEntity();
            var q = _ListLearningAssistToolDAC.GetDeleteLearningAssistTool(designtrainingcourseid, learningassisttoolid);
            if (q != null)
            {
                _ListLearningAssistToolEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListLearningAssistToolEntity.LearningAssistToolId = q.LearningAssistToolId;
                _ListLearningAssistToolEntity.ListLearningAssistToolId = q.ListLearningAssistToolId;
            }
            else
            {
                _ListLearningAssistToolEntity = null;
            }
            return _ListLearningAssistToolEntity;
        }

        public IQueryable<ListLearningAssistToolEntity> GetAll()
        {
            return (IQueryable<ListLearningAssistToolEntity>)_ListLearningAssistToolDAC.GetAll();
        }

        public IQueryable<ListLearningAssistToolEntity> GetAll(int ID)
        {
            return _ListLearningAssistToolDAC.GetAllListLearningAssistTool(ID);
        }

        public bool Addlist(List<ListLearningAssistToolEntity> Current)
        {
            foreach (var item in Current)
            {
                //if (GetDeleteLearningAssistTool(item.DesignTrainingCourseId, item.LearningAssistToolId) != null && item.State)
                //{
                //    Edit(item);
                //}
                if (GetLearningAssistTool(item.DesignTrainingCourseId, item.LearningAssistToolId) == null && item.State)
                {
                    ListLearningAssistTool _ListLearningAssistTool = new ListLearningAssistTool(item.DesignTrainingCourseId, item.LearningAssistToolId);
                    _ListLearningAssistToolDAC.Add(_ListLearningAssistTool);
                }
                else if (Get(item.ListLearningAssistToolId) != null && item.State == false)
                {
                    Delete(item.ListLearningAssistToolId);
                }
            }
            return true;
        }

        #region ListStyleCourseReport
        public IQueryable<ListLearningAssistToolEntity> GetListLearningAssistTool(int ID)
        {

            return _ListLearningAssistToolDAC.GetListLearningAssistTool(ID);
        }

        #endregion
    }
}
