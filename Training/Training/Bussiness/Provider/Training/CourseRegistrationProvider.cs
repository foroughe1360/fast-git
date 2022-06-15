using Bussiness.InfraStructre;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace Bussiness
{
    public class CourseRegistrationProvider : ICourseRegistrationProvider
    {
        private CourseRegistrationDAC _CourseRegistrationDAC;
        public CourseRegistrationProvider()
        {
            _CourseRegistrationDAC = new CourseRegistrationDAC();
        }
        public int Add(CourseRegistrationEntity Current)
        {
            CourseRegistration _CourseRegistration = new CourseRegistration(Current.DesignTrainingCourseId, Current.EmployemeId,Current.EmployemeStateID);

            return _CourseRegistrationDAC.Add(_CourseRegistration);
        }

        public bool Delete(int ID)
        {
            return _CourseRegistrationDAC.Delete(ID);
        }

        public bool Edit(CourseRegistrationEntity Current)
        {
            CourseRegistration _CourseRegistration = new CourseRegistration();
            _CourseRegistration.CourseRegistrationId = Current.CourseRegistrationId;
            _CourseRegistration.TimeLastModified = DateTime.Now;
            _CourseRegistration.DesignTrainingCourseId = Current.DesignTrainingCourseId;
            _CourseRegistration.EmployemeId = Current.EmployemeId;
            _CourseRegistration.EmployemeStateID = Current.EmployemeStateID;
            return _CourseRegistrationDAC.Edit(_CourseRegistration);
        }

        public CourseRegistrationEntity Get(int ID)
        {
            CourseRegistrationEntity _CourseRegistrationEntity = new CourseRegistrationEntity();
            var q = _CourseRegistrationDAC.Get(ID);
            _CourseRegistrationEntity.CourseRegistrationId = q.CourseRegistrationId;
            _CourseRegistrationEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
            _CourseRegistrationEntity.EmployemeId = q.EmployemeId;
            _CourseRegistrationEntity.EmployemeStateID = q.EmployemeStateID;
            return _CourseRegistrationEntity;
        }

        public IQueryable<CourseRegistrationEntity> GetAll()
        {
            return (IQueryable<CourseRegistrationEntity>) _CourseRegistrationDAC.GetAll();
        }

        public IQueryable<CourseRegistrationEntity> GetAll(int ID)
        {
            return _CourseRegistrationDAC.GetAllCourseRegistration(ID);
        }
    }
}
