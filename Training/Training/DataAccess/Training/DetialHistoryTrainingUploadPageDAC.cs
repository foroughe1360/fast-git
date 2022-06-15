using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess.Training
{
    public class DetialHistoryTrainingUploadPageDAC : IDetialHistoryTrainingUploadPageRepository
    {
        public int Add(DetialHistoryTrainingUploadPage Current)
        {
            TrainingContext db = new TrainingContext();
            db.DetialHistoryTrainingUploadPages.Add(Current);
            db.SaveChanges();
            return Current.DetialHistoryTrainingUploadPageId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var detialhistorytraininguploadpage = new DetialHistoryTrainingUploadPage() { DetialHistoryTrainingUploadPageId = ID, Hidden = true };
                db.DetialHistoryTrainingUploadPages.Attach(detialhistorytraininguploadpage);
                db.Entry(detialhistorytraininguploadpage).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(DetialHistoryTrainingUploadPage Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DetialHistoryTrainingUploadPages.Attach(Current);

                db.Entry(Current).Property(x => x.DetialHistoryTrainingUploadPageId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.CodingTrainingPageId).IsModified = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Success = false;
            }
            return Success;
        }

        public DetialHistoryTrainingUploadPage Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DetialHistoryTrainingUploadPages.SingleOrDefault(x => x.DetialHistoryTrainingUploadPageId == ID);
        }

        public IQueryable<DetialHistoryTrainingUploadPage> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DetialHistoryTrainingUploadPages select item;
        }

        public IQueryable<DetialHistoryTrainingUploadPageEntity> GetAllDetialHistoryTrainingUploadPage(int historytraininguploadpageid)
        {
            TrainingContext db = new TrainingContext();
            return from detialhistorytraininguploadpages in db.DetialHistoryTrainingUploadPages.Where(a => a.Hidden == false && a.HistoryTrainingUploadPageId == historytraininguploadpageid)
                   join codingtrainingpages in db.CodingTrainingPages on detialhistorytraininguploadpages.CodingTrainingPageId equals codingtrainingpages.CodingTrainingPageId
                   select new DetialHistoryTrainingUploadPageEntity
                   {
                       DetialHistoryTrainingUploadPageId = detialhistorytraininguploadpages.DetialHistoryTrainingUploadPageId,
                       HistoryTrainingUploadPageId = detialhistorytraininguploadpages.HistoryTrainingUploadPageId,
                       CodingTrainingPageId = detialhistorytraininguploadpages.CodingTrainingPageId,
                       TitleCodingTrainingPage = codingtrainingpages.Title
                   };
        }
    }
}
