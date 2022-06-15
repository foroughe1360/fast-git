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
    public class OJTLevelDAC : IOJTLevelRepository
    {
        public int Add(OJTLevel Current)
        {
            TrainingContext db = new TrainingContext();
            db.OJTLevels.Add(Current);
            db.SaveChanges();
            return Current.OJTLevelId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var ojtlevel = new OJTLevel() { OJTLevelId = ID, Hidden = true };
                db.OJTLevels.Attach(ojtlevel);
                db.Entry(ojtlevel).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(OJTLevel Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.OJTLevels.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.LevelNumber).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;

                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public OJTLevel Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.OJTLevels.SingleOrDefault(x => x.OJTLevelId == ID);
        }

        public IQueryable<OJTLevel> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.OJTLevels select item;
        }


        public IQueryable<OJTLevelEntity> GetAllOJTLevel()
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from ojtlevels in db.OJTLevels.Where(a => a.Hidden == false)
                 select new OJTLevelEntity
                 {
                     LevelNumber = ojtlevels.LevelNumber,
                     OJTLevelId = ojtlevels.OJTLevelId,
                     Description=ojtlevels.Description
                 });
            return _query;
        }

    }
}
