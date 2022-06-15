using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;

namespace DataAccess
{
    public class HistoryQualificationOfStaffDAC : IHistoryQualificationOfStaffRepository
    {
        public int Add(HistoryQualificationOfStaff Current)
        {
            TrainingContext db = new TrainingContext();
            db.HistoryQualificationOfStaffs.Add(Current);
            db.SaveChanges();
            return Current.HistoryQualificationOfStaffId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var historyQualificationOfStaff = new HistoryQualificationOfStaff() {  HistoryQualificationOfStaffId= ID, Hidden = true };
                db.HistoryQualificationOfStaffs.Attach(historyQualificationOfStaff);
                db.Entry(historyQualificationOfStaff).Property(x => x.Hidden).IsModified = true;
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

        public bool Edit(HistoryQualificationOfStaff Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.HistoryQualificationOfStaffs.Attach(Current);
                db.Entry(Current).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
            catch 
            {
                return Success = false;
            }
            return Success;
        }

        public HistoryQualificationOfStaff Get(int ID)
        {
            TrainingContext db = new TrainingContext();
          return  db.HistoryQualificationOfStaffs.SingleOrDefault(x => x.HistoryQualificationOfStaffId == ID);
        }

        public IQueryable<HistoryQualificationOfStaff> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.HistoryQualificationOfStaffs select item;
        }
    }
}
