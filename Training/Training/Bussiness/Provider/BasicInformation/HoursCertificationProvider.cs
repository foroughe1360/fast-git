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
    public class HoursCertificationProvider : IHoursCertificationProvider
    {
        private HoursCertificationDAC _HoursCertificationDAC;

        public HoursCertificationProvider()
        {
            _HoursCertificationDAC = new HoursCertificationDAC();
        }

        public int Add(HoursCertificationEntity Current)
        {
            General _General = new General();
            Current.HoursCertificationDate = _General.ShamsiToMiladi(Current.HoursCertificationDateStr);
            HoursCertification _HoursCertification = new HoursCertification(Current.TimePeriod,Current.HoursCertificationDate);
            return _HoursCertificationDAC.Add(_HoursCertification);

        }

        public bool Delete(int ID)
        {
            return _HoursCertificationDAC.Delete(ID);
        }

        public bool Edit(HoursCertificationEntity Current)
        {
            General _General = new General();
            HoursCertification _HoursCertification = new HoursCertification();
            _HoursCertification.HoursCertificationId = Current.HoursCertificationId;
            _HoursCertification.TimeLastModified = DateTime.Now;
            _HoursCertification.TimePeriod = Current.TimePeriod;
            _HoursCertification.HoursCertificationDate = _General.ShamsiToMiladi(Current.HoursCertificationDateStr);
            return _HoursCertificationDAC.Edit(_HoursCertification);
        }

        public HoursCertificationEntity Get(int ID)
        {
            HoursCertificationEntity _HoursCertificationEntity = new HoursCertificationEntity();
            var q = _HoursCertificationDAC.Get(ID);
            _HoursCertificationEntity.HoursCertificationId = q.HoursCertificationId;
            _HoursCertificationEntity.TimePeriod = q.TimePeriod;
            _HoursCertificationEntity.HoursCertificationDate = q.HoursCertificationDate;
            return _HoursCertificationEntity;
        }

        public IQueryable<HoursCertificationEntity> GetAll()
        {
            var query= _HoursCertificationDAC.GetAll();
            return
                (from q in query
                 select new HoursCertificationEntity
                 {
                     HoursCertificationId=q.HoursCertificationId,
                     TimePeriod=q.TimePeriod,
                     HoursCertificationDate=q.HoursCertificationDate
                 });
        }
    }
}
