using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using DomainModel.Models;

namespace Bussiness
{
    public class ListHealthConditionProvider : IListHealthConditionprovider
    {
        private ListHealthConditionDAC _ListHealthConditionDAC;

        public ListHealthConditionProvider()
        {
            _ListHealthConditionDAC = new ListHealthConditionDAC();
        }

        public int Add(ListHealthConditionEntity Current)
        {
         return   _ListHealthConditionDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListHealthConditionDAC.Delete(ID);
        }

        public bool Edit(ListHealthConditionEntity Current)
        {
            ListHealthCondition _ListHealthCondition = new ListHealthCondition();
            _ListHealthCondition.ListHealthConditionId = Current.ListHealthConditionId;
            _ListHealthCondition.TimeLastModified = DateTime.Now;
            _ListHealthCondition.InventoryjobsId = Current.InventoryjobsId;
            _ListHealthCondition.HealthConditionsId = Current.HealthConditionsId;
            _ListHealthCondition.Description = Current.Description;
            return _ListHealthConditionDAC.Edit(_ListHealthCondition);
        }

        public ListHealthConditionEntity Get(int ID)
        {
            ListHealthConditionEntity _ListHealthConditionEntity = new ListHealthConditionEntity();
            var q = _ListHealthConditionDAC.Get(ID);
            if (q != null)
            {
                _ListHealthConditionEntity.HealthConditionsId = q.HealthConditionsId;
                _ListHealthConditionEntity.InventoryjobsId = q.InventoryjobsId;
                _ListHealthConditionEntity.ListHealthConditionId = q.ListHealthConditionId;
            }
            else
            {
                _ListHealthConditionEntity = null;
            }
            return _ListHealthConditionEntity; 
        }

        public ListHealthConditionEntity GetListHealthCondition(int inventoryjobsid, int healthconditionsid)
        {
            ListHealthConditionEntity _ListHealthConditionEntity = new ListHealthConditionEntity();
            var q = _ListHealthConditionDAC.GetListHealthCondition(inventoryjobsid, healthconditionsid);
            if (q != null)
            {
                _ListHealthConditionEntity.HealthConditionsId = q.HealthConditionsId;
                _ListHealthConditionEntity.InventoryjobsId = q.InventoryjobsId;
                _ListHealthConditionEntity.ListHealthConditionId = q.ListHealthConditionId;
            }
            else
            {
                _ListHealthConditionEntity = null;
            }
            return _ListHealthConditionEntity;
        }

        public IQueryable<ListHealthConditionEntity> GetAll()
        {
           return (IQueryable<ListHealthConditionEntity>)_ListHealthConditionDAC.GetAll();
        }

        public IQueryable<ListHealthConditionEntity> GetAll(int ID)
        {
            return _ListHealthConditionDAC.GetAll(ID);
        }

        public bool Addlist(List<ListHealthConditionEntity> Current)
        {
            foreach (var item in Current)
            {
                if (GetListHealthCondition(item.InventoryjobsId, item.HealthConditionsId) == null && item.State)
                {
                    ListHealthCondition _ListHealthCondition = new ListHealthCondition(item.InventoryjobsId, item.HealthConditionsId, item.Description);
                    _ListHealthConditionDAC.Add(_ListHealthCondition);
                }
                else if (Get(item.ListHealthConditionId) != null && item.State == false)
                {
                    Delete(item.ListHealthConditionId);
                }
                else if (Get(item.ListHealthConditionId) != null && item.State ==  true)
                {
                    if (Edit(item) == false)
                        return false;
                }
            }
            return true;
        }
    }
}
