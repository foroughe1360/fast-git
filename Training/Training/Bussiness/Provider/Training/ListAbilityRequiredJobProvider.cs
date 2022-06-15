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
    public class ListAbilityRequiredJobProvider : IListAbilityRequiredJobProvider
    {
        private ListAbilityRequiredJobDAC _ListAbilityRequiredJobDAC;
        public ListAbilityRequiredJobProvider()
        {
            _ListAbilityRequiredJobDAC = new ListAbilityRequiredJobDAC();
        }
        public int Add(ListAbilityRequiredJobEntity Current)
        {
            return _ListAbilityRequiredJobDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListAbilityRequiredJobDAC.Delete(ID);
        }

        public bool Edit(ListAbilityRequiredJobEntity Current)
        {
            return _ListAbilityRequiredJobDAC.Edit(Current);
        }

        public ListAbilityRequiredJobEntity Get(int ID)
        {
            ListAbilityRequiredJobEntity _ListAbilityRequiredJobEntity = new ListAbilityRequiredJobEntity();
            var q = _ListAbilityRequiredJobDAC.Get(ID);
            if (q != null)
            {
                _ListAbilityRequiredJobEntity.AbilityRequiredJobId = q.AbilityRequiredJobId;
                _ListAbilityRequiredJobEntity.InventoryjobsId = q.InventoryjobsId;
                _ListAbilityRequiredJobEntity.ListAbilityRequiredJobId = q.ListAbilityRequiredJobId;
            }
            else
            {
                _ListAbilityRequiredJobEntity = null;
            }
            return _ListAbilityRequiredJobEntity;
        }
        public ListAbilityRequiredJobEntity GetListAbilityRequiredJob(int inventoryjobsid, int abilityrequiredjobid)
        {
            ListAbilityRequiredJobEntity _ListAbilityRequiredJobEntity = new ListAbilityRequiredJobEntity();
            var q = _ListAbilityRequiredJobDAC.GetListAbilityRequiredJob(inventoryjobsid, abilityrequiredjobid);
            if (q != null)
            {
                _ListAbilityRequiredJobEntity.AbilityRequiredJobId = q.AbilityRequiredJobId;
                _ListAbilityRequiredJobEntity.InventoryjobsId = q.InventoryjobsId;
                _ListAbilityRequiredJobEntity.ListAbilityRequiredJobId = q.ListAbilityRequiredJobId;
            }
            else
            {
                _ListAbilityRequiredJobEntity = null;
            }
            return _ListAbilityRequiredJobEntity;
        }

        public IQueryable<ListAbilityRequiredJobEntity> GetAll()
        {
           return (IQueryable<ListAbilityRequiredJobEntity>)_ListAbilityRequiredJobDAC.GetAll();
        }

        public IQueryable<ListAbilityRequiredJobEntity> GetAll(int ID)
        {
            return _ListAbilityRequiredJobDAC.GetAll(ID);
        }

        public bool Addlist(List<ListAbilityRequiredJobEntity> Current)
        {
            foreach (var item in Current)
            {
                if (GetListAbilityRequiredJob(item.InventoryjobsId, item.AbilityRequiredJobId) == null && item.State)
                {
                    ListAbilityRequiredJob _ListAbilityRequiredJob = new ListAbilityRequiredJob(item.InventoryjobsId, item.AbilityRequiredJobId);
                    _ListAbilityRequiredJobDAC.Add(_ListAbilityRequiredJob);
                }
                else if (Get(item.ListAbilityRequiredJobId) != null && item.State == false)
                {
                    Delete(item.ListAbilityRequiredJobId);
                }
            }
            return true;
        }
    }
}
