using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class TrainingCourseProvider : ITrainingCourseProvider
    {
        private TrainingCourseDAC _TrainingCourseDAC;
        public TrainingCourseProvider()
        {
            _TrainingCourseDAC = new TrainingCourseDAC();
        }
        public int Add(TrainingCourseEntity Current)
        {
            TrainingCourse _TrainingCourse = new TrainingCourse(Current.CourseName,Current.CourseTypeId);
            return _TrainingCourseDAC.Add(_TrainingCourse);
        }
        public bool Delete(int ID)
        {
            return _TrainingCourseDAC.Delete(ID);
        }
        public bool Edit(TrainingCourseEntity Current)
        {
            TrainingCourse _TrainingCourse = new TrainingCourse();
            _TrainingCourse.TrainingCourseId = Current.TrainingCourseId;
            _TrainingCourse.TimeLastModified = DateTime.Now;
            _TrainingCourse.CourseName = Current.CourseName;
            _TrainingCourse.CourseTypeId = Current.CourseTypeId;
            return _TrainingCourseDAC.Edit(_TrainingCourse);
        }
        public TrainingCourseEntity Get(int ID)
        {
            TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
            var q = _TrainingCourseDAC.Get(ID);
            _TrainingCourseEntity.TrainingCourseId = q.TrainingCourseId;
            _TrainingCourseEntity.CourseName = q.CourseName;
            _TrainingCourseEntity.CourseTypeId = q.CourseTypeId;
            return _TrainingCourseEntity;
        }
        public IQueryable<TrainingCourseEntity> GetAll()
        {
            return _TrainingCourseDAC.GetAllTrainingCourse();
        }
    }
}
