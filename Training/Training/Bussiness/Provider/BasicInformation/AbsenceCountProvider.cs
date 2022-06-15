using Bussiness.InfraStructre.BasicInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess.BasicInformation;
using DomainModel.Models;

namespace Bussiness
{
    public class AbsenceCountProvider : IAbsenceCountProvider
    {
        private AbsenceCountDAC _AbsenceCountDAC;
        public AbsenceCountProvider()
        {
            _AbsenceCountDAC = new AbsenceCountDAC();
        }
        public int Add(AbsenceCountEntity Current)
        {
            General _General = new General();
            Current.AbsenceCountDate = _General.ShamsiToMiladi(Current.AbsenceCountDateStr);
            AbsenceCount _AbsenceCount = new AbsenceCount(Current.MaxAbsenceCount, Current.AbsenceCountDate);
            return _AbsenceCountDAC.Add(_AbsenceCount);
        }

        public bool Delete(int ID)
        {
            return _AbsenceCountDAC.Delete(ID);
        }

        public bool Edit(AbsenceCountEntity Current)
        {
            General _General = new General();
            AbsenceCount _AbsenceCount = new AbsenceCount();
            _AbsenceCount.AbsenceCountId = Current.AbsenceCountId;
            _AbsenceCount.TimeLastModified = DateTime.Now;
            _AbsenceCount.MaxAbsenceCount = Current.MaxAbsenceCount;
            _AbsenceCount.AbsenceCountDate = _General.ShamsiToMiladi(Current.AbsenceCountDateStr);
            return _AbsenceCountDAC.Edit(_AbsenceCount);
        }

        public AbsenceCountEntity Get(int ID)
        {
            AbsenceCountEntity _AbsenceCountEntity = new AbsenceCountEntity();
            var q = _AbsenceCountDAC.Get(ID);
            _AbsenceCountEntity.AbsenceCountId = q.AbsenceCountId;
            _AbsenceCountEntity.MaxAbsenceCount = q.MaxAbsenceCount;
            _AbsenceCountEntity.AbsenceCountDate = q.AbsenceCountDate;
            return _AbsenceCountEntity;
        }

        public IQueryable<AbsenceCountEntity> GetAll()
        {
            var query = _AbsenceCountDAC.GetAll();
            return
                (from q in query
                 select new AbsenceCountEntity
                 {
                     AbsenceCountId = q.AbsenceCountId,
                     MaxAbsenceCount = q.MaxAbsenceCount,
                     AbsenceCountDate = q.AbsenceCountDate
                 });
        }
    }
}
