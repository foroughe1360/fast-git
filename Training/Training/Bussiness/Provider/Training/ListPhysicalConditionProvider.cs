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
    public class ListPhysicalConditionProvider : IListPhysicalConditionProvider
    {
        private ListPhysicalConditionDAC _ListPhysicalConditionDAC;
        public ListPhysicalConditionProvider()
        {
            _ListPhysicalConditionDAC = new ListPhysicalConditionDAC();
        }
        public int Add(ListPhysicalConditionEntity Current)
        {
            return _ListPhysicalConditionDAC.Add(Current);
        }
        public bool Delete(int ID)
        {
            return _ListPhysicalConditionDAC.Delete(ID);
        }
        public bool Edit(ListPhysicalConditionEntity Current)
        {
            return _ListPhysicalConditionDAC.Edit(Current);
        }
        public ListPhysicalConditionEntity Get(int ID)
        {
            ListPhysicalConditionEntity _ListPhysicalConditionEntity = new ListPhysicalConditionEntity();
            var q = _ListPhysicalConditionDAC.Get(ID);
            if (q != null)
            {
                _ListPhysicalConditionEntity.InventoryjobsId = q.InventoryjobsId;
                _ListPhysicalConditionEntity.ListPhysicalConditionId = q.ListPhysicalConditionId;
                _ListPhysicalConditionEntity.PhysicalConditionsId = q.PhysicalConditionsId;
            }
            else
            {
                _ListPhysicalConditionEntity = null;
            }
            return _ListPhysicalConditionEntity;
        }
        public ListPhysicalConditionEntity GetListPhysicalCondition(int inventoryjobsid, int physicalconditionsid)
        {
            ListPhysicalConditionEntity _ListPhysicalConditionEntity = new ListPhysicalConditionEntity();
            var q = _ListPhysicalConditionDAC.GetListPhysicalCondition(inventoryjobsid, physicalconditionsid);
            if (q != null)
            {
                _ListPhysicalConditionEntity.InventoryjobsId = q.InventoryjobsId;
                _ListPhysicalConditionEntity.ListPhysicalConditionId = q.ListPhysicalConditionId;
                _ListPhysicalConditionEntity.PhysicalConditionsId = q.PhysicalConditionsId;
            }
            else
            {
                _ListPhysicalConditionEntity = null;
            }
            return _ListPhysicalConditionEntity;
        }
        public IQueryable<ListPhysicalConditionEntity> GetAll()
        {
            return (IQueryable <ListPhysicalConditionEntity>)_ListPhysicalConditionDAC.GetAll();
        }
        public IQueryable<ListPhysicalConditionEntity> GetAll(int ID)
        {
            return _ListPhysicalConditionDAC.GetAll(ID);
        }
        public bool Addlist(List<ListPhysicalConditionEntity> Current)
        {
            foreach (var item in Current)
            {
                if (GetListPhysicalCondition(item.InventoryjobsId, item.PhysicalConditionsId) == null && item.State)
                {
                    ListPhysicalCondition _ListPhysicalCondition = new ListPhysicalCondition(item.InventoryjobsId, item.PhysicalConditionsId);
                    _ListPhysicalConditionDAC.Add(_ListPhysicalCondition);
                }
                else if (Get(item.ListPhysicalConditionId) != null && item.State == false)
                {
                    Delete(item.ListPhysicalConditionId);
                }
            }
            return true;
        }
    }
}
