using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DataAccess.Training
{
    public class HistoryTrainingUploadPageDAC : IHistoryTrainingUploadPageRepository
    {
        public int Add(HistoryTrainingUploadPage Current)
        {
            TrainingContext db = new TrainingContext();
            db.HistoryTrainingUploadPages.Add(Current);
            db.SaveChanges();
            return Current.HistoryTrainingUploadPageId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var historytraininguploadpage = new HistoryTrainingUploadPage() { HistoryTrainingUploadPageId = ID, Hidden = true };
                db.HistoryTrainingUploadPages.Attach(historytraininguploadpage);
                db.Entry(historytraininguploadpage).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(HistoryTrainingUploadPage Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.HistoryTrainingUploadPages.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.HTUPDescripption).IsModified = true;
                db.Entry(Current).Property(x => x.HistoryTrainingUploadPageDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public HistoryTrainingUploadPage Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.HistoryTrainingUploadPages.SingleOrDefault(x => x.HistoryTrainingUploadPageId == ID);
        }

        public IQueryable<HistoryTrainingUploadPage> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.HistoryTrainingUploadPages.Where(a => a.Hidden == false) select item;
        }
    }
}
