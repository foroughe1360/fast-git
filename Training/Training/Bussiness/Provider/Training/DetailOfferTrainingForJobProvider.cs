using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;

namespace Bussiness
{
    public class DetailOfferTrainingForJobProvider : IDetailOfferTrainingForJobProvider
    {
        private DetailOfferTrainingForJobDAC _DetailOfferTrainingForJobDAC;
        public DetailOfferTrainingForJobProvider()
        {
            _DetailOfferTrainingForJobDAC = new DetailOfferTrainingForJobDAC();
        }
        public int Add(DetailOfferTrainingForJobEntity Current)
        {
            DetailOfferTrainingForJob _DetailOfferTrainingForJob = new DetailOfferTrainingForJob(Current.OfferTrainingForJobsId, Current.NeedTraining, Current.PriorityId, Current.TableTypeOfTrainingOfferId, Current.TableTypeOfTrainingSetId);
            return _DetailOfferTrainingForJobDAC.Add(_DetailOfferTrainingForJob);
        }

        public bool Delete(int ID)
        {
            return _DetailOfferTrainingForJobDAC.Delete(ID);
        }

        public bool Edit(DetailOfferTrainingForJobEntity Current)
        {
            DetailOfferTrainingForJob _DetailOfferTrainingForJob = new DetailOfferTrainingForJob();
            _DetailOfferTrainingForJob.DetailOfferTrainingForJobId = Current.DetailOfferTrainingForJobId;
            _DetailOfferTrainingForJob.TimeLastModified = DateTime.Now;
            _DetailOfferTrainingForJob.NeedTraining = Current.NeedTraining;
            _DetailOfferTrainingForJob.OfferTrainingForJobsId = Current.OfferTrainingForJobsId;
            _DetailOfferTrainingForJob.PriorityId = Current.PriorityId;
            _DetailOfferTrainingForJob.TableTypeOfTrainingOfferId = Current.TableTypeOfTrainingOfferId;
            _DetailOfferTrainingForJob.TableTypeOfTrainingSetId = Current.TableTypeOfTrainingSetId;

            return _DetailOfferTrainingForJobDAC.Edit(_DetailOfferTrainingForJob);
        }

        public DetailOfferTrainingForJobEntity Get(int ID)
        {
            DetailOfferTrainingForJobEntity _DetailOfferTrainingForJobEntity = new DetailOfferTrainingForJobEntity();
            var q = _DetailOfferTrainingForJobDAC.Get(ID);
            _DetailOfferTrainingForJobEntity.DetailOfferTrainingForJobId = q.DetailOfferTrainingForJobId;
            _DetailOfferTrainingForJobEntity.NeedTraining = q.NeedTraining;
            _DetailOfferTrainingForJobEntity.OfferTrainingForJobsId = q.OfferTrainingForJobsId;
            _DetailOfferTrainingForJobEntity.PriorityId = q.PriorityId;
            _DetailOfferTrainingForJobEntity.TableTypeOfTrainingOfferId = q.TableTypeOfTrainingOfferId;
            _DetailOfferTrainingForJobEntity.TableTypeOfTrainingSetId = q.TableTypeOfTrainingSetId;
            return _DetailOfferTrainingForJobEntity;
        }

        public IQueryable<DetailOfferTrainingForJobEntity> GetAll()
        {
            return (IQueryable<DetailOfferTrainingForJobEntity>)_DetailOfferTrainingForJobDAC.GetAll();
        }

        public IQueryable<DetailOfferTrainingForJobEntity> GetAll(int ID)
        {
            return _DetailOfferTrainingForJobDAC.GetAllDetailOfferTrainingForJob(ID);
        }

        public IQueryable<DetailOfferTrainingForJobReport> GetDetailOfferTrainingForJobReport(int ID)
        {
            return _DetailOfferTrainingForJobDAC.GetDetailOfferTrainingForJobReport(ID);

        }
    }
}
