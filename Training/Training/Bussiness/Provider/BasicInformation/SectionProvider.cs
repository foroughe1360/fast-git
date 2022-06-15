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
    public class SectionProvider : ISectionProvider
    {
        private SectionDAC _SectionDAC;
        public SectionProvider()
        {
            _SectionDAC = new SectionDAC();
        }
        public int Add(SectionEntity Current)
        {
            Section _Section = new Section(Current.Name, Current.DepartmentId);
            return _SectionDAC.Add(_Section);
        }
        public bool Delete(int ID)
        {
            return _SectionDAC.Delete(ID);
        }
        public bool Edit(SectionEntity Current)
        {
            Section _Section = new Section();
            _Section.SectionId = Current.SectionId;
            _Section.TimeLastModified = DateTime.Now;
            _Section.Name = Current.Name;
            _Section.DepartmentId = Current.DepartmentId;
            return _SectionDAC.Edit(_Section);
        }
        public SectionEntity Get(int ID)
        {
            SectionEntity _SectionEntity = new SectionEntity();
            var q = _SectionDAC.Get(ID);
            _SectionEntity.DepartmentId = q.DepartmentId;
            _SectionEntity.Name = q.Name;
            _SectionEntity.SectionId = q.SectionId;
            return _SectionEntity;

            //return (SectionEntity)_Section.Get(ID);
        }
        public IQueryable<SectionEntity> GetAll()
        {
            var query = _SectionDAC.GetAll();
            return
                (from q in query
                 select new SectionEntity
                 {
                     SectionId = q.SectionId,
                     DepartmentId = q.DepartmentId,
                     Name = q.Name
                     
                 });
        }
        public IQueryable<SectionEntity> GetAll(int ID)
        {
            return _SectionDAC.GetAllSection(ID);
        }
    }
}
