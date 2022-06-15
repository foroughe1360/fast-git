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
    public class DepartmentProvider : IDepartmentProvider
    {
        private DepartmentDAC _DepartmentDAC;
        public DepartmentProvider()
        {
            _DepartmentDAC = new DepartmentDAC();
        }
        public int Add(DepartmentEntity Current)
        {
            Department _Department = new Department(Current.UnitSCenterId,Current.Name);
            return _DepartmentDAC.Add(_Department);
        }
        public bool Delete(int ID)
        {
            return _DepartmentDAC.Delete(ID);
        }
        public bool Edit(DepartmentEntity Current)
        {
            Department _Department = new Department();
            _Department.DepartmentId = Current.DepartmentId;
            _Department.TimeLastModified= DateTime.Now;
            _Department.UnitSCenterId = Current.UnitSCenterId;
            _Department.Name = Current.Name;

            return _DepartmentDAC.Edit(_Department);
        }
        public DepartmentEntity Get(int ID)
        {
            DepartmentEntity _DepartmentEntity = new DepartmentEntity();
            var q = _DepartmentDAC.Get(ID);
            _DepartmentEntity.DepartmentId = q.DepartmentId;
            _DepartmentEntity.Name = q.Name;
            _DepartmentEntity.UnitSCenterId = q.UnitSCenterId;
            return _DepartmentEntity;
            //return (DepartmentEntity) _DepartmentDAC.Get(ID);
        }
        public IQueryable<DepartmentEntity> GetAll()
        {
            return  _DepartmentDAC.GetAllDepartment();
        }
        public IQueryable<DepartmentEntity> GetDepartmentDPD(int unitscenterid)
        {
            return _DepartmentDAC.GetDepartmentDPD(unitscenterid);
        }
    }
}
