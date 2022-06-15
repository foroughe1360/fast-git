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
    public class AssessmentOfTrainingServiceDAC : IAssessmentOfTrainingServiceRepository
    {
        public int Add(AssessmentOfTrainingService Current)
        {
            TrainingContext db = new TrainingContext();
            db.AssessmentOfTrainingServices.Add(Current);
            db.SaveChanges();
            return Current.AssessmentOfTrainingServiceId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var assessmentOfTrainingService = new AssessmentOfTrainingService() { AssessmentOfTrainingServiceId = ID, Hidden = true };
                db.AssessmentOfTrainingServices.Attach(assessmentOfTrainingService);
                db.Entry(assessmentOfTrainingService).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(AssessmentOfTrainingService Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.AssessmentOfTrainingServices .Attach(Current);
                db.Entry(Current).Property(x => x.AssessmentOfTrainingServiceId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.InstitutionName).IsModified = true;
                db.Entry(Current).Property(x => x.ManagingDirector).IsModified = true;
                db.Entry(Current).Property(x => x.TypeOfCompanyId).IsModified = true;
                db.Entry(Current).Property(x => x.TypeOfInstitutionId).IsModified = true;
                db.Entry(Current).Property(x => x.ScopeOfTheActivities).IsModified = true;
                db.Entry(Current).Property(x => x.EconomicCode).IsModified = true;
                db.Entry(Current).Property(x => x.TeacherName).IsModified = true;
                db.Entry(Current).Property(x => x.EducationId).IsModified = true;
                db.Entry(Current).Property(x => x.Address).IsModified = true;
                

                //db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public AssessmentOfTrainingService Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.AssessmentOfTrainingServices.SingleOrDefault(x => x.AssessmentOfTrainingServiceId == ID);
        }
         
        public AssessmentOfTrainingServiceEntity GetAOTSE(int ID)
        {
            TrainingContext db = new TrainingContext();
            AssessmentOfTrainingServiceEntity _AssessmentOfTrainingServiceEntity = new AssessmentOfTrainingServiceEntity();
            return
                (
                    from assessmentoftrainingservices in db.AssessmentOfTrainingServices.Where(a => a.AssessmentOfTrainingServiceId == ID)
                    join tableinterfacevaluesTypeOfCompany in db.TableInterfaceValues on assessmentoftrainingservices.TypeOfCompanyId equals tableinterfacevaluesTypeOfCompany.TableInterfaceValueId
                    join tableinterfacevaluesEducation in db.TableInterfaceValues on assessmentoftrainingservices.EducationId equals tableinterfacevaluesEducation.TableInterfaceValueId
                    join tableinterfacevaluesTypeOfInstitution in db.TableInterfaceValues on assessmentoftrainingservices.TypeOfInstitutionId equals tableinterfacevaluesTypeOfInstitution.TableInterfaceValueId
                    select new AssessmentOfTrainingServiceEntity
                    {
                        AssessmentOfTrainingServiceId = assessmentoftrainingservices.AssessmentOfTrainingServiceId,
                        EconomicCode = assessmentoftrainingservices.EconomicCode,
                        EducationId = assessmentoftrainingservices.EducationId,
                        TeacherName = assessmentoftrainingservices.TeacherName,
                        ManagingDirector = assessmentoftrainingservices.ManagingDirector,
                        InstitutionName = assessmentoftrainingservices.InstitutionName,
                        ScopeOfTheActivities = assessmentoftrainingservices.ScopeOfTheActivities,
                        Address = assessmentoftrainingservices.Address,
                        TypeOfCompanyId = assessmentoftrainingservices.TypeOfCompanyId,
                        TypeOfCompanyName = tableinterfacevaluesTypeOfCompany.TableValue,
                        TypeOfInstitutionId = assessmentoftrainingservices.TypeOfInstitutionId,
                        Real = (assessmentoftrainingservices.TypeOfInstitutionId == 242 ? true:false) ,
                        Legal = (assessmentoftrainingservices.TypeOfInstitutionId == 243 ? true : false),
                        TypeOfInstitutionName = tableinterfacevaluesTypeOfInstitution.TableValue,
                        EducationName = tableinterfacevaluesEducation.TableValue,
                    }).SingleOrDefault();
        }

        public IQueryable<AssessmentOfTrainingService> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.AssessmentOfTrainingServices  select item;
        }

        public IQueryable<AssessmentOfTrainingServiceEntity> GetAllAssessmentOfTrainingService()
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from assessmentoftrainingservice in db.AssessmentOfTrainingServices.Where(a => a.Hidden == false)
                 join tableinterfacevalues in db.TableInterfaceValues on assessmentoftrainingservice.EducationId equals tableinterfacevalues.TableInterfaceValueId
                 join tableinterfacevalues1 in db.TableInterfaceValues on assessmentoftrainingservice.TypeOfCompanyId equals tableinterfacevalues1.TableInterfaceValueId

                 select new AssessmentOfTrainingServiceEntity
                 {
                     AssessmentOfTrainingServiceId = assessmentoftrainingservice.AssessmentOfTrainingServiceId,
                     EconomicCode = assessmentoftrainingservice.EconomicCode,
                     EducationId = assessmentoftrainingservice.EducationId,
                     EducationName = tableinterfacevalues.TableValue,
                     TypeOfCompanyId = assessmentoftrainingservice.TypeOfCompanyId,
                     TeacherName = assessmentoftrainingservice.TeacherName,
                     TypeOfCompanyName = tableinterfacevalues1.TableValue,
                     Address = assessmentoftrainingservice.Address,
                     ManagingDirector = assessmentoftrainingservice.ManagingDirector,
                     InstitutionName = assessmentoftrainingservice.InstitutionName,
                     ScopeOfTheActivities = assessmentoftrainingservice.ScopeOfTheActivities
                 });
            return _query;
        }

    }
}
