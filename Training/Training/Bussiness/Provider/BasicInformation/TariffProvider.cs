using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class TariffProvider : ITariffProvider
    {
        private TariffDAC _TariffDAC;
        public TariffProvider()
        {
            _TariffDAC = new TariffDAC();
        }
        public int Add(TariffEntity Current)
        {
            General _General = new General();
            Current.TariffDate = _General.ShamsiToMiladi(Current.TariffDateStr);

            Tariff _Tariff = new Tariff(Current.Cost,Current.CourseTypeId,Current.TariffDate);
            return _TariffDAC.Add(_Tariff);
        }
        public bool Delete(int ID)
        {
            return _TariffDAC.Delete(ID);
        }
        public bool Edit(TariffEntity Current)
        {
            General _General = new General();
            Tariff _Tariff = new Tariff();
            _Tariff.TariffId = Current.TariffId;
            _Tariff.TimeLastModified = DateTime.Now;
            _Tariff.Cost = Current.Cost;
            _Tariff.CourseTypeId = Current.CourseTypeId;
            _Tariff.TariffDate = _General.ShamsiToMiladi(Current.TariffDateStr);
            return _TariffDAC.Edit(_Tariff);
        }
        public TariffEntity Get(int ID)
        {
            TariffEntity _TariffEntity = new TariffEntity();
            var q = _TariffDAC.Get(ID);
            _TariffEntity.TariffId = q.TariffId;
            _TariffEntity.Cost = q.Cost;
            _TariffEntity.CourseTypeId = q.CourseTypeId;
            _TariffEntity.TariffDate = q.TariffDate;
            return _TariffEntity;
            //return (TariffEntity)_TariffDAC.Get(ID);
        }
        public IQueryable<TariffEntity> GetAll()
        {
            return _TariffDAC.GetAllTariff();
        }
    }
}
