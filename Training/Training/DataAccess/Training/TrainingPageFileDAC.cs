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
    public class TrainingPageFileDAC : ITrainingPageFileRepository
    {
        public int Add(TrainingPageFile Current)
        {
            TrainingContext db = new TrainingContext();
            db.TrainingPageFiles.Add(Current);
            db.SaveChanges();
            return Current.TrainingPageFileId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var trainingpagefile = new TrainingPageFile() { TrainingPageFileId = ID, Hidden = true };
                db.TrainingPageFiles.Attach(trainingpagefile);
                db.Entry(trainingpagefile).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TrainingPageFile Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TrainingPageFiles.Attach(Current);

                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.FileScan).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingPageFileDesc).IsModified = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Success = false;
            }
            return Success;
        }

        public TrainingPageFile Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TrainingPageFiles.SingleOrDefault(x => x.TrainingPageFileId == ID);
        }

        public IQueryable<TrainingPageFile> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TrainingPageFiles select item;
        }

        public IQueryable<TrainingPageFileEntity> GetAll(int detialhistorytraininguploadpageid)
        {
            TrainingContext db = new TrainingContext();
            return from trainingpagefiles in db.TrainingPageFiles.Where(a => a.Hidden == false && a.DetialHistoryTrainingUploadPageId == detialhistorytraininguploadpageid)
                   select new TrainingPageFileEntity
                   {
                       TimeCreated = trainingpagefiles.TimeCreated,
                       TrainingPageFileId = trainingpagefiles.TrainingPageFileId,
                       DetialHistoryTrainingUploadPageId = trainingpagefiles.DetialHistoryTrainingUploadPageId,
                       FileScan  = trainingpagefiles.FileScan,
                       TrainingPageFileDesc = trainingpagefiles.TrainingPageFileDesc
                   };
        }
    }
}
