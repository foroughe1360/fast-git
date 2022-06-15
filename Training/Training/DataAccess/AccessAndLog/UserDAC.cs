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
    public class UserDAC : IUserRepository
    {
        public int Add(User Current)
        {
            TrainingContext db = new TrainingContext();
            db.Users.Add(Current);
            db.SaveChanges();
            return Current.UserId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var user = new User() { UserId = ID, Hidden = true };
                db.Users.Attach(user);
                db.Entry(user).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(User Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Users.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.FirstName).IsModified = true;
                db.Entry(Current).Property(x => x.LastName).IsModified = true;
                db.Entry(Current).Property(x => x.UserName).IsModified = true;
                db.Entry(Current).Property(x => x.IsActive).IsModified = true;
                db.Entry(Current).Property(x => x.RoleId).IsModified = true;

                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        /// <summary>
        /// this will be the tooltip
        /// </summary>
        /// <param name="Change Password">Used to Change Password.</param>
        public bool Edit(int ID,DateTime timelastmodified, string password,string vcode)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var user = new User() { UserId = ID,TimeLastModified= timelastmodified, Password=password,VCode=vcode };
                db.Users.Attach(user);
                db.Entry(user).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(user).Property(x => x.Password).IsModified = true;
                db.Entry(user).Property(x => x.VCode).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public User Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Users.SingleOrDefault(x => x.UserId == ID);
        }

        public UserEntity Get(string username)
        {
            TrainingContext db = new TrainingContext();
            return
                (from users in db.Users.Where(x => x.UserName == username && x.IsActive==true)
                 join tableinterfacevalues in db.TableInterfaceValues on users.RoleId equals tableinterfacevalues.TableInterfaceValueId
                 select new UserEntity
                 {
                     UserId= users.UserId,
                     LastName= users.LastName,
                     FirstName = users.FirstName,
                     IsActive = users.IsActive,
                     UserName = users.UserName,
                     Password = users.Password,
                     VCode = users.VCode,
                     Roles = tableinterfacevalues.TableValue,
                 }
                ).SingleOrDefault();
                
                
                //db.Users.SingleOrDefault(x => x.UserName == username);
        }

        public User Get(string username,string password)
        {
            TrainingContext db = new TrainingContext();
            return db.Users.SingleOrDefault(x => x.UserName == username && x.Password==password);
        }

        public IQueryable<User> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Users select item;
        }

        public IQueryable<UserEntity> GetAllUser()
        {
            TrainingContext db = new TrainingContext();
            return
                (from users in db.Users
                 join tableinterfacevalues in db.TableInterfaceValues on users.RoleId equals tableinterfacevalues.TableInterfaceValueId
                 select new UserEntity
                 {
                     UserId = users.UserId,
                     UserGUID = users.UserGUID,
                     FirstName=users.FirstName,
                     LastName=users.LastName,
                     IsActive=users.IsActive,
                     UserName=users.UserName,
                     Password=users.Password,
                     VCode=users.VCode,
                     RoleId=users.RoleId,
                     Roles=tableinterfacevalues.TableValue,
                     UserNameFamily=users.FirstName+" "+users.LastName
                 });
        }
    }
}
