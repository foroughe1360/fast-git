using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class RatingEvaluationDAC : IRatingEvaluationRepository
    {
        public int Add(RatingEvaluation Current)
        {
            TrainingContext db = new TrainingContext();
            db.RatingEvaluations.Add(Current);
            db.SaveChanges();
            return Current.RatingEvaluationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var ratingevaluation = new RatingEvaluation() { RatingEvaluationId = ID, Hidden = true };
                db.RatingEvaluations.Attach(ratingevaluation);
                db.Entry(ratingevaluation).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(RatingEvaluation Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.RatingEvaluations.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.RatingEvaluationCoursesID).IsModified = true;
                db.Entry(Current).Property(x => x.Number).IsModified = true;
                db.Entry(Current).Property(x => x.RatingEvaluationDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public RatingEvaluation Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.RatingEvaluations.SingleOrDefault(x => x.RatingEvaluationId == ID);
        }

        public IQueryable<RatingEvaluation> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.RatingEvaluations select item;
        }

        public IQueryable<RatingEvaluationEntity> GetAllRatingEvaluation()
        {
            TrainingContext db = new TrainingContext();
            return
                (from ratingevaluations in db.RatingEvaluations.Where(a => a.Hidden== false)
                 join tableinterfacevalues in db.TableInterfaceValues on ratingevaluations.RatingEvaluationCoursesID equals tableinterfacevalues.TableInterfaceValueId
                 select new RatingEvaluationEntity
                 {
                     RatingEvaluationId = ratingevaluations.RatingEvaluationId,
                     RatingEvaluationCoursesID = ratingevaluations.RatingEvaluationCoursesID,
                     ratingevaluationcourseName = tableinterfacevalues.TableValue,
                     RatingEvaluationDate = ratingevaluations.RatingEvaluationDate,
                     Number = ratingevaluations.Number
                 });
        }
    }
}
