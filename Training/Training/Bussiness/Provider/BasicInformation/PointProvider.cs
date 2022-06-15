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
    public class PointProvider : IPointProvider
    {
        private PointDAC _PointDAC;
        public PointProvider()
        {
            _PointDAC = new PointDAC();
        }
        public int Add(PointEntity Current)
        {
            Point _Point = new Point(Current.DetailTypeRateId,Current.PointName,Current.NumPoint);
            return _PointDAC.Add(_Point);
        }
        public bool Delete(int ID)
        {
            return _PointDAC.Delete(ID);
        }
        public bool Edit(PointEntity Current)
        {
            Point _Point = new Point();
            _Point.PointId=Current.PointId;
            _Point.TimeLastModified = DateTime.Now;
            _Point.DetailTypeRateId=Current.DetailTypeRateId;
            _Point.PointName=Current.PointName;
            _Point.NumPoint=Current.NumPoint;

            return _PointDAC.Edit(_Point);
        }
        public PointEntity Get(int ID)
        {
            PointEntity _PointEntity = new PointEntity();
            var q = _PointDAC.Get(ID);
            _PointEntity.DetailTypeRateId = q.DetailTypeRateId;
            _PointEntity.NumPoint = q.NumPoint;
            _PointEntity.PointId = q.PointId;
            _PointEntity.PointName = q.PointName;
            return  _PointEntity;

            //return (PointEntity)_PointDAC.Get(ID);
        }
        public IQueryable<PointEntity> GetAll()
        {
            var query = _PointDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new PointEntity()
                 {
                     DetailTypeRateId = q.DetailTypeRateId,
                     NumPoint = q.NumPoint,
                     PointId = q.PointId,
                     PointName = q.PointName

                 });
            return _query;
        }
        public IQueryable<PointEntity> GetAll(int ID)
        {
            var query = _PointDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false && a.DetailTypeRateId==ID)
                 select new PointEntity()
                 {
                     DetailTypeRateId = q.DetailTypeRateId,
                     NumPoint = q.NumPoint,
                     PointId = q.PointId,
                     PointName = q.PointName

                 });
            return _query;
        }
    }
}
