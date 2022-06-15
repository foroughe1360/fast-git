using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;

namespace DataAccess
{
    public class CompetencyTestingDAC : ICompetencyTestingRepository
    {
        public int Add(CompetencyTesting Current)
        {
            TrainingContext db = new TrainingContext();
            db.CompetencyTestings.Add(Current);
            db.SaveChanges();
            return Current.CompetencyTestingId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var competencyTesting = new CompetencyTesting() {CompetencyTestingId  = ID, Hidden = true };
                db.CompetencyTestings.Attach(competencyTesting);
                db.Entry(competencyTesting).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();

                //TrainingContext db = new TrainingContext();
                //var accessmenuUser = db.AccessMenuUsers.SingleOrDefault(x => x.AccessMenuUserId == ID);
                //db.AccessMenuUsers.Remove(accessmenuUser);
                //db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(CompetencyTesting Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.CompetencyTestings.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public CompetencyTesting Get(int ID)
        {
            TrainingContext db = new TrainingContext();
           return db.CompetencyTestings.SingleOrDefault(x => x.CompetencyTestingId == ID);
        }

        public IQueryable<CompetencyTesting> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.CompetencyTestings select item;
        }
    }
}
