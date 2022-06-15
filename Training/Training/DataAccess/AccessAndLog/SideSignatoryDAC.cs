using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class SideSignatoryDAC : ISideSignatoryRepository
    {
        public int Add(SideSignatory Current)
        {
            TrainingContext db = new TrainingContext();
            db.SideSignatories.Add(Current);
            db.SaveChanges();
            return Current.SideSignatoryId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var sidesignatory = new SideSignatory() { SideSignatoryId = ID, Hidden = true };
                db.SideSignatories.Attach(sidesignatory);
                db.Entry(sidesignatory).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(SideSignatory Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.SideSignatories.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Title).IsModified = true;
                db.Entry(Current).Property(x => x.TitleEN).IsModified = true;
                db.Entry(Current).Property(x => x.SideSignatoryCode).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public SideSignatory Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.SideSignatories.SingleOrDefault(x => x.SideSignatoryId == ID);
        }

        public IQueryable<SideSignatory> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.SideSignatories select item;
        }

        public IQueryable<SideSignatoryEntity> GetAllSideSignatory()
        {
            TrainingContext db = new TrainingContext();
            return from sidesignatories in db.SideSignatories.Where(a => a.Hidden == false)
                   select new SideSignatoryEntity
                   {
                       SideSignatoryId = sidesignatories.SideSignatoryId,
                       Title = sidesignatories.Title,
                       TitleEN = sidesignatories.TitleEN,
                       SideSignatoryCode = sidesignatories.SideSignatoryCode
                   };
        }
    }
}
