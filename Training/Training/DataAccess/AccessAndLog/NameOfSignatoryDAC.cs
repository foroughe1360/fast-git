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
    public class NameOfSignatoryDAC : INameOfSignatoryRepository
    {
        public int Add(NameOfSignatory Current)
        {
            TrainingContext db = new TrainingContext();
            db.NameOfSignatories.Add(Current);
            db.SaveChanges();
            return Current.NameOfSignatoryId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var nameofsignatory = new NameOfSignatory() { NameOfSignatoryId = ID, Hidden = true };
                db.NameOfSignatories.Attach(nameofsignatory);
                db.Entry(nameofsignatory).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(NameOfSignatory Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.NameOfSignatories.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.SideSignatoryId).IsModified = true;
                db.Entry(Current).Property(x => x.FirstName).IsModified = true;
                db.Entry(Current).Property(x => x.LastName).IsModified = true;
                db.Entry(Current).Property(x => x.NameOfSignatoryDate).IsModified = true;
                db.Entry(Current).Property(x => x. State).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public NameOfSignatory Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.NameOfSignatories.SingleOrDefault(x => x.NameOfSignatoryId == ID);
        }

        public IQueryable<NameOfSignatory> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.NameOfSignatories select item;
        }

        public IQueryable<NameOfSignatoryEntity> GetAllNameOfSignatory(int sidesignatoryid)
        {
            TrainingContext db = new TrainingContext();
            return
                from nameofsignatories in db.NameOfSignatories.Where(a => a.SideSignatoryId == sidesignatoryid && a.Hidden == false)
                join sidesignatories in db.SideSignatories on nameofsignatories.SideSignatoryId equals sidesignatories.SideSignatoryId
                select new NameOfSignatoryEntity
                {
                    NameOfSignatoryId = nameofsignatories.NameOfSignatoryId,
                    SideSignatoryId = nameofsignatories.SideSignatoryId,
                    FirstName = nameofsignatories.FirstName,
                    LastName = nameofsignatories.LastName,
                    NameOfSignatoryDate = nameofsignatories.NameOfSignatoryDate,
                    StateStr = (nameofsignatories.State == true?"فعال":"غیرفعال"),
                    Specifications = nameofsignatories.FirstName+" "+nameofsignatories.LastName
                };
        }

        public IQueryable<NameOfSignatoryEntity> GetListNameOfSignatory()
        {
            TrainingContext db = new TrainingContext();

            NameOfSignatory _NameOfSignatory = new NameOfSignatory();
            var qqq = from s in db.NameOfSignatories.Where(a => a.Hidden == false)
                    group s by s.SideSignatoryId into g
                    select new { SideSignatoryId = g.Key };
            
            return
                (from list in qqq
                 join nameofsignatories in db.NameOfSignatories.Where(a => a.State) on list.SideSignatoryId equals nameofsignatories.SideSignatoryId
                 join sidesignatories in db.SideSignatories on nameofsignatories.SideSignatoryId equals sidesignatories.SideSignatoryId
                 select new NameOfSignatoryEntity
                 {
                     NameOfSignatoryId = nameofsignatories.NameOfSignatoryId,
                     SideSignatoryId = nameofsignatories.SideSignatoryId,
                     FirstName = nameofsignatories.FirstName,
                     LastName = nameofsignatories.LastName,
                     NameOfSignatoryDate = nameofsignatories.NameOfSignatoryDate,
                     State = nameofsignatories.State,
                     Specifications = nameofsignatories.FirstName + " " + nameofsignatories.LastName,
                     SideSignatoryCode = sidesignatories.SideSignatoryCode
                 });
        }
    }
}
