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
    public class MasterRateItDAC : IMasterRateItRepository
    {
        public int Add(MasterRateIt Current)
        {
            TrainingContext db = new TrainingContext();
            db.MasterRateIts.Add(Current);
            db.SaveChanges();
            return Current.MasterRateItId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var masterrateit = new MasterRateIt() { MasterRateItId = ID, Hidden = true };
                db.MasterRateIts.Attach(masterrateit);
                db.Entry(masterrateit).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(MasterRateIt Current)
        {
            bool Success = true;
            try
            { 
                TrainingContext db = new TrainingContext();
                db.MasterRateIts.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TypesRateItId).IsModified = true;
                db.Entry(Current).Property(x => x.Name).IsModified = true;
                db.Entry(Current).Property(x => x.MinRating).IsModified = true;
                db.Entry(Current).Property(x => x.MaxRating).IsModified = true;
                db.Entry(Current).Property(x => x.Parent).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public MasterRateIt Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.MasterRateIts.SingleOrDefault(x => x.MasterRateItId == ID);
        }

        public IQueryable<MasterRateIt> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.MasterRateIts select item;
        }

        public IQueryable<MasterRateItEntity> GetAllMasterRateIt()
        {
            TrainingContext db = new TrainingContext();
            return
                (from masterrateits in db.MasterRateIts.Where(a => a.Hidden==false)
                 join tableinterfacevalues in db.TableInterfaceValues on masterrateits.TypesRateItId equals tableinterfacevalues.TableInterfaceValueId
                 select new MasterRateItEntity
                 {
                     MasterRateItId = masterrateits.MasterRateItId,
                     Name = masterrateits.Name,
                     MinRating = masterrateits.MinRating,
                     MaxRating  =masterrateits.MaxRating,
                     Parent = masterrateits.Parent,
                     TypesRateItId = masterrateits.TypesRateItId,
                     TypesRateItName = tableinterfacevalues.TableValue
                 });

        }
    }
}
