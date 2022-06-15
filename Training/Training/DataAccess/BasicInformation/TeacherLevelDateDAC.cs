using DataAccess.InfraStructre.BasicInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class TeacherLevelDateDAC : ITeacherLevelDateRepository
    {
        public int Add(TeacherLevelDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.TeacherLevelDates.Add(Current);
            db.SaveChanges();
            return Current.TeacherLevelDateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var teacherleveldate = new TeacherLevelDate() { TeacherLevelDateId = ID, Hidden = true };
                db.TeacherLevelDates.Attach(teacherleveldate);
                db.Entry(teacherleveldate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TeacherLevelDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TeacherLevelDates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.LevelDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TeacherLevelDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TeacherLevelDates.SingleOrDefault(x => x.TeacherLevelDateId == ID);
        }

        public IQueryable<TeacherLevelDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TeacherLevelDates select item;
        }

        public IQueryable<TeacherLevelDateEntity> GetAllTeacherLevelDate()
        {
            TrainingContext db = new TrainingContext();
            return
                (from teacherleveldates in db.TeacherLevelDates.Where(a=>a.Hidden==false)
                 select new TeacherLevelDateEntity
                 {
                     TeacherLevelDateId = teacherleveldates.TeacherLevelDateId,
                     Description=teacherleveldates.Description,
                     LevelDate = teacherleveldates.LevelDate
                 });
        }

       

    }
}
