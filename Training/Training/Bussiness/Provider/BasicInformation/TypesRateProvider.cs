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
    public class TypesRateProvider : ITypesRateProvider
    {
        private TypesRateDAC _TypesRateDAC;
        public TypesRateProvider()
        {
            _TypesRateDAC = new TypesRateDAC();
        }
        public int Add(TypesRateEntity Current)
        {
            TypesRate _TypesRate = new TypesRate(Current.RateName,Current.NumberRate);
            return _TypesRateDAC.Add(_TypesRate);
        }
        public bool Delete(int ID)
        {
            return _TypesRateDAC.Delete(ID);
        }
        public bool Edit(TypesRateEntity Current)
        {
            TypesRate _TypesRate = new TypesRate();
            _TypesRate.TypesRateId=Current.TypesRateId;
            _TypesRate.TimeLastModified = DateTime.Now;
            _TypesRate.RateName=Current.RateName;
            _TypesRate.NumberRate=Current.NumberRate;
            return _TypesRateDAC.Edit(_TypesRate);
        }
        public TypesRateEntity Get(int ID)
        {
            TypesRateEntity _TypesRateEntity = new TypesRateEntity();
            var q = _TypesRateDAC.Get(ID);
            _TypesRateEntity.NumberRate = q.NumberRate;
            _TypesRateEntity.RateName = q.RateName;
            _TypesRateEntity.TypesRateId = q.TypesRateId;
            return _TypesRateEntity;
        }
        public IQueryable<TypesRateEntity> GetAll()
        {
            var query = _TypesRateDAC.GetAll();
            var _query = (from q in query.Where(a => a.Hidden == false)
                          select new TypesRateEntity
                          {
                              NumberRate = q.NumberRate,
                              RateName = q.RateName,
                              TypesRateId = q.TypesRateId
                          });
            return _query;
        }
    }
}
