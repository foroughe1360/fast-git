using DataAccess.InfraStructre.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess.Training
{
    public class TrainingCalendarDateDAC : ITrainingCalendarDateRepository
    {
        public int Add(TrainingCalendarDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.TrainingCalendarDates.Add(Current);
            db.SaveChanges();
            return Current.TrainingCalendarDateId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var trainingcalendardate = new TrainingCalendarDate() { TrainingCalendarDateId = ID, Hidden = true };
                db.TrainingCalendarDates.Attach(trainingcalendardate);
                db.Entry(trainingcalendardate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(TrainingCalendarDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TrainingCalendarDates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.TrCalendarDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
        public TrainingCalendarDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TrainingCalendarDates.SingleOrDefault(x => x.TrainingCalendarDateId == ID);
        }
        public IQueryable<TrainingCalendarDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TrainingCalendarDates select item;
        }
        public IQueryable<TrainingCalendarDateEntity> GetAllTrainingCalendarDate()
        {
            TrainingContext db = new TrainingContext();
            return 
                (from TrainingCalendarDates in db.TrainingCalendarDates.Where(a=>a.Hidden == false)
                 select new TrainingCalendarDateEntity
                 {
                     TrainingCalendarDateId=TrainingCalendarDates.TrainingCalendarDateId,
                     Description=TrainingCalendarDates.Description,
                     TrCalendarDate=TrainingCalendarDates.TrCalendarDate
                 });
        }
    }
}
