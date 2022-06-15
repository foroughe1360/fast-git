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
    public class NumberSucceedProvider : INumberSucceedProvider
    {
        private NumberSucceedDAC _NumberSucceedDAC;

        public NumberSucceedProvider()
        {
            _NumberSucceedDAC = new NumberSucceedDAC();
        }

        public int Add(NumberSucceedEntity Current)
        {
            General _General = new General();
            Current.NumberSucceedDate = _General.ShamsiToMiladi(Current.NumberSucceedDateStr);
            NumberSucceed _NumberSucceed = new NumberSucceed(Current.Number,Current.NumberSucceedDate);
            return _NumberSucceedDAC.Add(_NumberSucceed);
        }

        public bool Delete(int ID)
        {
            return _NumberSucceedDAC.Delete(ID);
        }

        public bool Edit(NumberSucceedEntity Current)
        {
            General _General = new General();
            NumberSucceed _NumberSucceed = new NumberSucceed();
            _NumberSucceed.NumberSucceedId = Current.NumberSucceedId;
            _NumberSucceed.TimeLastModified = DateTime.Now;
            _NumberSucceed. Number = Current.Number;
            _NumberSucceed.NumberSucceedDate = _General.ShamsiToMiladi(Current.NumberSucceedDateStr);
            return _NumberSucceedDAC.Edit(_NumberSucceed);
        }

        public NumberSucceedEntity Get(int ID)
        {
            NumberSucceedEntity _NumberSucceedEntity = new NumberSucceedEntity();
            var q = _NumberSucceedDAC.Get(ID);
            _NumberSucceedEntity.NumberSucceedId = q.NumberSucceedId;
            _NumberSucceedEntity.Number = q.Number;
            _NumberSucceedEntity.NumberSucceedDate = q.NumberSucceedDate;
            return _NumberSucceedEntity;
        }

        public IQueryable<NumberSucceedEntity> GetAll()
        {
            var query = _NumberSucceedDAC.GetAll();
            return
                (from q in query
                 select new NumberSucceedEntity
                 {
                     NumberSucceedId = q.NumberSucceedId,
                     Number = q.Number,
                     NumberSucceedDate = q.NumberSucceedDate
                 });
        }
    }
}
