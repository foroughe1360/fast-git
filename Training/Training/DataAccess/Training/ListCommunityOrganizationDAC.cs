using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class ListCommunityOrganizationDAC : IListCommunityOrganizationRepository
    {
        public int Add(ListCommunityOrganization Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListCommunityOrganizations.Add(Current);
            db.SaveChanges();
            return Current.ListCommunityOrganizationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listCommunityOrganization = new ListCommunityOrganization() { ListCommunityOrganizationId = ID, Hidden = true };
                db.ListCommunityOrganizations.Attach(listCommunityOrganization);
                db.Entry(listCommunityOrganization).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();

            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListCommunityOrganization Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListCommunityOrganizations.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListCommunityOrganization Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListCommunityOrganizations.SingleOrDefault(x => x.ListCommunityOrganizationId == ID);
        }

        public ListCommunityOrganization GetListCommunityOrganization(int inventoryjobsid,int communityorganizationsid,int communicationorganizationid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListCommunityOrganizations.SingleOrDefault(x => x.InventoryjobsId == inventoryjobsid && x.CommunityOrganizationsId == communityorganizationsid && x.Hidden == false && x.CommunicationOrganizationId == communicationorganizationid);
        }

        public IQueryable<ListCommunityOrganization> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListCommunityOrganizations select item;
        }

        public IQueryable<ListCommunityOrganizationEntity> GetAll(int ID , int communicationorganizationid)
        {
            TrainingContext db = new TrainingContext();
            return
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.TableInterfaceId == (int)TableInterfaceEntity.TableInterface.CommunityOrganizations)
                 join listcommunityorganizations in db.ListCommunityOrganizations.Where(a => a.InventoryjobsId == ID && a.CommunicationOrganizationId == communicationorganizationid && a.Hidden==false) on tableinterfacevalues.TableInterfaceValueId equals listcommunityorganizations.CommunityOrganizationsId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListCommunityOrganizationEntity
                 {
                     ListCommunityOrganizationId = (temp.ListCommunityOrganizationId == null ? 0 : temp.ListCommunityOrganizationId),
                     InventoryjobsId = (temp.InventoryjobsId == null ? 0 : temp.InventoryjobsId),
                     CommunityOrganizationsId = tableinterfacevalues.TableInterfaceValueId,
                     ListCommunityOrganizationName = tableinterfacevalues.TableValue,
                     ListCommunityOrganizationState = (temp == null ? false : true)
                 });
        }

        public IQueryable<ListCommunityOrganizationEntity> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            var s=
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.TableInterfaceId == (int)TableInterfaceEntity.TableInterface.CommunityOrganizations && a.Hidden==false)
                 join listcommunityorganizations in db.ListCommunityOrganizations.Where(a => a.InventoryjobsId == ID && a.Hidden == false) on tableinterfacevalues.TableInterfaceValueId equals listcommunityorganizations.CommunityOrganizationsId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListCommunityOrganizationEntity
                 {
                     CommunicationOrganizationId = (temp.CommunicationOrganizationId == null ? 0 : temp.CommunicationOrganizationId),
                     ListCommunityOrganizationId = (temp.ListCommunityOrganizationId == null ? 0 : temp.ListCommunityOrganizationId),
                     InventoryjobsId = (temp.InventoryjobsId == null ? 0 : temp.InventoryjobsId),
                     CommunityOrganizationsId = tableinterfacevalues.TableInterfaceValueId,
                     ListCommunityOrganizationName = tableinterfacevalues.TableValue,
                     ListCommunityOrganizationState = (temp == null ? false : true)
                 });
            return s;
        }

    }
}
