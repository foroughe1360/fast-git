using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;

namespace DataAccess
{
    public class DetailTypeRateDAC : IDetailTypeRateRepository
    {
        public int Add(DetailTypeRate Current)
        {
            TrainingContext db = new TrainingContext();
            db.DetailTypeRates.Add(Current);
            db.SaveChanges();
            return Current.DetailTypeRateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var detailtypeRate = new DetailTypeRate() { DetailTypeRateId = ID, Hidden = true };
                db.DetailTypeRates.Attach(detailtypeRate);
                db.Entry(detailtypeRate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(DetailTypeRate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DetailTypeRates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TypesRateId).IsModified = true;
                db.Entry(Current).Property(x => x.Parent).IsModified = true;
                db.Entry(Current).Property(x => x.DetailTypeName).IsModified = true;
                db.Entry(Current).Property(x => x.NumDetailType).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public DetailTypeRate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DetailTypeRates.SingleOrDefault(x => x.DetailTypeRateId == ID);
        }

        public IQueryable<DetailTypeRate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DetailTypeRates select item;
        }

        public IQueryable<DetailTypeRateEntity> GetAllDetailTypeRate(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from detailtyperates in db.DetailTypeRates.Where(a => a.TypesRateId == ID && a.Hidden==false)
                 join typesrates in db.TypesRates on detailtyperates.TypesRateId equals typesrates.TypesRateId
                 select new DetailTypeRateEntity
                 {
                     DetailTypeName = detailtyperates.DetailTypeName,
                     DetailTypeRateId = detailtyperates.DetailTypeRateId,
                     NumDetailType = detailtyperates.NumDetailType,
                     Parent = detailtyperates.Parent,
                     TypesRateId = detailtyperates.TypesRateId,
                     TypesRateName =  typesrates.RateName
                 });

        }
    }
}
