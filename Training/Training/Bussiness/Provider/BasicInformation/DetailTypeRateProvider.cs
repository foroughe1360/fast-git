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
    public class DetailTypeRateProvider : IDetailTypeRateProvider
    {
        private DetailTypeRateDAC _DetailTypeRateDAC;
        public DetailTypeRateProvider()
        {
            _DetailTypeRateDAC = new DetailTypeRateDAC();
        }
        public int Add(DetailTypeRateEntity Current)
        {
            DetailTypeRate _DetailTypeRate = new DetailTypeRate(Current.TypesRateId,Current.Parent,Current.DetailTypeName,Current.NumDetailType);
            return _DetailTypeRateDAC.Add(_DetailTypeRate);
        }

        public bool Delete(int ID)
        {
            return _DetailTypeRateDAC.Delete(ID);
        }

        public bool Edit(DetailTypeRateEntity Current)
        {
            DetailTypeRate _DetailTypeRate = new DetailTypeRate();
            _DetailTypeRate.DetailTypeRateId= Current.DetailTypeRateId;
            _DetailTypeRate.TimeLastModified = DateTime.Now;
            _DetailTypeRate.TypesRateId= Current.TypesRateId;
            _DetailTypeRate.Parent= Current.Parent;
            _DetailTypeRate.DetailTypeName= Current.DetailTypeName;
            _DetailTypeRate.NumDetailType= Current.NumDetailType;
            return _DetailTypeRateDAC.Edit(_DetailTypeRate);
        }

        public DetailTypeRateEntity Get(int ID)
        {
            DetailTypeRateEntity _DetailTypeRateEntity = new DetailTypeRateEntity();
            var q = _DetailTypeRateDAC.Get(ID);
            _DetailTypeRateEntity.DetailTypeName = q.DetailTypeName;
            _DetailTypeRateEntity.DetailTypeRateId = q.DetailTypeRateId;
            _DetailTypeRateEntity.NumDetailType = q.NumDetailType;
            _DetailTypeRateEntity.Parent = q.Parent;
            _DetailTypeRateEntity.TypesRateId = q.TypesRateId;
            return _DetailTypeRateEntity;
        }

        public IQueryable<DetailTypeRateEntity> GetAll()
        {
            var query = _DetailTypeRateDAC.GetAll();
            return
                (from q in query
                 select new DetailTypeRateEntity
                 {
                     DetailTypeRateId=q.DetailTypeRateId,
                     DetailTypeName=q.DetailTypeName,
                     NumDetailType=q.NumDetailType,
                     Parent=q.Parent,
                     TypesRateId=q.TypesRateId,
                     TypesRateName=q.DetailTypeName
                 });
        }

        public IQueryable<DetailTypeRateEntity> GetAll(int ID)
        {
            return _DetailTypeRateDAC.GetAllDetailTypeRate(ID);
        }
    }
}
