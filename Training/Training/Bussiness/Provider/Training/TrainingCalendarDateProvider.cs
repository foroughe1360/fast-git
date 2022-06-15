using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess.Training;
using DomainModel.Models;

namespace Bussiness.Provider.Training
{
    public class TrainingCalendarDateProvider : ITrainingCalendarDateProvider
    {
        private TrainingCalendarDateDAC _TrainingCalendarDateDAC;

        public TrainingCalendarDateProvider()
        {
            _TrainingCalendarDateDAC = new TrainingCalendarDateDAC();
        }

        public int Add(TrainingCalendarDateEntity Current)
        {
            General _General = new General();
            Current.TrCalendarDate = _General.ShamsiToMiladi(Current.TrCalendarDateStr);
            TrainingCalendarDate _TrainingCalendarDate = new TrainingCalendarDate(Current.Description, Current.TrCalendarDate);
            return _TrainingCalendarDateDAC.Add(_TrainingCalendarDate);
        }

        public bool Delete(int ID)
        {
            return _TrainingCalendarDateDAC.Delete(ID);
        }

        public bool Edit(TrainingCalendarDateEntity Current)
        {
            General _General = new General();
            TrainingCalendarDate _TrainingCalendarDate = new TrainingCalendarDate();
            _TrainingCalendarDate.TrainingCalendarDateId = Current.TrainingCalendarDateId;
            _TrainingCalendarDate.TimeLastModified = DateTime.Now;
            _TrainingCalendarDate.Description = Current.Description;
            _TrainingCalendarDate.TrCalendarDate = _General.ShamsiToMiladi(Current.TrCalendarDateStr);
            return _TrainingCalendarDateDAC.Edit(_TrainingCalendarDate);
        }

        public TrainingCalendarDateEntity Get(int ID)
        {
            TrainingCalendarDateEntity _TrainingCalendarDateEntity = new TrainingCalendarDateEntity();
            var q = _TrainingCalendarDateDAC.Get(ID);
            _TrainingCalendarDateEntity.TrainingCalendarDateId = q.TrainingCalendarDateId;
            _TrainingCalendarDateEntity.Description = q.Description;
            _TrainingCalendarDateEntity.TrCalendarDate = q.TrCalendarDate;
            return _TrainingCalendarDateEntity;
        }

        public IQueryable<TrainingCalendarDateEntity> GetAll()
        {
            return _TrainingCalendarDateDAC.GetAllTrainingCalendarDate();
        }
    }
}
