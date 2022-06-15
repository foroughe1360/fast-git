using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using System.Data.Entity;

namespace DataAccess
{
    public class LogErrorDAC : ILogErrorRepository
    {
        public int Add(LogError Current)
        {
            TrainingContext db = new TrainingContext();
            db.LogErrors.Add(Current);
            db.SaveChanges();
            return Current.LogErrorId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var logerror = new LogError() { LogErrorId = ID, Hidden = true };
                db.LogErrors.Attach(logerror);
                db.Entry(logerror).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(LogError Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.LogErrors.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public LogError Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.LogErrors.SingleOrDefault(x => x.LogErrorId == ID);
        }

        public IQueryable<LogError> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.LogErrors select item;
        }
    }
}
