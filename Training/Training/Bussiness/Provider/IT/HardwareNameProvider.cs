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
    class HardwareNameProvider : IHardwareNameProvider
    {
        private HardwareNameDAC _HardwareNameDAC;
        private General _General;
        public HardwareNameProvider()
        {
            _HardwareNameDAC = new HardwareNameDAC();
        }

        public int Add(HardwareNameEntity Current)
        {
            General _General = new General();
            HardwareName _HardwareName = new HardwareName(Current.HardwareTitle, Current.State);
            return _HardwareNameDAC.Add(_HardwareName);
        }

        public bool Delete(int ID)
        {
            return _HardwareNameDAC.Delete(ID);
        }

        public bool Edit(HardwareNameEntity Current)
        {
            General _General = new General();
            HardwareName _HardwareName = new HardwareName();
            _HardwareName.HardwareNameId = Current.HardwareNameId;
            _HardwareName.TimeLastModified = DateTime.Now;
            _HardwareName.HardwareTitle = Current.HardwareTitle;
            _HardwareName.State = Current.State;
            return _HardwareNameDAC.Edit(_HardwareName);
        }

        public HardwareNameEntity Get(int ID)
        {
            HardwareNameEntity _HardwareNameEntity = new HardwareNameEntity();
            var q = _HardwareNameDAC.Get(ID);
            _HardwareNameEntity.HardwareNameId = q.HardwareNameId;
            _HardwareNameEntity.HardwareTitle = q.HardwareTitle;
            _HardwareNameEntity.State = q.State; ;
            return _HardwareNameEntity;
        }
        public IQueryable<HardwareNameEntity> GetAll()
        {
            var query = _HardwareNameDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new HardwareNameEntity()
                 {
                     HardwareNameId = q.HardwareNameId,
                     HardwareTitle = q.HardwareTitle,
                     State = q.State
                 });
            return _query;
        }

        //public IQueryable<HardwareNameEntity> GetAll(HardwareNameSearch HardwareNamesearch)
        //{
        //    return _HardwareNameDAC.GetAllHardwareNameModel(HardwareNamesearch);
        //}

        public IQueryable<HardwareNameEntity> GetAll(int HardwareNameid)
        {
            var query = _HardwareNameDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false && a.HardwareNameId == HardwareNameid)
                 select new HardwareNameEntity()
                 {
                     HardwareNameId = q.HardwareNameId,
                     HardwareTitle = q.HardwareTitle,
                 });
            return _query;
        }

    }

}

