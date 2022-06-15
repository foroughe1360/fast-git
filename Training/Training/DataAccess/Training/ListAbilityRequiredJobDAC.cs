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
    public class ListAbilityRequiredJobDAC : IListAbilityRequiredJobRepository
    {
        public int Add(ListAbilityRequiredJob Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListAbilityRequiredJobs.Add(Current);
            db.SaveChanges();
            return Current.ListAbilityRequiredJobId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listAbilityRequiredJob = new ListAbilityRequiredJob() { ListAbilityRequiredJobId = ID, Hidden = true };
                db.ListAbilityRequiredJobs.Attach(listAbilityRequiredJob);
                db.Entry(listAbilityRequiredJob).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch 
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(ListAbilityRequiredJob Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListAbilityRequiredJobs.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
        public ListAbilityRequiredJob Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListAbilityRequiredJobs.SingleOrDefault(x => x.ListAbilityRequiredJobId == ID);
        }
        public ListAbilityRequiredJob GetListAbilityRequiredJob(int inventoryjobsid, int abilityrequiredjobid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListAbilityRequiredJobs.SingleOrDefault(x => x.InventoryjobsId == inventoryjobsid && x.AbilityRequiredJobId == abilityrequiredjobid && x.Hidden == false);
        }
        public IQueryable<ListAbilityRequiredJob> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListAbilityRequiredJobs select item;
        }
        public IQueryable<ListAbilityRequiredJobEntity> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.TableInterfaceId == (int)TableInterfaceEntity.TableInterface.AbilityRequiredJob)
                 join listabilityrequiredjobs in db.ListAbilityRequiredJobs.Where(a => a.InventoryjobsId == ID && a.Hidden==false) on tableinterfacevalues.TableInterfaceValueId equals listabilityrequiredjobs.AbilityRequiredJobId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListAbilityRequiredJobEntity
                 {
                     AbilityRequiredJobId = tableinterfacevalues.TableInterfaceValueId,
                     InventoryjobsId = (temp.InventoryjobsId == null ? 0 : temp.InventoryjobsId),
                     ListAbilityRequiredJobId = (temp.ListAbilityRequiredJobId == null ? 0 : temp.ListAbilityRequiredJobId),
                     ListAbilityRequiredJobName = tableinterfacevalues.TableValue,
                     ListAbilityRequiredJobState = (temp == null ? false : true)
                 });
        }
    }
}
