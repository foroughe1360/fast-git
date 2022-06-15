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
    public class ListEffectivenessOfCourseProvider : IListEffectivenessOfCourseProvider
    {
        private ListEffectivenessOfCourseDAC _ListEffectivenessOfCourseDAC;
        public ListEffectivenessOfCourseProvider()
        {
            _ListEffectivenessOfCourseDAC = new ListEffectivenessOfCourseDAC();
        }

        public int Add(ListEffectivenessOfCourseEntity Current)
        {
            ListEffectivenessOfCourse _ListEffectivenessOfCourse = new ListEffectivenessOfCourse(Current.DesignTrainingCourseId,Current.EffectivenessOfCoursesId);
            return _ListEffectivenessOfCourseDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListEffectivenessOfCourseDAC.Delete(ID);
        }

        public bool Edit(ListEffectivenessOfCourseEntity Current)
        {
            ListEffectivenessOfCourse _ListEffectivenessOfCourse = new ListEffectivenessOfCourse();
            _ListEffectivenessOfCourse.ListEffectivenessOfCourseId = Current.ListEffectivenessOfCourseId;
            _ListEffectivenessOfCourse.TimeLastModified = DateTime.Now;
            _ListEffectivenessOfCourse.Hidden = false;
            return _ListEffectivenessOfCourseDAC.Edit(Current);
        }

        public ListEffectivenessOfCourseEntity Get(int ID)
        {
            ListEffectivenessOfCourseEntity _ListEffectivenessOfCourseEntity = new ListEffectivenessOfCourseEntity();
            var q = _ListEffectivenessOfCourseDAC.Get(ID);
            if (q != null)
            {
                _ListEffectivenessOfCourseEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListEffectivenessOfCourseEntity.EffectivenessOfCoursesId = q.EffectivenessOfCoursesId;
                _ListEffectivenessOfCourseEntity.ListEffectivenessOfCourseId = q.ListEffectivenessOfCourseId;
            }
            else
            {
                _ListEffectivenessOfCourseEntity = null;
            }
            return _ListEffectivenessOfCourseEntity;
        }

        public ListEffectivenessOfCourseEntity GetEffectivenessOfCourse(int designtrainingcourseid, int effectivenessofcourseid)
        {
            ListEffectivenessOfCourseEntity _ListEffectivenessOfCourseEntity = new ListEffectivenessOfCourseEntity();
            var q = _ListEffectivenessOfCourseDAC.GetEffectivenessOfCourse(designtrainingcourseid, effectivenessofcourseid);
            if (q != null)
            {
                _ListEffectivenessOfCourseEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListEffectivenessOfCourseEntity.EffectivenessOfCoursesId = q.EffectivenessOfCoursesId;
                _ListEffectivenessOfCourseEntity.ListEffectivenessOfCourseId = q.ListEffectivenessOfCourseId;
            }
            else
            {
                _ListEffectivenessOfCourseEntity = null;
            }
            return _ListEffectivenessOfCourseEntity;
        }

        public ListEffectivenessOfCourseEntity GetDeleteEffectivenessOfCourse(int designtrainingcourseid, int effectivenessofcourseid)
        {
            ListEffectivenessOfCourseEntity _ListEffectivenessOfCourseEntity = new ListEffectivenessOfCourseEntity();
            var q = _ListEffectivenessOfCourseDAC.GetDeleteEffectivenessOfCourse(designtrainingcourseid, effectivenessofcourseid);
            if (q != null)
            {
                _ListEffectivenessOfCourseEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
                _ListEffectivenessOfCourseEntity.EffectivenessOfCoursesId = q.EffectivenessOfCoursesId;
                _ListEffectivenessOfCourseEntity.ListEffectivenessOfCourseId = q.ListEffectivenessOfCourseId;
            }
            else
            {
                _ListEffectivenessOfCourseEntity = null;
            }
            return _ListEffectivenessOfCourseEntity;
        }

        public IQueryable<ListEffectivenessOfCourseEntity> GetAll()
        {
            return (IQueryable<ListEffectivenessOfCourseEntity>)_ListEffectivenessOfCourseDAC.GetAll();
        }

        public IQueryable<ListEffectivenessOfCourseEntity> GetAll(int ID)
        {
            return _ListEffectivenessOfCourseDAC.GetAllListEffectivenessOfCourse(ID);
        }

        public bool Addlist(List<ListEffectivenessOfCourseEntity> Current)
        {
            foreach (var item in Current)
            {
                if (GetEffectivenessOfCourse(item.DesignTrainingCourseId, item.EffectivenessOfCoursesId) == null && item.State)
                {
                    ListEffectivenessOfCourse _ListEffectivenessOfCourse = new ListEffectivenessOfCourse(item.DesignTrainingCourseId, item.EffectivenessOfCoursesId);
                    _ListEffectivenessOfCourseDAC.Add(_ListEffectivenessOfCourse);
                }
                else if (Get(item.ListEffectivenessOfCourseId) != null && item.State == false)
                {
                    Delete(item.ListEffectivenessOfCourseId);
                }
            }
            return true;
        }

        #region ListEffectivenessOfCourseReport
        public IQueryable<ListEffectivenessOfCourseEntity> getListEffectivenessOfCourse(int ID)
        {

            return _ListEffectivenessOfCourseDAC.getListEffectivenessOfCourse(ID);
        }

        #endregion
    }
}
