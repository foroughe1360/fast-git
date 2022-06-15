using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;

namespace DataAccess
{
    public class ListQualificationOfStaffDAC : IListQualificationOfStaffRepository
    {
        public int Add(ListQualificationOfStaff Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListQualificationOfStaffs.Add(Current);
            db.SaveChanges();
            return Current.ListQualificationOfStaffId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listQualificationOfStaff = new ListQualificationOfStaff() { ListQualificationOfStaffId = ID, Hidden = true };
                db.ListQualificationOfStaffs.Attach(listQualificationOfStaff);
                db.Entry(listQualificationOfStaff).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();

                //TrainingContext db = new TrainingContext();
                //var accessmenuUser = db.AccessMenuUsers.SingleOrDefault(x => x.AccessMenuUserId == ID);
                //db.AccessMenuUsers.Remove(accessmenuUser);
                //db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListQualificationOfStaff Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListQualificationOfStaffs.Attach(Current);
                db.Entry(Current).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch 
            {
                return Success = false;
            }
            return Success;
        }

        public ListQualificationOfStaff Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListQualificationOfStaffs.SingleOrDefault(x => x.ListQualificationOfStaffId == ID);
        }

        public IQueryable<ListQualificationOfStaff> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListQualificationOfStaffs select item;
        }
    }
}
