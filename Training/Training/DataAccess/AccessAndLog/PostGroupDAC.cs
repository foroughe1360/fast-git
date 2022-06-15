using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;

namespace DataAccess
{
    public class PostGroupDAC : IPostGroupRepository
    {
        public int Add(PostGroup Current)
        {
            TrainingContext db = new TrainingContext();
            db.PostGroups.Add(Current);
            db.SaveChanges();
            return Current.PostTypeId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var postgroup = new PostGroup() { PostGroupId = ID, Hidden = true };
                db.PostGroups.Attach(postgroup);
                db.Entry(postgroup).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(PostGroup Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.PostGroups.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.CollectionId).IsModified = true;
                db.Entry(Current).Property(x => x.PostTypeId).IsModified = true;
                db.Entry(Current).Property(x => x.State).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public PostGroup Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.PostGroups.SingleOrDefault(x => x.PostGroupId == ID);
        }

        public IQueryable<PostGroup> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.PostGroups select item;
        }

        public IQueryable<PostGroupEntity> GetAllPostGroup()
        {
            TrainingContext db = new TrainingContext();
            return
                (from postgroups in db.PostGroups.Where(a=>a.Hidden==false)
                 join tableinterfacevaluesCollectionId in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollectionId.TableInterfaceValueId
                 join TableInterfaceValuesPostTypeId in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostTypeId.TableInterfaceValueId
                 select new PostGroupEntity
                 {
                     PostGroupId=postgroups.PostGroupId,
                     PostTypeId=postgroups.PostTypeId,
                     CollectionId=postgroups.CollectionId,
                     PostTypeName = TableInterfaceValuesPostTypeId.TableValue,
                     CollectionName = tableinterfacevaluesCollectionId.TableValue,
                     PostGroupName = tableinterfacevaluesCollectionId.TableValue+" -- " +TableInterfaceValuesPostTypeId.TableValue,
                     State=postgroups.State
                 });
        }        
    }
}
