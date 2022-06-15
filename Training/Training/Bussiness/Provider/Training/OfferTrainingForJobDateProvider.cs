using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess.Training;
using DomainModel.Models;

namespace Bussiness.Provider
{
    public class OfferTrainingForJobDateProvider : IOfferTrainingForJobDateProvider
    {
        private OfferTrainingForJobDateDAC _OfferTrainingForJobDateDAC;

        public OfferTrainingForJobDateProvider()
        {
            _OfferTrainingForJobDateDAC = new OfferTrainingForJobDateDAC();
        }

        public int Add(OfferTrainingForJobDateEntity Current)
        {
            General _General = new General();
            Current.OTFJDate = _General.ShamsiToMiladi(Current.OTFJDateStr);
            OfferTrainingForJobDate _OfferTrainingForJobDate = new OfferTrainingForJobDate(Current.Description, Current.OTFJDate);
            return _OfferTrainingForJobDateDAC.Add(_OfferTrainingForJobDate);
        }

        public bool Delete(int ID)
        {
            return _OfferTrainingForJobDateDAC.Delete(ID);
        }

        public bool Edit(OfferTrainingForJobDateEntity Current)
        {
            General _General = new General();
            OfferTrainingForJobDate _OfferTrainingForJobDate = new OfferTrainingForJobDate();
            _OfferTrainingForJobDate.OfferTrainingForJobDateId = Current.OfferTrainingForJobDateId;
            _OfferTrainingForJobDate.TimeLastModified = DateTime.Now;
            _OfferTrainingForJobDate.Description = Current.Description;
            _OfferTrainingForJobDate.OTFJDate = _General.ShamsiToMiladi(Current.OTFJDateStr);
            return _OfferTrainingForJobDateDAC.Edit(_OfferTrainingForJobDate);
        }

        public OfferTrainingForJobDateEntity Get(int ID)
        {
            OfferTrainingForJobDateEntity _OfferTrainingForJobDateEntity = new OfferTrainingForJobDateEntity();
            var q = _OfferTrainingForJobDateDAC.Get(ID);
            _OfferTrainingForJobDateEntity.OfferTrainingForJobDateId = q.OfferTrainingForJobDateId;
            _OfferTrainingForJobDateEntity.Description = q.Description;
            _OfferTrainingForJobDateEntity.OTFJDate = q.OTFJDate;
            return _OfferTrainingForJobDateEntity;
        }

        public IQueryable<OfferTrainingForJobDateEntity> GetAll()
        {
            return _OfferTrainingForJobDateDAC.GetAllOfferTrainingForJobDate();
        }
    }
}
