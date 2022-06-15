using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class TeacherLevelProvider : ITeacherLevelProvider
    {
        private TeacherLevelDAC _TeacherLevelDAC;

        public TeacherLevelProvider()
        {
            _TeacherLevelDAC = new TeacherLevelDAC();
        }
        public int Add(TeacherLevelEntity Current)
        {
            TeacherLevel _TeacherLevel = new TeacherLevel(Current.TeacherLevelDateId,Current.TeacherId,Current.TrainingCourse,Current.EffectivenessOfPreviousPeriod,
                Current.Rhetorical,Current.EducationId,Current.Experience,Current.CoursePlan,Current.HistoryOfCooperation,Current.Degree);
            return _TeacherLevelDAC.Add(_TeacherLevel);
        }
        public bool Delete(int ID)
        {
            return _TeacherLevelDAC.Delete(ID);
        }
        public bool Edit(TeacherLevelEntity Current)
        {
            TeacherLevel _TeacherLevel = new TeacherLevel();
            _TeacherLevel.TeacherLevelId = Current.TeacherLevelId;
            _TeacherLevel.TimeLastModified = DateTime.Now;
            _TeacherLevel.TeacherLevelDateId = Current.TeacherLevelDateId;
            _TeacherLevel.TeacherId = Current.TeacherId;
            _TeacherLevel.TrainingCourse = Current.TrainingCourse;
            _TeacherLevel.EffectivenessOfPreviousPeriod = Current.EffectivenessOfPreviousPeriod;
            _TeacherLevel.Rhetorical = Current.Rhetorical;
            _TeacherLevel.EducationId = Current.EducationId;
            _TeacherLevel.Experience = Current.Experience;
            _TeacherLevel.CoursePlan = Current.CoursePlan;
            _TeacherLevel.HistoryOfCooperation = Current.HistoryOfCooperation;
            _TeacherLevel.Degree = Current.Degree;
            return _TeacherLevelDAC.Edit(_TeacherLevel);
        }
        public TeacherLevelEntity Get(int ID)
        {
            TeacherLevelEntity _TeacherLevelEntity = new TeacherLevelEntity();
            var q = _TeacherLevelDAC.Get(ID);
            _TeacherLevelEntity.TeacherLevelId = q.TeacherLevelId;
            _TeacherLevelEntity.TeacherLevelDateId = q.TeacherLevelDateId;
            _TeacherLevelEntity.TeacherId = q.TeacherId;
            _TeacherLevelEntity.TrainingCourse = q.TrainingCourse;
            _TeacherLevelEntity.EffectivenessOfPreviousPeriod = q.EffectivenessOfPreviousPeriod;
            _TeacherLevelEntity.Rhetorical = q.Rhetorical;
            _TeacherLevelEntity.EducationId = q.EducationId;
            _TeacherLevelEntity.Experience = q.Experience;
            _TeacherLevelEntity.CoursePlan = q.CoursePlan;
            _TeacherLevelEntity.HistoryOfCooperation = q.HistoryOfCooperation;
            _TeacherLevelEntity.Degree = q.Degree;
            return _TeacherLevelEntity;
        }
        public IQueryable<TeacherLevelEntity> GetAll()
        {
            return (IQueryable<TeacherLevelEntity>)_TeacherLevelDAC.GetAll();
        }
        public IQueryable<TeacherLevelEntity> GetAll(int ID)
        {
            return _TeacherLevelDAC.GetAllTeacherLevel(ID);
        }
        public IQueryable<TeacherLevelEntity> GetAll(TeacherLevelSearch teacherlevelsearch)
        {
            return _TeacherLevelDAC.GetAllTeacherLevel(teacherlevelsearch);
        }

      
    }
}
