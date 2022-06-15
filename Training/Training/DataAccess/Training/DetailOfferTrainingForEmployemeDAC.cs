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
    public class DetailOfferTrainingForEmployemeDAC : IDetailOfferTrainingForEmployemeRepository
    {
        public int Add(DetailOfferTrainingForEmployeme Current)
        {
            TrainingContext db = new TrainingContext();
            db.DetailOfferTrainingForEmployeme.Add(Current);
            db.SaveChanges();
            return Current.DetailOfferTrainingForEmployemeId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var detailoffertrainingforemployeme = new DetailOfferTrainingForEmployeme() { DetailOfferTrainingForEmployemeId = ID, Hidden = true };
                db.DetailOfferTrainingForEmployeme.Attach(detailoffertrainingforemployeme);
                db.Entry(detailoffertrainingforemployeme).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(DetailOfferTrainingForEmployeme Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DetailOfferTrainingForEmployeme.Attach(Current);

                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.DetailOfferTrainingForEmployemeId).IsModified = true;
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

        public DetailOfferTrainingForEmployeme Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DetailOfferTrainingForEmployeme.SingleOrDefault(x => x.DetailOfferTrainingForEmployemeId == ID);
        }

        public IQueryable<DetailOfferTrainingForEmployeme> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DetailOfferTrainingForEmployeme select item;
        }
         
        public IQueryable<DetailOfferTrainingForEmployemeEntity> GetAllDetailOfferTrainingForEmployeme(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from detailoffertrainingforemployeme in db.DetailOfferTrainingForEmployeme.Where(a => a.Hidden == false && a.OfferTrainingForEmployemesId == ID)
                 join offertrainingforemployemes in db.OfferTrainingForEmployemes on detailoffertrainingforemployeme.OfferTrainingForEmployemesId equals offertrainingforemployemes.OfferTrainingForEmployemeId
                 join tableInterfacevalues in db.TableInterfaceValues on detailoffertrainingforemployeme.PriorityId equals tableInterfacevalues.TableInterfaceValueId

                 join tabletypeoftrainingsoffer in db.TableTypeOfTrainings on detailoffertrainingforemployeme.TableTypeOfTrainingOfferId equals tabletypeoftrainingsoffer.TableTypeOfTrainingId
                 join tabletypeoftrainingsset in db.TableTypeOfTrainings on detailoffertrainingforemployeme.TableTypeOfTrainingSetId equals tabletypeoftrainingsset.TableTypeOfTrainingId


                 select new DetailOfferTrainingForEmployemeEntity
                 {
                     DetailOfferTrainingForEmployemeId = detailoffertrainingforemployeme.DetailOfferTrainingForEmployemeId,
                     NeedTraining = detailoffertrainingforemployeme.NeedTraining,
                     OfferTrainingForEmployemesId = detailoffertrainingforemployeme.OfferTrainingForEmployemesId,
                     PriorityId = detailoffertrainingforemployeme.PriorityId,
                     PriorityName = tableInterfacevalues.TableValue,

                     TableTypeOfTrainingOfferId = detailoffertrainingforemployeme.TableTypeOfTrainingOfferId,
                     TableTypeOfTrainingSetId = detailoffertrainingforemployeme.TableTypeOfTrainingSetId,

                     SD = tabletypeoftrainingsoffer.Sd,
                     OJT = tabletypeoftrainingsoffer.Ojt,
                     C = tabletypeoftrainingsoffer.C,

                     SDSet = tabletypeoftrainingsset.Sd,
                     OJTSet = tabletypeoftrainingsset.Ojt,
                     CSet = tabletypeoftrainingsset.C
                 });
            return _query;
        }

        public IQueryable<DetailOfferTrainingForEmployemeReport> GetDetailOfferTrainingForEmployemeReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from detailoffertrainingforemployeme in db.DetailOfferTrainingForEmployeme.Where(a => a.Hidden == false && a.OfferTrainingForEmployemesId == ID)
                 join offertrainingforemployemes in db.OfferTrainingForEmployemes on detailoffertrainingforemployeme.OfferTrainingForEmployemesId equals offertrainingforemployemes.OfferTrainingForEmployemeId
                 join tableInterfacevalues in db.TableInterfaceValues on detailoffertrainingforemployeme.PriorityId equals tableInterfacevalues.TableInterfaceValueId
                 join tabletypeoftrainingsoffer in db.TableTypeOfTrainings on detailoffertrainingforemployeme.TableTypeOfTrainingOfferId equals tabletypeoftrainingsoffer.TableTypeOfTrainingId
                 join tabletypeoftrainingsset in db.TableTypeOfTrainings on detailoffertrainingforemployeme.TableTypeOfTrainingSetId equals tabletypeoftrainingsset.TableTypeOfTrainingId


                 select new DetailOfferTrainingForEmployemeReport
                 {
                     NeedTraining = detailoffertrainingforemployeme.NeedTraining,
                     SuggestedSD = tabletypeoftrainingsoffer.Sd,
                     SuggestedOJT = tabletypeoftrainingsoffer.Ojt,
                     SuggestedC = tabletypeoftrainingsoffer.C,

                     ApprovalSD = tabletypeoftrainingsset.Sd,
                     ApprovalOJT = tabletypeoftrainingsset.Ojt,
                     ApprovalC = tabletypeoftrainingsset.C,
                     Priority = tableInterfacevalues.TableValue,
                     PN1 = (detailoffertrainingforemployeme.PriorityId == (int)DetailOfferTrainingForJobEntity.DetailOfferTrainingForJob.pN1 ? true : false),
                     PN2 = (detailoffertrainingforemployeme.PriorityId == (int)DetailOfferTrainingForJobEntity.DetailOfferTrainingForJob.pN2 ? true : false),
                     PN3 = (detailoffertrainingforemployeme.PriorityId == (int)DetailOfferTrainingForJobEntity.DetailOfferTrainingForJob.pN3 ? true : false),
                 });
            return _query;
        }


    }
}
