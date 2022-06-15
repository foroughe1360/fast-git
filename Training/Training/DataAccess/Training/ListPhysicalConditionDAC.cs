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
    public class ListPhysicalConditionDAC : IListPhysicalConditionRepository
    {
        public int Add(ListPhysicalCondition Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListPhysicalConditions.Add(Current);
            db.SaveChanges();
            return Current.ListPhysicalConditionId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listPhysicalCondition = new ListPhysicalCondition() { ListPhysicalConditionId = ID, Hidden = true };
                db.ListPhysicalConditions.Attach(listPhysicalCondition);
                db.Entry(listPhysicalCondition).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListPhysicalCondition Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListPhysicalConditions.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListPhysicalCondition Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListPhysicalConditions.SingleOrDefault(x => x.ListPhysicalConditionId == ID);
        }

        public ListPhysicalCondition GetListPhysicalCondition(int inventoryjobsid, int physicalconditionsid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListPhysicalConditions.SingleOrDefault(x => x.InventoryjobsId == inventoryjobsid && x.PhysicalConditionsId == physicalconditionsid && x.Hidden == false);
        }

        public IQueryable<ListPhysicalCondition> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListPhysicalConditions select item;
        }

        public IQueryable<ListPhysicalConditionEntity> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.TableInterfaceId == 20)
                 join listcommunityorganizations in db.ListPhysicalConditions.Where(a => a.InventoryjobsId == ID && a.Hidden==false) on tableinterfacevalues.TableInterfaceValueId equals listcommunityorganizations.PhysicalConditionsId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListPhysicalConditionEntity
                 {
                     InventoryjobsId = (temp.InventoryjobsId == null ? 0 : temp.InventoryjobsId),
                     ListPhysicalConditionId = (temp.ListPhysicalConditionId == null ? 0 : temp.InventoryjobsId),
                     PhysicalConditionsId = tableinterfacevalues.TableInterfaceValueId,
                     PhysicalConditionsName = tableinterfacevalues.TableValue,
                     ListPhysicalConditionsState= (temp == null ? false : true)
                 });
        }

    }
}
    