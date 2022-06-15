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
    public class AssessorDAC : IAssessorRepository
    {
        public int Add(Assessor Current)
        {
            TrainingContext db = new TrainingContext();
            db.Assessors.Add(Current);
            db.SaveChanges();
            return Current.AssessorId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var assessor = new Assessor() { AssessorId = ID, Hidden = true };
                db.Assessors.Attach(assessor);
                db.Entry(assessor).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Assessor Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Assessors.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.UserId).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Assessor Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Assessors.SingleOrDefault(x => x.AssessorId == ID);
        }

        public IQueryable<Assessor> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Assessors select item;
        }

        public IQueryable<AssessorEntity> GetAllAssessor()
        {
            TrainingContext db = new TrainingContext();
            return
                (from assessors in db.Assessors.Where(a => a.Hidden == false)
                 join users in db.Users on assessors.UserId equals users.UserId
                 select new AssessorEntity
                 {
                     AssessorId = assessors.AssessorId,
                     UserId = assessors.UserId,
                     UserName = users.FirstName + " " + users.LastName
                 });
        }
    }
}
