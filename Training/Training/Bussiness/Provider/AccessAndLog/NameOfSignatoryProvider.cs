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
    public class NameOfSignatoryProvider : INameOfSignatoryProvider
    {
        private NameOfSignatoryDAC _NameOfSignatoryDAC;
        public NameOfSignatoryProvider()
        {
            _NameOfSignatoryDAC = new NameOfSignatoryDAC();
        }
        public int Add(NameOfSignatoryEntity Current)
        {
            General _General = new General();
            Current.NameOfSignatoryDate = _General.ShamsiToMiladi(Current.NameOfSignatoryDatestr);
            NameOfSignatory _NameOfSignatory = new NameOfSignatory(Current.SideSignatoryId,Current.FirstName,Current.LastName,
                Current.NameOfSignatoryDate,Current.State);
            return _NameOfSignatoryDAC.Add(_NameOfSignatory);
        }

        public bool Delete(int ID)
        {
            return _NameOfSignatoryDAC.Delete(ID);
        }

        public bool Edit(NameOfSignatoryEntity Current)
        {
            General _General = new General();
            NameOfSignatory _NameOfSignatory = new NameOfSignatory();
            _NameOfSignatory.NameOfSignatoryId = Current.NameOfSignatoryId;
            _NameOfSignatory.TimeLastModified = DateTime.Now;
            _NameOfSignatory.SideSignatoryId = Current.SideSignatoryId;
            _NameOfSignatory.FirstName = Current.FirstName;
            _NameOfSignatory.LastName = Current.LastName;
            _NameOfSignatory.NameOfSignatoryDate = _General.ShamsiToMiladi(Current.NameOfSignatoryDatestr);
            _NameOfSignatory.State = Current.State;
            return _NameOfSignatoryDAC.Edit(_NameOfSignatory);
        }

        public NameOfSignatoryEntity Get(int ID)
        {
            NameOfSignatoryEntity _NameOfSignatoryEntity = new NameOfSignatoryEntity();
            var q = _NameOfSignatoryDAC.Get(ID);
            _NameOfSignatoryEntity.NameOfSignatoryId = q.NameOfSignatoryId;
            _NameOfSignatoryEntity.SideSignatoryId = q.SideSignatoryId;
            _NameOfSignatoryEntity.FirstName = q.FirstName;
            _NameOfSignatoryEntity.LastName = q.LastName;
            _NameOfSignatoryEntity.NameOfSignatoryDate = q.NameOfSignatoryDate;
            _NameOfSignatoryEntity.State = q.State;
            return _NameOfSignatoryEntity;
        }

        public IQueryable<NameOfSignatoryEntity> GetListNameOfSignatory()
        {
            return _NameOfSignatoryDAC.GetListNameOfSignatory();
        }

        public IQueryable<NameOfSignatoryEntity> GetAll()
        {
            return (IQueryable < NameOfSignatoryEntity > )_NameOfSignatoryDAC.GetAll();
        }

        public IQueryable<NameOfSignatoryEntity> GetAll(int sidesignatoryid)
        {
            return _NameOfSignatoryDAC.GetAllNameOfSignatory(sidesignatoryid);
        }
    }
}
