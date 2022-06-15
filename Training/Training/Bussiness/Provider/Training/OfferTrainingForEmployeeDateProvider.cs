using Bussiness.InfraStructre;
using DataAccess.Training;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Provider
{
    public class OfferTrainingForEmployeeDateProvider : IOfferTrainingForEmployeeDateProvider
    {
        private OfferTrainingForEmployeeDateDAC _OfferTrainingForEmployeeDateDAC;
        public OfferTrainingForEmployeeDateProvider()
        {
            _OfferTrainingForEmployeeDateDAC = new OfferTrainingForEmployeeDateDAC();
        }
        public int Add(OfferTrainingForEmployeeDateEntity Current)
        {
            General _General = new General();
            Current.OTFJDate = _General.ShamsiToMiladi(Current.OTFJDateStr);
            OfferTrainingForEmployeeDate _OfferTrainingForEmployeeDate = new OfferTrainingForEmployeeDate(Current.Description, Current.OTFJDate);
            return _OfferTrainingForEmployeeDateDAC.Add(_OfferTrainingForEmployeeDate);
        }

        public bool Delete(int ID)
        {
            return _OfferTrainingForEmployeeDateDAC.Delete(ID);
        }

        public bool Edit(OfferTrainingForEmployeeDateEntity Current)
        {
            General _General = new General();
            OfferTrainingForEmployeeDate _OfferTrainingForEmployeeDate = new OfferTrainingForEmployeeDate();
            _OfferTrainingForEmployeeDate.OfferTrainingForEmployeeDateId = Current.OfferTrainingForEmployeeDateId;
            _OfferTrainingForEmployeeDate.TimeLastModified = DateTime.Now;
            _OfferTrainingForEmployeeDate.Description = Current.Description;
            _OfferTrainingForEmployeeDate.OTFJDate = _General.ShamsiToMiladi(Current.OTFJDateStr);
            return _OfferTrainingForEmployeeDateDAC.Edit(_OfferTrainingForEmployeeDate);
        }

        public OfferTrainingForEmployeeDateEntity Get(int ID)
        {
            OfferTrainingForEmployeeDateEntity _OfferTrainingForEmployeeDateEntity = new OfferTrainingForEmployeeDateEntity();
            var q = _OfferTrainingForEmployeeDateDAC.Get(ID);
            _OfferTrainingForEmployeeDateEntity.OfferTrainingForEmployeeDateId = q.OfferTrainingForEmployeeDateId;
            _OfferTrainingForEmployeeDateEntity.Description = q.Description;
            _OfferTrainingForEmployeeDateEntity.OTFJDate = q.OTFJDate;
            return _OfferTrainingForEmployeeDateEntity;
        }

        public IQueryable<OfferTrainingForEmployeeDateEntity> GetAll()
        {
            return _OfferTrainingForEmployeeDateDAC.GetAllOfferTrainingForEmployeeDate();
        }

        public OfferTrainingForEmployeeDateEntity Get(int ID , int OfferTrainingForEmployeeDateId)
        {
            OfferTrainingForEmployeeDateEntity _OfferTrainingForEmployeeDateEntity = new OfferTrainingForEmployeeDateEntity();
            var q = _OfferTrainingForEmployeeDateDAC.Get(ID);
            _OfferTrainingForEmployeeDateEntity.OfferTrainingForEmployeeDateId = q.OfferTrainingForEmployeeDateId;
            _OfferTrainingForEmployeeDateEntity.Description = q.Description;
            _OfferTrainingForEmployeeDateEntity.OTFJDate = q.OTFJDate;
            return _OfferTrainingForEmployeeDateEntity;
        }

    }
}
