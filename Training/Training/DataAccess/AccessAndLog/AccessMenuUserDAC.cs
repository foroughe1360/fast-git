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
    public class AccessMenuUserDAC : IAccessMenuUserRepository
    {
        public int Add(AccessMenuUser Current)
        {
            using (TrainingContext db = new TrainingContext())
            {
                try
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.AccessMenuUsers.Add(Current);
                    db.SaveChanges();
                }
                finally
                {
                    db.Configuration.AutoDetectChangesEnabled = true;
                }
            }
            return Current.AccessMenuUserId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                
                var accessmenuUser = new AccessMenuUser() { AccessMenuUserId = ID, Hidden = true };
                db.AccessMenuUsers.Attach(accessmenuUser);
                db.Entry(accessmenuUser).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(AccessMenuUser Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.AccessMenuUsers.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Status).IsModified = true;
                db.Entry(Current).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public AccessMenuUser Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.AccessMenuUsers.SingleOrDefault(x => x.AccessMenuUserId == ID);
           
        }

        public AccessMenuUser Get(int userid,int menuid)
        {
            TrainingContext db = new TrainingContext();
            return db.AccessMenuUsers.SingleOrDefault(x => x.UserId == userid && x.MenuId == menuid && x.Hidden == false); 
        }

        public IQueryable<AccessMenuUser> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.AccessMenuUsers select item;
        }

        public IQueryable<AccessMenuUserEntity> GetAllAccessMenuUser(int ID)
        {
            TrainingContext db = new TrainingContext();

            var _query =
                (from accessmenuusers in db.AccessMenuUsers.Where(a => a.Hidden == false && a.UserId == ID)
                 join users in db.Users on accessmenuusers.UserId equals users.UserId
                 join tableinterfacevalues in db.TableInterfaceValues on accessmenuusers.AccessTypeId equals tableinterfacevalues.TableInterfaceValueId
                 join menus in db.Menus on accessmenuusers.MenuId equals menus.MenuId
                 select new AccessMenuUserEntity()
                 {
                     AccessMenuUserId = accessmenuusers.AccessMenuUserId,
                     AccessTypeId = accessmenuusers.AccessTypeId,
                     AccessTypeName = tableinterfacevalues.TableValue,
                     MenuId = accessmenuusers.MenuId,
                     MenuName = menus.Name,
                     Status = accessmenuusers.Status,
                     UserId = accessmenuusers.UserId,
                     UserNameFamily = users.FirstName + " " + users.LastName
                 });
            return _query;
        }
        public IQueryable<AccessMenuUserEntity> GetAllAccessMenuUserTree(int ID)
        {
            TrainingContext db = new TrainingContext();
            
            var _query =
                (
                 from menus in db.Menus
                 join accessmenuusers in db.AccessMenuUsers.Where(a => a.UserId == ID && a.Hidden == false ) on menus.MenuId equals accessmenuusers.MenuId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new AccessMenuUserEntity()
                 {
                     AccessMenuUserId = menus.MenuId,
                     MenuName = menus.Name,
                     Selected = (temp.AccessMenuUserId == null ? false : true),
                     Parent = menus.Parent,
                     Opened = false
                 });
            return _query;
        }
        public IQueryable<AccessMenuUserEntity> GetAllAccessMenuUserTreeOnly(int ID)
        {
            TrainingContext db = new TrainingContext();

            var _query =
                (
                 from accessmenuusers in db.AccessMenuUsers.Where(a => a.UserId == ID && a.Hidden == false)
                 select new AccessMenuUserEntity()
                 {
                     MenuId = accessmenuusers.MenuId
                 });
            return _query;
        }
    }
}
