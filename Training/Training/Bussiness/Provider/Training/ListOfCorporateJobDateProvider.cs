using Bussiness.InfraStructre;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DomainModel.Models;

namespace Bussiness
{
    public class ListOfCorporateJobDateProvider : IListOfCorporateJobDateProvider
    {
        private ListOfCorporateJobDateDAC _ListOfCorporateJobDateDAC;

        public ListOfCorporateJobDateProvider()
        {
            _ListOfCorporateJobDateDAC = new ListOfCorporateJobDateDAC();
        }

        public int Add(ListOfCorporateJobDateEntity Current)
        {
            General _General = new General();
            Current.LOCJDate = _General.ShamsiToMiladi(Current.LOCJDateStr);
            ListOfCorporateJobDate _ListOfCorporateJobDate = new ListOfCorporateJobDate(Current.Description,Current.LOCJDate);
            return _ListOfCorporateJobDateDAC.Add(_ListOfCorporateJobDate);
        }

        public bool Delete(int ID)
        {
            return _ListOfCorporateJobDateDAC.Delete(ID);
        }

        public bool Edit(ListOfCorporateJobDateEntity Current)
        {
            General _General = new General();
            ListOfCorporateJobDate _ListOfCorporateJobDate = new ListOfCorporateJobDate();
            _ListOfCorporateJobDate.ListOfCorporateJobDateId = Current.ListOfCorporateJobDateId;
            _ListOfCorporateJobDate.TimeLastModified = DateTime.Now;
            _ListOfCorporateJobDate.Description = Current.Description;
            _ListOfCorporateJobDate.LOCJDate = _General.ShamsiToMiladi(Current.LOCJDateStr);
            return _ListOfCorporateJobDateDAC.Edit(_ListOfCorporateJobDate);
        }

        public ListOfCorporateJobDateEntity Get(int ID)
        {
            ListOfCorporateJobDateEntity _ListOfCorporateJobDateEntity = new ListOfCorporateJobDateEntity();
            var q = _ListOfCorporateJobDateDAC.Get(ID);
            _ListOfCorporateJobDateEntity.ListOfCorporateJobDateId = q.ListOfCorporateJobDateId;
            _ListOfCorporateJobDateEntity.Description = q.Description;
            _ListOfCorporateJobDateEntity.LOCJDate = q.LOCJDate;
            return _ListOfCorporateJobDateEntity;
        }

        public IQueryable<ListOfCorporateJobDateEntity> GetAll()
        {
            return _ListOfCorporateJobDateDAC.GetAllListOfCorporateJobDate();
        }
    }
}
