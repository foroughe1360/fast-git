using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;

namespace DataAccess
{
    public class ListResponsibilitiePowerDAC : IListResponsibilitiePowerRepository
    {
        public int Add(ListResponsibilitiePower Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListResponsibilitiePowers.Add(Current);
            db.SaveChanges();
            return Current.ListResponsibilitiePowerId ;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listresponsibilitieppower = new ListResponsibilitiePower() { ListResponsibilitiePowerId = ID, Hidden = true };
                db.ListResponsibilitiePowers.Attach(listresponsibilitieppower);
                db.Entry(listresponsibilitieppower).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListResponsibilitiePower Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListResponsibilitiePowers.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.PostGroupId).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListResponsibilitiePower Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListResponsibilitiePowers.SingleOrDefault(x => x.ListResponsibilitiePowerId == ID);
        }

        public IQueryable<ListResponsibilitiePower> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListResponsibilitiePowers select item;
        }

        public IQueryable<ListResponsibilitiePowerEntity> GetAllListResponsibilitiePower()
        {
            TrainingContext db = new TrainingContext();
            return
                (from listresponsibilitiepowers in db.ListResponsibilitiePowers.Where(a => a.Hidden==false)
                 join postgroups in db.PostGroups on listresponsibilitiepowers.PostGroupId equals postgroups.PostGroupId
                 join tableinterfacevaluesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals tableinterfacevaluesPostType.TableInterfaceValueId
                 join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                 select new ListResponsibilitiePowerEntity
                 {
                     ListResponsibilitiePowerId = listresponsibilitiepowers.ListResponsibilitiePowerId,
                     PostGroupId = listresponsibilitiepowers.PostGroupId,
                     Description= listresponsibilitiepowers.Description,
                     PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + tableinterfacevaluesPostType.TableValue,
                 });
        }

        public IQueryable<ListResponsibilitiePowerEntity> GetAllListResponsibilitiePower(ListResponsibilitiePowerSearch listresponsibilitiepowersearch)
        {
            TrainingContext db = new TrainingContext();
            var list = 
                (from listresponsibilitiepowers in db.ListResponsibilitiePowers.Where(a => a.Hidden == false)
                 join postgroups in db.PostGroups on listresponsibilitiepowers.PostGroupId equals postgroups.PostGroupId
                 join tableinterfacevaluesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals tableinterfacevaluesPostType.TableInterfaceValueId
                 join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                 select new ListResponsibilitiePowerEntity
                 {
                     ListResponsibilitiePowerId = listresponsibilitiepowers.ListResponsibilitiePowerId,
                     PostGroupId = listresponsibilitiepowers.PostGroupId,
                     Description = listresponsibilitiepowers.Description,
                     PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + tableinterfacevaluesPostType.TableValue,
                 });
            if (listresponsibilitiepowersearch.PostGroupId != 0)
                list = list.Where(p => p.PostGroupId == listresponsibilitiepowersearch.PostGroupId);

            return list;
        }
    }
}
