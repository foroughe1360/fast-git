using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;

namespace Bussiness
{
    public class PlacementTabJobTrainingDateProvider : IPlacementTabJobTrainingDateProvider
    {
        private PlacementTabJobTrainingDateDAC _PlacementTabJobTrainingDateDAC;

        public PlacementTabJobTrainingDateProvider()
        {
            _PlacementTabJobTrainingDateDAC = new PlacementTabJobTrainingDateDAC();
        }

        public int Add(PlacementTabJobTrainingDateEntity Current)
        {
            General _General = new General();
            Current.PTJTDate = _General.ShamsiToMiladi(Current.PTJTDatetStr);
            PlacementTabJobTrainingDate _PlacementTabJobTrainingDate = new PlacementTabJobTrainingDate(Current.Description, Current.PTJTDate);
            return _PlacementTabJobTrainingDateDAC.Add(_PlacementTabJobTrainingDate);
        }

        public bool Delete(int ID)
        {
            return _PlacementTabJobTrainingDateDAC.Delete(ID);
        }

        public bool Edit(PlacementTabJobTrainingDateEntity Current)
        {
            General _General = new General();
            PlacementTabJobTrainingDate _PlacementTabJobTrainingDate = new PlacementTabJobTrainingDate();
            _PlacementTabJobTrainingDate.PlacementTabJobTrainingDateId = Current.PlacementTabJobTrainingDateId;
            _PlacementTabJobTrainingDate.TimeLastModified = DateTime.Now;
            _PlacementTabJobTrainingDate.Description = Current.Description;
            _PlacementTabJobTrainingDate.PTJTDate = _General.ShamsiToMiladi(Current.PTJTDatetStr);
            return _PlacementTabJobTrainingDateDAC.Edit(_PlacementTabJobTrainingDate);
        }

        public PlacementTabJobTrainingDateEntity Get(int ID)
        {
            PlacementTabJobTrainingDateEntity _PlacementTabJobTrainingDateEntity = new PlacementTabJobTrainingDateEntity();
            var q = _PlacementTabJobTrainingDateDAC.Get(ID);
            _PlacementTabJobTrainingDateEntity.PlacementTabJobTrainingDateId = q.PlacementTabJobTrainingDateId;
            _PlacementTabJobTrainingDateEntity.Description = q.Description;
            _PlacementTabJobTrainingDateEntity.PTJTDate = q.PTJTDate;
            return _PlacementTabJobTrainingDateEntity;
        }

        public IQueryable<PlacementTabJobTrainingDateEntity> GetAll()
        {
            return _PlacementTabJobTrainingDateDAC.GetAllPlacementTabJobTrainingDate();
        }
    }
}
