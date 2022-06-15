using DataAccess.InfraStructre.AccessAndLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Models;

namespace DataAccess
{
    public class CodingTrainingPageDAC : ICodingTrainingPageRepository
    {
        public int Add(CodingTrainingPage Current)
        {
            TrainingContext db = new TrainingContext();
            db.CodingTrainingPages.Add(Current);
            db.SaveChanges();
            return Current.CodingTrainingPageId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var codingtrainingpage = new CodingTrainingPage() { CodingTrainingPageId = ID, Hidden = true };
                db.CodingTrainingPages.Attach(codingtrainingpage);
                db.Entry(codingtrainingpage).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(CodingTrainingPage Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.CodingTrainingPages.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Title).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingPageCode).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public CodingTrainingPage Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.CodingTrainingPages.SingleOrDefault(x => x.CodingTrainingPageId == ID);
        }

        public IQueryable<CodingTrainingPage> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.CodingTrainingPages select item;
        }
    }
}
