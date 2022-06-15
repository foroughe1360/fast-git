using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DataAccess;
using InterfaceEntity;

namespace Bussiness
{
    public class EmployemeSignaturyProvider : IEmployemeSignaturyProvider
    {
        private EmployemeSignaturyDAC _EmployemeSignaturyDAC;

        public EmployemeSignaturyProvider()
        {
        _EmployemeSignaturyDAC = new EmployemeSignaturyDAC();
        }
        public int Add(EmployemeSignaturyEntity Current)
        {
            General _General = new General();
            Current.EmployemeSignaturyDate = _General.ShamsiToMiladi(Current.EmployemeSignaturyDatestr);
            EmployemeSignatury _EmployemeSignatury = new EmployemeSignatury(Current.SideSignatoryId, Current.EmployemeId,
                Current.EmployemeSignaturyDate, Current.State);
            return _EmployemeSignaturyDAC.Add(_EmployemeSignatury);
        }

        public bool Delete(int ID)
        {
            return _EmployemeSignaturyDAC.Delete(ID);
        }

        public bool Edit(EmployemeSignaturyEntity Current)
        {
            General _General = new General();
            EmployemeSignatury _EmployemeSignatury = new EmployemeSignatury();
            _EmployemeSignatury.EmployemeSignaturyId = Current.EmployemeSignaturyId;
            _EmployemeSignatury.TimeLastModified = DateTime.Now;
            _EmployemeSignatury.SideSignatoryId = Current.SideSignatoryId;
            _EmployemeSignatury.EmployemeId = Current.EmployemeId;
            _EmployemeSignatury.EmployemeSignaturyDate = _General.ShamsiToMiladi(Current.EmployemeSignaturyDatestr);
            _EmployemeSignatury.State = Current.State;
            return _EmployemeSignaturyDAC.Edit(_EmployemeSignatury);
        }

        public EmployemeSignaturyEntity Get(int ID)
        {
            EmployemeSignaturyEntity _EmployemeSignaturyEntity = new EmployemeSignaturyEntity();
            var q = _EmployemeSignaturyDAC.Get(ID);
            _EmployemeSignaturyEntity.EmployemeSignaturyId = q.EmployemeSignaturyId;
            _EmployemeSignaturyEntity.SideSignatoryId = q.SideSignatoryId;
            _EmployemeSignaturyEntity.EmployemeId = q.EmployemeId;
            _EmployemeSignaturyEntity.EmployemeSignaturyDate = q.EmployemeSignaturyDate;
            _EmployemeSignaturyEntity.State = q.State;
            return _EmployemeSignaturyEntity;
        }

        public IQueryable<EmployemeSignaturyEntity> GetListEmployemeSignatury()
        {
            return _EmployemeSignaturyDAC.GetListEmployemeSignatury();
        }

        public IQueryable<EmployemeSignaturyEntity> GetAll()
        {
            return (IQueryable<EmployemeSignaturyEntity>)_EmployemeSignaturyDAC.GetAll();
        }

        public IQueryable<EmployemeSignaturyEntity> GetAll(int sidesignatoryid)
        {
            return _EmployemeSignaturyDAC.GetAllEmployemeSignatury(sidesignatoryid);
        }

        public List<EmployemeSignaturyEntity> GetEmployemeMangerSignatury(int employemeid)
        {
            return _EmployemeSignaturyDAC.GetEmployemeMangerSignatury(employemeid);
        }

    }
}
