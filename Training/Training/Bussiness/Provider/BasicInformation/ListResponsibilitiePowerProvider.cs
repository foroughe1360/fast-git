using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity.Search.BasicInformation;

namespace Bussiness
{
    public class ListResponsibilitiePowerProvider : IListResponsibilitiePowerProvider
    {
        ListResponsibilitiePowerDAC _ListResponsibilitiePowerDAC;

        public ListResponsibilitiePowerProvider()
        {
            _ListResponsibilitiePowerDAC = new ListResponsibilitiePowerDAC();
        }
        
        public int Add(ListResponsibilitiePowerEntity Current)
        {
            ListResponsibilitiePower _ListResponsibilitiePpower = 
                new ListResponsibilitiePower(Current.PostGroupId,Current.Description);
            return _ListResponsibilitiePowerDAC.Add(_ListResponsibilitiePpower);
        }

        public bool Delete(int ID)
        {
            return _ListResponsibilitiePowerDAC.Delete(ID);
        }

        public bool Edit(ListResponsibilitiePowerEntity Current)
        {
            ListResponsibilitiePower _ListResponsibilitiePower = new ListResponsibilitiePower();
            _ListResponsibilitiePower.ListResponsibilitiePowerId = Current.ListResponsibilitiePowerId;
            _ListResponsibilitiePower.TimeLastModified = DateTime.Now;
            _ListResponsibilitiePower.PostGroupId = Current.PostGroupId;
            _ListResponsibilitiePower.Description = Current.Description;
            return _ListResponsibilitiePowerDAC.Edit(_ListResponsibilitiePower);
        }

        public ListResponsibilitiePowerEntity Get(int ID)
        {
            ListResponsibilitiePowerEntity _ListResponsibilitiePowerEntity = new ListResponsibilitiePowerEntity();
            var q = _ListResponsibilitiePowerDAC.Get(ID);
            _ListResponsibilitiePowerEntity.ListResponsibilitiePowerId = q.ListResponsibilitiePowerId;
            _ListResponsibilitiePowerEntity.PostGroupId = q.PostGroupId;
            _ListResponsibilitiePowerEntity.Description = q.Description;
            return _ListResponsibilitiePowerEntity;
        }

        public IQueryable<ListResponsibilitiePowerEntity> GetAll()
        {
            return _ListResponsibilitiePowerDAC.GetAllListResponsibilitiePower();
        }

        public IQueryable<ListResponsibilitiePowerEntity> GetAll(ListResponsibilitiePowerSearch listresponsibilitiepowersearch)
        {
            return _ListResponsibilitiePowerDAC.GetAllListResponsibilitiePower(listresponsibilitiepowersearch);
        }
        
    }
}
