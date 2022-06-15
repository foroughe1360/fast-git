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
    public class JobGroupDAC : IJobGroupRepository
    {
        public int Add(JobGroup Current)
        {
            TrainingContext db = new TrainingContext();
            db.JobGroups.Add(Current);
            db.SaveChanges();
            return Current.JobGroupId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var jobgroup = new JobGroup() { JobGroupId = ID, Hidden = true };
                db.JobGroups.Attach(jobgroup);
                db.Entry(jobgroup).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(JobGroup Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.JobGroups.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.JobGroupName).IsModified = true;
                db.Entry(Current).Property(x => x.PonitJobGroup).IsModified = true;
                db.Entry(Current).Property(x => x.GroupNumber).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
        public JobGroup Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.JobGroups.SingleOrDefault(x => x.JobGroupId == ID);
        }
        public IQueryable<JobGroup> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.JobGroups.Where(a => a.Hidden==false) select item;
        }
    }
}
