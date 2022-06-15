using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class CriterionAssessmentOfTrainingServiceDAC : ICriterionAssessmentOfTrainingServiceRepository
    {
        public int Add(CriterionAssessmentOfTrainingService Current)
        {
            TrainingContext db = new TrainingContext();
            db.CriterionAssessmentOfTrainingServices.Add(Current);
            db.SaveChanges();
            return Current.CriterionAssessmentOfTrainingServiceId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            try
            {
                TrainingContext db = new TrainingContext();
                var criterionAssessmentOfTrainingService = new CriterionAssessmentOfTrainingService() { AssessmentOfTrainingServiceId = ID, Hidden = true };
                db.Entry(criterionAssessmentOfTrainingService).Property(x => x.Hidden).IsModified = true;
                db.CriterionAssessmentOfTrainingServices.Attach(criterionAssessmentOfTrainingService);
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(CriterionAssessmentOfTrainingService Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.CriterionAssessmentOfTrainingServices.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Earnpoints).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public CriterionAssessmentOfTrainingService Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.CriterionAssessmentOfTrainingServices.SingleOrDefault(x => x.CriterionAssessmentOfTrainingServiceId == ID);
        }

        public CriterionAssessmentOfTrainingService Get(int assessmentoftrainingserviceid, int typeofevaluationid)
        {
            TrainingContext db = new TrainingContext();
            return db.CriterionAssessmentOfTrainingServices.SingleOrDefault(x => x.AssessmentOfTrainingServiceId == assessmentoftrainingserviceid
                                                                              && x.TypeOfEvaluationId== typeofevaluationid);
        }

        public IQueryable<CriterionAssessmentOfTrainingService> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.CriterionAssessmentOfTrainingServices select item;
        }

        public IQueryable<CriterionAssessmentOfTrainingServiceEntity> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from typeofevaluation in db.TypeOfEvaluations.Where(a => a.Hidden == false)
                 join criterionassessmentofTrainingservice in db.CriterionAssessmentOfTrainingServices.Where(a => a.AssessmentOfTrainingServiceId==ID && a.Hidden == false) 
                    on typeofevaluation.TypeOfEvaluationId equals criterionassessmentofTrainingservice.TypeOfEvaluationId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new CriterionAssessmentOfTrainingServiceEntity
                 {
                     AssessmentOfTrainingServiceId = (temp.AssessmentOfTrainingServiceId == null?0: temp.AssessmentOfTrainingServiceId),
                     CriterionAssessmentOfTrainingServiceId = (temp.CriterionAssessmentOfTrainingServiceId == null?0: temp.CriterionAssessmentOfTrainingServiceId),
                     Description = (temp.Description == null?"": temp.Description),
                     Earnpoints = (temp.Earnpoints == null?0: temp.Earnpoints),
                     TypeOfEvaluationId = typeofevaluation.TypeOfEvaluationId,
                     TypeOfEvaluationName = typeofevaluation.Title,
                     MaxScore = typeofevaluation.MaxScore

                 });
            return _query;
        }

    }
}
