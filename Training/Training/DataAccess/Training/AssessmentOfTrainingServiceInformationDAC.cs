using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;

namespace DataAccess
{
    public class AssessmentOfTrainingServiceInformationDAC : IAssessmentOfTrainingServiceInformationRepository
    {
        public int Add(AssessmentOfTrainingServiceInformation Current)
        {
            TrainingContext db = new TrainingContext();
            db.AssessmentOfTrainingServiceInformations.Add(Current);
            db.SaveChanges();
            return Current.AssessmentOfTrainingServiceInformationId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            try
            {
                TrainingContext db = new TrainingContext();
                var assessmentOfTrainingServiceInformation = new AssessmentOfTrainingServiceInformation () { AssessmentOfTrainingServiceInformationId = ID, Hidden = true };
                db.AssessmentOfTrainingServiceInformations.Attach(assessmentOfTrainingServiceInformation);
                db.Entry(assessmentOfTrainingServiceInformation).Property(x => x.Hidden).IsModified = true;

                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(AssessmentOfTrainingServiceInformation Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.AssessmentOfTrainingServiceInformations.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Name).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public AssessmentOfTrainingServiceInformation Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.AssessmentOfTrainingServiceInformations.SingleOrDefault(x => x.AssessmentOfTrainingServiceInformationId == ID);
        }

        public IQueryable<AssessmentOfTrainingServiceInformation> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.AssessmentOfTrainingServiceInformations select item;
        }
    }
}
