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
    public class ListHealthConditionDAC : IListHealthConditionRepository
    {
        public int Add(ListHealthCondition Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListHealthConditions.Add(Current);
            db.SaveChanges();
            return Current.ListHealthConditionId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            try
            {
                TrainingContext db = new TrainingContext();
                var listHealthCondition = new ListHealthCondition() { ListHealthConditionId = ID, Hidden = true };
                db.ListHealthConditions.Attach(listHealthCondition);
                db.Entry(listHealthCondition).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListHealthCondition Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListHealthConditions.Attach(Current);
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListHealthCondition Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListHealthConditions.SingleOrDefault(x => x.ListHealthConditionId == ID);
        }

        public ListHealthCondition GetListHealthCondition(int inventoryjobsid, int healthconditionsid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListHealthConditions.SingleOrDefault(x => x.InventoryjobsId == inventoryjobsid && x.HealthConditionsId == healthconditionsid && x.Hidden == false);
        }

        public IQueryable<ListHealthCondition> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListHealthConditions select item;
        }

        public IQueryable<ListHealthConditionEntity> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.TableInterfaceId == 21 && a.Hidden== false)
                 join ListHealthConditions in db.ListHealthConditions.Where(a => a.InventoryjobsId == ID && a.Hidden==false) on tableinterfacevalues.TableInterfaceValueId equals ListHealthConditions.HealthConditionsId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListHealthConditionEntity
                 {
                     HealthConditionsId = tableinterfacevalues.TableInterfaceValueId,
                     InventoryjobsId = (temp.InventoryjobsId == null ? 0 : temp.InventoryjobsId),
                     ListHealthConditionId = (temp.ListHealthConditionId == null ? 0 : temp.ListHealthConditionId),
                     ListHealthConditionName = tableinterfacevalues.TableValue,
                     Description = (temp.Description == null ? "" : temp.Description),
                     ListHealthConditionState = (temp == null ? false : true)
                 });
        }
    }

}

