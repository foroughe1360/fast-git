using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;

namespace DataAccess
{
    public class TeacherLevelDAC : ITeacherLevelRepository
    {
        public int Add(TeacherLevel Current)
        {
            TrainingContext db = new TrainingContext();
            db.TeacherLevels.Add(Current);
            db.SaveChanges();
            return Current.TeacherLevelId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var teacherlevel = new TeacherLevel() { TeacherLevelId = ID, Hidden = true };
                db.TeacherLevels.Attach(teacherlevel);
                db.Entry(teacherlevel).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TeacherLevel Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TeacherLevels.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TeacherId).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingCourse).IsModified = true;
                db.Entry(Current).Property(x => x.EffectivenessOfPreviousPeriod).IsModified = true;
                db.Entry(Current).Property(x => x.Rhetorical).IsModified = true;
                db.Entry(Current).Property(x => x.EducationId).IsModified = true;
                db.Entry(Current).Property(x => x.Experience).IsModified = true;
                db.Entry(Current).Property(x => x.CoursePlan).IsModified = true;
                db.Entry(Current).Property(x => x.HistoryOfCooperation).IsModified = true;

                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TeacherLevel Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TeacherLevels.SingleOrDefault(x => x.TeacherLevelId == ID);
        }

        public IQueryable<TeacherLevel> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TeacherLevels select item;
        }

        public IQueryable<TeacherLevelEntity> GetAllTeacherLevel(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from teacherlevels in db.TeacherLevels.Where(a => a.Hidden == false && a.TeacherLevelDateId == ID)
                 join teachers in db.Teachers on teacherlevels.TeacherId equals teachers.TeacherId
                 select new TeacherLevelEntity
                 {
                     TeacherLevelDateId = teacherlevels.TeacherLevelDateId,
                     TeacherLevelId = teacherlevels.TeacherLevelId,
                     TeacherId = teacherlevels.TeacherId,
                     TeacherName = teachers.Name + " " + teachers.Family,
                     TrainingCourse = teacherlevels.TrainingCourse,
                     EffectivenessOfPreviousPeriod = teacherlevels.EffectivenessOfPreviousPeriod,
                     Rhetorical = teacherlevels.Rhetorical,
                     EducationId = teacherlevels.EducationId,
                     CoursePlan = teacherlevels.CoursePlan,
                     Experience = teacherlevels.Experience,
                     HistoryOfCooperation = teacherlevels.HistoryOfCooperation,
                     Total = (teacherlevels.EffectivenessOfPreviousPeriod + teacherlevels.Rhetorical + teacherlevels.EducationId +
                                teacherlevels.CoursePlan + teacherlevels.Experience + teacherlevels.HistoryOfCooperation),
                     Degree = teacherlevels.Degree,

                 });
        }
        public IQueryable<TeacherLevelEntity> GetAllTeacherLevel(TeacherLevelSearch teacherlevelsearch)
        {
            TrainingContext db = new TrainingContext();
            var list = 
                (from teacherlevels in db.TeacherLevels.Where(a => a.Hidden == false && a.TeacherLevelDateId == teacherlevelsearch.TeacherLevelDateId)
                 join teachers in db.Teachers on teacherlevels.TeacherId equals teachers.TeacherId
                 select new TeacherLevelEntity
                 {
                     TeacherLevelDateId = teacherlevels.TeacherLevelDateId,
                     TeacherLevelId = teacherlevels.TeacherLevelId,
                     TeacherId = teacherlevels.TeacherId,
                     TeacherName = teachers.Name + " " + teachers.Family,
                     TrainingCourse = teacherlevels.TrainingCourse,
                     EffectivenessOfPreviousPeriod = teacherlevels.EffectivenessOfPreviousPeriod,
                     Rhetorical = teacherlevels.Rhetorical,
                     EducationId = teacherlevels.EducationId,
                     CoursePlan = teacherlevels.CoursePlan,
                     Experience = teacherlevels.Experience,
                     HistoryOfCooperation = teacherlevels.HistoryOfCooperation,
                     Total = (teacherlevels.EffectivenessOfPreviousPeriod + teacherlevels.Rhetorical + teacherlevels.EducationId +
                                teacherlevels.CoursePlan + teacherlevels.Experience + teacherlevels.HistoryOfCooperation),

                 });
            if (teacherlevelsearch.TeacherName.Trim() != "")
                list = list.Where(p => p.TeacherName.Contains(teacherlevelsearch.TeacherName));
            return list;
        }


    }
}
