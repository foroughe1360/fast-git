using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class PlacementTabJobTrainingDateDAC : IPlacementTabJobTrainingDateRepository
    {
        public int Add(PlacementTabJobTrainingDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.PlacementTabJobTrainingDates.Add(Current);
            db.SaveChanges();
            return Current.PlacementTabJobTrainingDateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var placementtabjobtrainingdate = new PlacementTabJobTrainingDate() { PlacementTabJobTrainingDateId = ID, Hidden = true };
                db.PlacementTabJobTrainingDates.Attach(placementtabjobtrainingdate);
                db.Entry(placementtabjobtrainingdate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result; throw new NotImplementedException();
        }

        public bool Edit(PlacementTabJobTrainingDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.PlacementTabJobTrainingDates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.PTJTDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public PlacementTabJobTrainingDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.PlacementTabJobTrainingDates.SingleOrDefault(x => x.PlacementTabJobTrainingDateId == ID);
        }

        public IQueryable<PlacementTabJobTrainingDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.PlacementTabJobTrainingDates select item;
        }

        public IQueryable<PlacementTabJobTrainingDateEntity> GetAllPlacementTabJobTrainingDate()
        {
            TrainingContext db = new TrainingContext();
            return
                (from placementtabjobtrainingdates in db.PlacementTabJobTrainingDates.Where(a => a.Hidden == false)
                 select new PlacementTabJobTrainingDateEntity
                 {
                     PlacementTabJobTrainingDateId = placementtabjobtrainingdates.PlacementTabJobTrainingDateId,
                     Description = placementtabjobtrainingdates.Description,
                     PTJTDate = placementtabjobtrainingdates.PTJTDate
                 });
        }
    }
}
