using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DataAccess
{
    public class NumberSucceedDAC : INumberSucceedRepository
    {
        public int Add(NumberSucceed Current)
        {
            TrainingContext db = new TrainingContext();
            db.NumberSucceeds.Add(Current);
            db.SaveChanges();
            return Current.NumberSucceedId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var numbersucceed = new NumberSucceed() { NumberSucceedId = ID, Hidden = true };
                db.NumberSucceeds.Attach(numbersucceed);
                db.Entry(numbersucceed).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(NumberSucceed Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.NumberSucceeds.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Number).IsModified = true;
                db.Entry(Current).Property(x => x.NumberSucceedDate).IsModified = true;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Success = false;
            }
            return Success;
        }

        public NumberSucceed Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.NumberSucceeds.SingleOrDefault(x => x.NumberSucceedId == ID);
        }

        public IQueryable<NumberSucceed> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.NumberSucceeds.Where(a => a.Hidden==false) select item;
        }
    }
}
