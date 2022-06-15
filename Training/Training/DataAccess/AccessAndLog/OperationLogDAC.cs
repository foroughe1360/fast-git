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
    public class OperationLogDAC : IOperationLogRepository
    {
        public int Add(OperationLog Current)
        {
            TrainingContext db = new TrainingContext();
            db.OperationLogs.Add(Current);
            db.SaveChanges();
            return Current.OperationLogId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var operationlog = new OperationLog() { OperationLogId = ID, Hidden = true };
                db.OperationLogs.Attach(operationlog);
                db.Entry(operationlog).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(OperationLog Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.OperationLogs.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public OperationLog Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.OperationLogs.SingleOrDefault(x => x.OperationLogId == ID);
        }

        public IQueryable<OperationLog> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.OperationLogs select item;
        }
    }
}
