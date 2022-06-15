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
    public class OfferTrainingForEmployeeDateDAC : IOfferTrainingForEmployeeDateRepository
    {
        public int Add(OfferTrainingForEmployeeDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.OfferTrainingForEmployeeDate.Add(Current);
            db.SaveChanges();
            return Current.OfferTrainingForEmployeeDateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var offertrainingforemployeedate = new OfferTrainingForEmployeeDate() { OfferTrainingForEmployeeDateId = ID, Hidden = true };
                db.OfferTrainingForEmployeeDate.Attach(offertrainingforemployeedate);
                db.Entry(offertrainingforemployeedate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(OfferTrainingForEmployeeDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.OfferTrainingForEmployeeDate.Attach(Current);
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

        public OfferTrainingForEmployeeDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.OfferTrainingForEmployeeDate.SingleOrDefault(x => x.OfferTrainingForEmployeeDateId == ID);
        }

        public IQueryable<OfferTrainingForEmployeeDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.OfferTrainingForEmployeeDate select item;
        }

        public IQueryable<OfferTrainingForEmployeeDateEntity> GetAllOfferTrainingForEmployeeDate()
        {
            TrainingContext db = new TrainingContext();
            return
                (from offertrainingforemployeedate in db.OfferTrainingForEmployeeDate.Where(a => a.Hidden == false)
                 select new OfferTrainingForEmployeeDateEntity
                 {
                     OfferTrainingForEmployeeDateId = offertrainingforemployeedate.OfferTrainingForEmployeeDateId,
                     Description = offertrainingforemployeedate.Description,
                     OTFJDate = offertrainingforemployeedate.OTFJDate
                 });
        }

    }
}
