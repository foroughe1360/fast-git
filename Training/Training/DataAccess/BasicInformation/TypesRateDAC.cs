using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;

namespace DataAccess
{
    public class TypesRateDAC : ITypesRateRepository
    {
        public int Add(TypesRate Current)
        {
            TrainingContext db = new TrainingContext();
            db.TypesRates.Add(Current);
            db.SaveChanges();
            return Current.TypesRateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var typesrate = new TypesRate() { TypesRateId = ID, Hidden = true };
                db.TypesRates.Attach(typesrate);
                db.Entry(typesrate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TypesRate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TypesRates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.RateName).IsModified = true;
                db.Entry(Current).Property(x => x.NumberRate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TypesRate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TypesRates.SingleOrDefault(x => x.TypesRateId == ID);
        }

        public IQueryable<TypesRate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TypesRates.Where(a => a.Hidden==false) select item;
        }
    }
}
