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
    public class OfferTrainingForJobProvider : IOfferTrainingForJobProvider
    {
        private OfferTrainingForJobDAC _OfferTrainingForJobDAC;
        public OfferTrainingForJobProvider()
        {
            _OfferTrainingForJobDAC = new OfferTrainingForJobDAC();
        }

        public int Add(OfferTrainingForJobEntity Current)
        {
            General _General = new General();
            Current.DateNeeds = _General.ShamsiToMiladi(Current.DateNeeds);
            OfferTrainingForJob _OfferTrainingForJob = new OfferTrainingForJob(Current.OfferTrainingForJobDateId,Current.SectionId, Current.PostGroupId, Current.DateNeeds);
            return _OfferTrainingForJobDAC.Add(_OfferTrainingForJob);
        }

        public bool Delete(int ID)
        {
            return _OfferTrainingForJobDAC.Delete(ID);
        }

        public bool Edit(OfferTrainingForJobEntity Current)
        {
            General _General = new General();
            OfferTrainingForJob _OfferTrainingForJob = new OfferTrainingForJob();
            _OfferTrainingForJob.OfferTrainingForJobId = Current.OfferTrainingForJobId;
            _OfferTrainingForJob.TimeLastModified = DateTime.Now;
            _OfferTrainingForJob.SectionId = Current.SectionId;
            _OfferTrainingForJob.PostGroupId = Current.PostGroupId;
            _OfferTrainingForJob.DateNeeds = _General.ShamsiToMiladi(Current.DateNeeds);

            return _OfferTrainingForJobDAC.Edit(_OfferTrainingForJob);
        }

        public OfferTrainingForJobEntity Get(int ID)
        {
            OfferTrainingForJobEntity _OfferTrainingForJobEntity = new OfferTrainingForJobEntity();
            return _OfferTrainingForJobDAC.GetOfferTrainingForJob(ID);

        }

        public PostReport GetPostReport(int ID)
        {
            return _OfferTrainingForJobDAC.GetPostReport(ID);

        }

        public IQueryable<OfferTrainingForJobEntity> GetAll()
        {
            return _OfferTrainingForJobDAC.GetAllOfferTrainingForJob();
        }

        public IQueryable<OfferTrainingForJobEntity> GetAll(int ID)
        {
            return _OfferTrainingForJobDAC.GetAllOfferTrainingForJob(ID);
        }

        

    }
}
