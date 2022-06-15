using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DataAccess.BasicInformation
{
    public class AbsenceCountDAC : IAbsenceCountRepository
    {
        public int Add(AbsenceCount Current)
        {
            TrainingContext db = new TrainingContext();
            db.AbsenceCounts.Add(Current);
            db.SaveChanges();
            return Current.AbsenceCountId;
        }

        public bool Delete(int ID)
        {

            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var absencecount = new AbsenceCount() { AbsenceCountId = ID, Hidden = true };
                db.AbsenceCounts.Attach(absencecount);
                db.Entry(absencecount).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(AbsenceCount Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.AbsenceCounts.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.MaxAbsenceCount).IsModified = true;
                db.Entry(Current).Property(x => x.AbsenceCountDate).IsModified = true;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Success = false;
            }
            return Success;
        }

        public AbsenceCount Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.AbsenceCounts.SingleOrDefault(x => x.AbsenceCountId == ID);
        }

        public IQueryable<AbsenceCount> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.AbsenceCounts.Where(a => a.Hidden==false) select item;
        }
    }
}
