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
    public class ListStyleCourseProvider : IListStyleCourseProvider
    {
        private ListStyleCourseDAC _ListStyleCourseDAC;
        public ListStyleCourseProvider()
        {
            _ListStyleCourseDAC = new ListStyleCourseDAC();
        }
        public int Add(ListStyleCourseEntity Current)
        {
            ListStyleCourse _ListStyleCourse = new ListStyleCourse(Current.DesignTrainingCourseId, Current.StyleCoursesId);
            return _ListStyleCourseDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListStyleCourseDAC.Delete(ID);
        }

        public bool Edit(ListStyleCourseEntity Current)
        {
            ListStyleCourse _ListStyleCourse = new ListStyleCourse();
            _ListStyleCourse.ListStyleCourseId = Current.ListStyleCourseId;
            _ListStyleCourse.DesignTrainingCourseId = Current.DesignTrainingCourseId;
            _ListStyleCourse.TimeLastModified = DateTime.Now;
            _ListStyleCourse.Hidden = false;
            return _ListStyleCourseDAC.Edit(_ListStyleCourse);
        }

        public ListStyleCourseEntity Get(int ID)
        {
            ListStyleCourseEntity _ListStyleCourseEntity = new ListStyleCourseEntity();
            var q = _ListStyleCourseDAC.Get(ID);
            if (q != null)
            { 
                _ListStyleCourseEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListStyleCourseEntity.ListStyleCourseId = q.ListStyleCourseId;
                _ListStyleCourseEntity.StyleCoursesId = q.StyleCoursesId;
            }
            else
            {
                _ListStyleCourseEntity = null;
            }
            return _ListStyleCourseEntity;
        }

        public ListStyleCourseEntity GetStyleCourse(int designtrainingcourseid, int StyleCourseid)
        {
            ListStyleCourseEntity _ListStyleCourseEntity = new ListStyleCourseEntity();
            var q = _ListStyleCourseDAC.GetLearningAssistTool(designtrainingcourseid, StyleCourseid);
            if (q != null)
            {
                _ListStyleCourseEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListStyleCourseEntity.ListStyleCourseId = q.ListStyleCourseId;
                _ListStyleCourseEntity.StyleCoursesId = q.StyleCoursesId;
            }
            else
            {
                _ListStyleCourseEntity = null;
            }
            return _ListStyleCourseEntity;
        }

        public ListStyleCourseEntity GetDeleteLearningAssistTool(int designtrainingcourseid, int StyleCourseid)
        {
            ListStyleCourseEntity _ListStyleCourseEntity = new ListStyleCourseEntity();
            var q = _ListStyleCourseDAC.GetDeleteLearningAssistTool(designtrainingcourseid, StyleCourseid);
            if (q != null)
            {
                _ListStyleCourseEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListStyleCourseEntity.ListStyleCourseId = q.ListStyleCourseId;
                _ListStyleCourseEntity.StyleCoursesId = q.StyleCoursesId;
            }
            else
            {
                _ListStyleCourseEntity = null;
            }
            return _ListStyleCourseEntity;
        }

        public IQueryable<ListStyleCourseEntity> GetAll()
        {
            return (IQueryable < ListStyleCourseEntity > )_ListStyleCourseDAC.GetAll();
        }

        public IQueryable<ListStyleCourseEntity> GetAll(int ID)
        {
            return _ListStyleCourseDAC.GetAllListStyleCourse(ID);
        }

        public bool Addlist(List<ListStyleCourseEntity> Current)
        {
            foreach (var item in Current)
            {
                if (GetStyleCourse(item.DesignTrainingCourseId, item.StyleCoursesId) == null && item.State)
                {
                    ListStyleCourse _ListStyleCourse = new ListStyleCourse(item.DesignTrainingCourseId, item.StyleCoursesId);
                    _ListStyleCourseDAC.Add(_ListStyleCourse);
                }
                else if (Get(item.ListStyleCourseId) != null && item.State == false)
                {
                    Delete(item.ListStyleCourseId);
                }
            }
            return true;
        }

        #region DesignTrainingCourseReport
            public IQueryable<ListStyleCourseEntity> getListStyleCoursesReport(int ID)
        {

            return _ListStyleCourseDAC.getListStyleCoursesReport(ID);
        }
        
        #endregion
    }
}
