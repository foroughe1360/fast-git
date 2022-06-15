using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DataAccess
{
    public class HoursCertificationDAC : IHoursCertificationRepository
    {
        public int Add(HoursCertification Current)
        {
            TrainingContext db = new TrainingContext();
            db.HoursCertifications.Add(Current);
            db.SaveChanges();
            return Current.HoursCertificationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var hourscertification = new HoursCertification() { HoursCertificationId = ID, Hidden = true };
                db.HoursCertifications.Attach(hourscertification);
                db.Entry(hourscertification).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(HoursCertification Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.HoursCertifications.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TimePeriod).IsModified = true;
                db.Entry(Current).Property(x => x.HoursCertificationDate).IsModified = true;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Success = false;
            }
            return Success;
        }

        public HoursCertification Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.HoursCertifications.SingleOrDefault(x => x.HoursCertificationId == ID);
        }

        public IQueryable<HoursCertification> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.HoursCertifications.Where(a => a.Hidden== false) select item;
        }
    }
}
