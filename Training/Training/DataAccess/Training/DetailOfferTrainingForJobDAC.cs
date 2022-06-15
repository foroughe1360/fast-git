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
    public class DetailOfferTrainingForJobDAC : IDetailOfferTrainingForJobRepository
    {
        public int Add(DetailOfferTrainingForJob Current)
        {
            TrainingContext db = new TrainingContext();
            db.DetailOfferTrainingForJobs.Add(Current);
            db.SaveChanges();
            return Current.DetailOfferTrainingForJobId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var detailOfferTrainingForJob = new DetailOfferTrainingForJob() { DetailOfferTrainingForJobId = ID, Hidden = true };
                db.DetailOfferTrainingForJobs.Attach(detailOfferTrainingForJob);
                db.Entry(detailOfferTrainingForJob).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(DetailOfferTrainingForJob Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DetailOfferTrainingForJobs.Attach(Current);

                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.OfferTrainingForJobsId).IsModified = true;
                db.Entry(Current).Property(x => x.NeedTraining).IsModified = true;
                db.Entry(Current).Property(x => x.PriorityId).IsModified = true;
                db.Entry(Current).Property(x => x.TableTypeOfTrainingOfferId).IsModified = true;
                db.Entry(Current).Property(x => x.TableTypeOfTrainingSetId).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
        public DetailOfferTrainingForJob Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DetailOfferTrainingForJobs.SingleOrDefault(x => x.DetailOfferTrainingForJobId == ID);
        }

       
        public IQueryable<DetailOfferTrainingForJob> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DetailOfferTrainingForJobs select item;
        }
        public IQueryable<DetailOfferTrainingForJobEntity> GetAllDetailOfferTrainingForJob(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from detailoffertrainingforjob in db.DetailOfferTrainingForJobs.Where(a => a.Hidden == false && a.OfferTrainingForJobsId == ID)
                 join offertrainingforjobs in db.OfferTrainingForJobs on detailoffertrainingforjob.OfferTrainingForJobsId equals offertrainingforjobs.OfferTrainingForJobId
                 join tableInterfacevalues in db.TableInterfaceValues on detailoffertrainingforjob.PriorityId equals tableInterfacevalues.TableInterfaceValueId

                 join tabletypeoftrainingsoffer in db.TableTypeOfTrainings on detailoffertrainingforjob.TableTypeOfTrainingOfferId equals tabletypeoftrainingsoffer.TableTypeOfTrainingId
                 join tabletypeoftrainingsset in db.TableTypeOfTrainings on detailoffertrainingforjob.TableTypeOfTrainingSetId equals tabletypeoftrainingsset.TableTypeOfTrainingId


                 select new DetailOfferTrainingForJobEntity
                 {
                     DetailOfferTrainingForJobId = detailoffertrainingforjob.DetailOfferTrainingForJobId,
                     NeedTraining = detailoffertrainingforjob.NeedTraining,
                     OfferTrainingForJobsId = detailoffertrainingforjob.OfferTrainingForJobsId,
                     PriorityId = detailoffertrainingforjob.PriorityId,
                     PriorityName = tableInterfacevalues.TableValue,

                     TableTypeOfTrainingOfferId = detailoffertrainingforjob.TableTypeOfTrainingOfferId,
                     TableTypeOfTrainingSetId = detailoffertrainingforjob.TableTypeOfTrainingSetId,

                     SD = tabletypeoftrainingsoffer.Sd,
                     OJT = tabletypeoftrainingsoffer.Ojt,
                     C = tabletypeoftrainingsoffer.C,

                     SDSet = tabletypeoftrainingsset.Sd,
                     OJTSet = tabletypeoftrainingsset.Ojt,
                     CSet = tabletypeoftrainingsset.C
                 });
            return _query;
        }
        public IQueryable<DetailOfferTrainingForJobReport> GetDetailOfferTrainingForJobReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from detailoffertrainingforjob in db.DetailOfferTrainingForJobs.Where(a => a.Hidden == false && a.OfferTrainingForJobsId == ID)
                 join offertrainingforjobs in db.OfferTrainingForJobs on detailoffertrainingforjob.OfferTrainingForJobsId equals offertrainingforjobs.OfferTrainingForJobId
                 join tableInterfacevalues in db.TableInterfaceValues on detailoffertrainingforjob.PriorityId equals tableInterfacevalues.TableInterfaceValueId
                 join tabletypeoftrainingsoffer in db.TableTypeOfTrainings on detailoffertrainingforjob.TableTypeOfTrainingOfferId equals tabletypeoftrainingsoffer.TableTypeOfTrainingId
                 join tabletypeoftrainingsset in db.TableTypeOfTrainings on detailoffertrainingforjob.TableTypeOfTrainingSetId equals tabletypeoftrainingsset.TableTypeOfTrainingId


                 select new DetailOfferTrainingForJobReport
                 {
                     NeedTraining = detailoffertrainingforjob.NeedTraining,
                     SuggestedSD = tabletypeoftrainingsoffer.Sd,
                     SuggestedOJT = tabletypeoftrainingsoffer.Ojt,
                     SuggestedC = tabletypeoftrainingsoffer.C,

                     ApprovalSD = tabletypeoftrainingsset.Sd,
                     ApprovalOJT = tabletypeoftrainingsset.Ojt,
                     ApprovalC = tabletypeoftrainingsset.C,
                     Priority = tableInterfacevalues.TableValue,
                     PN1 = (detailoffertrainingforjob.PriorityId == (int)DetailOfferTrainingForJobEntity.DetailOfferTrainingForJob.pN1 ? true : false),
                     PN2 = (detailoffertrainingforjob.PriorityId == (int)DetailOfferTrainingForJobEntity.DetailOfferTrainingForJob.pN2 ? true : false),
                     PN3 = (detailoffertrainingforjob.PriorityId == (int)DetailOfferTrainingForJobEntity.DetailOfferTrainingForJob.pN3 ? true : false),
                 });
            return _query;
        }
    }
}
