using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess.Training
{
    public class OfferTrainingForJobDateDAC : IOfferTrainingForJobDateRepository
    {
        public int Add(OfferTrainingForJobDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.OfferTrainingForJobDates.Add(Current);
            db.SaveChanges();
            return Current.OfferTrainingForJobDateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var offertrainingforjobdate = new OfferTrainingForJobDate() { OfferTrainingForJobDateId = ID, Hidden = true };
                db.OfferTrainingForJobDates.Attach(offertrainingforjobdate);
                db.Entry(offertrainingforjobdate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(OfferTrainingForJobDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.OfferTrainingForJobDates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.OTFJDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public OfferTrainingForJobDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.OfferTrainingForJobDates.SingleOrDefault(x => x.OfferTrainingForJobDateId == ID);
        }

        public IQueryable<OfferTrainingForJobDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.OfferTrainingForJobDates select item;
        }

        public IQueryable<OfferTrainingForJobDateEntity> GetAllOfferTrainingForJobDate()
        {
            TrainingContext db = new TrainingContext();
            return
                (from offertrainingforjobdates in db.OfferTrainingForJobDates.Where(a=>a.Hidden==false)
                 select new OfferTrainingForJobDateEntity
                 {
                     OfferTrainingForJobDateId = offertrainingforjobdates.OfferTrainingForJobDateId,
                     Description = offertrainingforjobdates.Description,
                     OTFJDate = offertrainingforjobdates.OTFJDate
                 });
        }
    }
}
