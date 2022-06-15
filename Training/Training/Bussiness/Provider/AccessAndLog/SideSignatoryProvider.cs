using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel;

namespace Bussiness
{
    public class SideSignatoryProvider : ISideSignatoryProvider
    {
        private SideSignatoryDAC _SideSignatoryDAC;
        public SideSignatoryProvider()
        {
            _SideSignatoryDAC = new SideSignatoryDAC();
        }

        public int Add(SideSignatoryEntity Current)
        {
            SideSignatory _SideSignatory = new SideSignatory(Current.Title,Current.TitleEN,Current.SideSignatoryCode);
            return _SideSignatoryDAC.Add(_SideSignatory);
        }

        public bool Delete(int ID)
        {
            return _SideSignatoryDAC.Delete(ID);
        }

        public bool Edit(SideSignatoryEntity Current)
        {
            SideSignatory _SideSignatory = new SideSignatory();
            _SideSignatory.SideSignatoryId = Current.SideSignatoryId;
            _SideSignatory.TimeLastModified = DateTime.Now;
            _SideSignatory.Title = Current.Title;
            _SideSignatory.TitleEN = Current.TitleEN;
            _SideSignatory.SideSignatoryCode = Current.SideSignatoryCode;
            return _SideSignatoryDAC.Edit(_SideSignatory);
        }

        public SideSignatoryEntity Get(int ID)
        {
            SideSignatoryEntity _SideSignatoryEntity = new SideSignatoryEntity();
            var q = _SideSignatoryDAC.Get(ID);
            _SideSignatoryEntity.SideSignatoryId = q.SideSignatoryId;
            _SideSignatoryEntity.Title = q.Title;
            _SideSignatoryEntity.TitleEN = q.TitleEN;
            _SideSignatoryEntity.SideSignatoryCode = q.SideSignatoryCode;
            return _SideSignatoryEntity;
        }

        public IQueryable<SideSignatoryEntity> GetAll()
        {
            return _SideSignatoryDAC.GetAllSideSignatory();
        }
    }
}
