using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;

namespace DataAccess
{
    public class EmployeeEvaluationDAC : IEmployeeEvaluationRepository
    {
        public int Add(EmployeeEvaluation Current)
        {
            TrainingContext db = new TrainingContext();
            db.EmployeeEvaluations.Add(Current);
            db.SaveChanges();
            return Current.EmployeeEvaluationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var employeeEvaluation = new EmployeeEvaluation() { EmployeeEvaluationId = ID, Hidden = true };
                db.EmployeeEvaluations.Attach(employeeEvaluation);
                db.Entry(employeeEvaluation).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();

                //TrainingContext db = new TrainingContext();
                //var accessmenuUser = db.AccessMenuUsers.SingleOrDefault(x => x.AccessMenuUserId == ID);
                //db.AccessMenuUsers.Remove(accessmenuUser);
                //db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(EmployeeEvaluation Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.EmployeeEvaluations.Attach(Current);
                db.Entry(Current).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch 
            {
                return Success = false;
            }
            return Success;
        }

        public EmployeeEvaluation Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.EmployeeEvaluations.SingleOrDefault(x => x.EmployeeEvaluationId == ID);
        }

        public IQueryable<EmployeeEvaluation> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.EmployeeEvaluations select item;
        }
    }
}
