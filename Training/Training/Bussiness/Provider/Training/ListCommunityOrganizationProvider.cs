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
    public class ListCommunityOrganizationProvider : IListCommunityOrganizationProvider
    {
        private ListCommunityOrganizationDAC _ListCommunityOrganizationDAC;

        public ListCommunityOrganizationProvider()
        {
            _ListCommunityOrganizationDAC = new ListCommunityOrganizationDAC();
        }

        public int Add(ListCommunityOrganizationEntity Current)
        {
            return _ListCommunityOrganizationDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListCommunityOrganizationDAC.Delete(ID);
        }

        public bool Edit(ListCommunityOrganizationEntity Current)
        {
            return _ListCommunityOrganizationDAC.Edit(Current);
        }

        public ListCommunityOrganizationEntity Get(int ID)
        {
            ListCommunityOrganizationEntity _ListCommunityOrganizationEntity = new ListCommunityOrganizationEntity();
            var q = _ListCommunityOrganizationDAC.Get(ID);
            if (q != null)
            {
                _ListCommunityOrganizationEntity.CommunityOrganizationsId = q.CommunityOrganizationsId;
                _ListCommunityOrganizationEntity.InventoryjobsId = q.InventoryjobsId;
                _ListCommunityOrganizationEntity.ListCommunityOrganizationId = q.ListCommunityOrganizationId;
            }
            else
            {
                _ListCommunityOrganizationEntity = null;
            }
            return _ListCommunityOrganizationEntity;
        }

        public ListCommunityOrganizationEntity GetListCommunityOrganization(int inventoryjobsid, int communityorganizationsid,int communicationorganizationid)
        {
            ListCommunityOrganizationEntity _ListCommunityOrganizationEntity = new ListCommunityOrganizationEntity();
            var q = _ListCommunityOrganizationDAC.GetListCommunityOrganization(inventoryjobsid, communityorganizationsid,communicationorganizationid);
            if (q != null)
            {
                _ListCommunityOrganizationEntity.CommunityOrganizationsId = q.CommunityOrganizationsId;
                _ListCommunityOrganizationEntity.InventoryjobsId = q.InventoryjobsId;
                _ListCommunityOrganizationEntity.ListCommunityOrganizationId = q.ListCommunityOrganizationId;
            }
            else
            {
                _ListCommunityOrganizationEntity = null;
            }
            return _ListCommunityOrganizationEntity;
        }

        public IQueryable<ListCommunityOrganizationEntity> GetAll()
        {
            var query = _ListCommunityOrganizationDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new ListCommunityOrganizationEntity()
                 {
                     CommunityOrganizationsId = q.CommunityOrganizationsId,
                     InventoryjobsId = q.InventoryjobsId,
                     ListCommunityOrganizationId = q.ListCommunityOrganizationId

                 });
            return _query;
        }

        public IQueryable<ListCommunityOrganizationEntity> GetAll(int ID, int communicationorganizationid)
        {
            return _ListCommunityOrganizationDAC.GetAll(ID, communicationorganizationid);
        }

        public IQueryable<ListCommunityOrganizationEntity> GetAll(int ID)
        {
            return _ListCommunityOrganizationDAC.GetAll(ID);
        }

        public bool Addlist(List<ListCommunityOrganizationEntity> Current)
        {
            foreach (var item in Current)
            {
                if (GetListCommunityOrganization(item.InventoryjobsId, item.CommunityOrganizationsId,item.CommunicationOrganizationId) == null && item.State)
                {
                    ListCommunityOrganization _ListCommunityOrganization = new ListCommunityOrganization(item.InventoryjobsId,item.CommunicationOrganizationId, item.CommunityOrganizationsId);
                    _ListCommunityOrganizationDAC.Add(_ListCommunityOrganization);
                }
                else if (Get(item.ListCommunityOrganizationId) != null && item.State == false)
                {
                    Delete(item.ListCommunityOrganizationId);
                }
            }
            return true;
        }
    }
}
