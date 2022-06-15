using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;

namespace DataAccess
{
    public class ListEmployeeEvaluationDAC : IListEmployeeEvaluationRepository
    {
        public int Add(ListEmployeeEvaluation Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListEmployeeEvaluations.Add(Current);
            db.SaveChanges();
            return Current.ListEmployeeEvaluationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listEmployeeEvaluation = new ListEmployeeEvaluation() { ListEmployeeEvaluationId = ID, Hidden = true };
                db.ListEmployeeEvaluations.Attach(listEmployeeEvaluation);
                db.Entry(listEmployeeEvaluation).Property(x => x.Hidden).IsModified = true;
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

        public bool Edit(ListEmployeeEvaluation Current)
        {
            throw new NotImplementedException();
        }

        public ListEmployeeEvaluation Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListEmployeeEvaluations.SingleOrDefault(x => x.EmployemesId == ID);
        }

        public IQueryable<ListEmployeeEvaluation> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListEmployeeEvaluations select item;
        }
    }
}
