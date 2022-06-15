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
    public class TypeOfEvaluationDAC : ITypeOfEvaluationRepository
    {
        public int Add(TypeOfEvaluation Current)
        {
            TrainingContext db = new TrainingContext();
            db.TypeOfEvaluations.Add(Current);
            db.SaveChanges();
            return Current.TypeOfEvaluationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var typeofevaluation = new TypeOfEvaluation() { TypeOfEvaluationId = ID, Hidden = true };
                db.TypeOfEvaluations.Attach(typeofevaluation);
                db.Entry(typeofevaluation).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TypeOfEvaluation Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TypeOfEvaluations.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Title).IsModified = true;
                db.Entry(Current).Property(x => x.MaxScore).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TypeOfEvaluation Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TypeOfEvaluations.SingleOrDefault(x => x.TypeOfEvaluationId == ID);
        }

        public IQueryable<TypeOfEvaluation> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TypeOfEvaluations select item;
        }
    }
}
