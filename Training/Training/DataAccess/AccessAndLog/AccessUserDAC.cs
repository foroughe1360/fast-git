using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;

namespace DataAccess
{
    public class AccessUserDAC : IAccessUserRepository
    {
        public int Add(AccessUser Current)
        {
            TrainingContext db = new TrainingContext();
            db.AccessUsers.Add(Current);
            db.SaveChanges();
            return Current.AccessUserId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var accessuser = new AccessUser() { AccessUserId = ID, Hidden = true };
                db.AccessUsers.Attach(accessuser);
                db.Entry(accessuser).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(AccessUser Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.AccessUsers.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public AccessUser Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.AccessUsers.SingleOrDefault(x => x.AccessUserId == ID);
        }

        public IQueryable<AccessUser> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.AccessUsers select item;
        }
    }
}
