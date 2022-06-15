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
    public class MasterRateItProvider : IMasterRateItProvider
    {
        private MasterRateItDAC _MasterRateItDAC;
        public MasterRateItProvider()
        {
            _MasterRateItDAC = new MasterRateItDAC();
        }
        public int Add(MasterRateItEntity Current)
        {
            MasterRateIt _MasterRateIt = new MasterRateIt(Current.TypesRateItId,Current.Name,Current.MinRating,Current.MaxRating,Current.Parent);
            return _MasterRateItDAC.Add(_MasterRateIt);
        }
        public bool Delete(int ID)
        {
            return _MasterRateItDAC.Delete(ID);
        }
        public bool Edit(MasterRateItEntity Current)
        {
            MasterRateIt _MasterRateIt = new MasterRateIt();
            _MasterRateIt.MasterRateItId = Current.MasterRateItId;
            _MasterRateIt.TimeLastModified= DateTime.Now;
            _MasterRateIt.TypesRateItId = Current.TypesRateItId;
            _MasterRateIt.Name = Current.Name;
            _MasterRateIt.MinRating = Current.MinRating;
            _MasterRateIt.MaxRating = Current.MaxRating;
            _MasterRateIt.Parent = Current.Parent; 
            return _MasterRateItDAC.Edit(_MasterRateIt);
        }
        public MasterRateItEntity Get(int ID)
        {
            MasterRateItEntity _MasterRateItEntity = new MasterRateItEntity();
            var q = _MasterRateItDAC.Get(ID);
            _MasterRateItEntity.MasterRateItId = q.MasterRateItId;
            _MasterRateItEntity.Name = q.Name;
            _MasterRateItEntity.MinRating = q.MinRating;
            _MasterRateItEntity.MaxRating = q.MaxRating;
            _MasterRateItEntity.Parent = q.Parent;
            _MasterRateItEntity.TypesRateItId = q.TypesRateItId;
            return _MasterRateItEntity;
        }
        public IQueryable<MasterRateItEntity> GetAll()
        {
            return _MasterRateItDAC.GetAllMasterRateIt();
        }
    }
}
