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
    public class FileRepositoryDAC : IFileRepositoryRepository
    {
        private TrainingContext db;

        public FileRepositoryDAC()
        {
            db = new TrainingContext();
        }

        public int Add(FileRepository Current)
        {
            db.FileRepositories.Add(Current);
            db.SaveChanges();
            return Current.FileRepositoryId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                var filerepository = new FileRepository() { FileRepositoryId = ID, Hidden = true };
                db.FileRepositories.Attach(filerepository);
                db.Entry(filerepository).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public int Delete(int contentid, int fileformid)
        {
            try
            {
                int ID = db.FileRepositories.FirstOrDefault(a => a.ContentId == contentid && a.FileFormId == fileformid).FileRepositoryId;
                db = new TrainingContext();
                var filerepository = new FileRepository() { FileRepositoryId = ID, ContentType = "",ContentLength = null,FileName = "" };
                //TrainingContext db1 = new TrainingContext();
                db.FileRepositories.Attach(filerepository);
                db.Entry(filerepository).Property(x => x.ContentType).IsModified = true;
                db.Entry(filerepository).Property(x => x.ContentLength).IsModified = true;
                db.Entry(filerepository).Property(x => x.FileName).IsModified = true;
                db.SaveChanges();
                return ID;
            }
            catch
            {
                return 0;
            }
        }

        public bool Edit(FileRepository Current)
        {
            bool Success = true;
            try
            {
                db = new TrainingContext();
                db.FileRepositories.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.ContentId).IsModified = true;
                db.Entry(Current).Property(x => x.FileName).IsModified = true;
                db.Entry(Current).Property(x => x.ContentType).IsModified = true;
                db.Entry(Current).Property(x => x.ContentLength).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public FileRepository Get(int ID)
        {
            return db.FileRepositories.SingleOrDefault(x => x.FileRepositoryId == ID);
        }

        public FileRepository Get(int contentid, int fileformid)
        {
            return db.FileRepositories.SingleOrDefault(x => x.ContentId == contentid && x.FileFormId == fileformid && x.Hidden==false);
        }

        public IQueryable<FileRepository> GetAll()
        {
            return from item in db.FileRepositories select item;
        }

        public IQueryable<FileRepositoryEntity> GetAllFileRepository()
        {
            return
                (from filerepositories in db.FileRepositories
                 join tableinterfacevalues in db.TableInterfaceValues on filerepositories.FileFormId equals tableinterfacevalues.TableInterfaceValueId
                 select new FileRepositoryEntity
                 {
                     FileRepositoryId=filerepositories.FileRepositoryId,
                     ContentId=filerepositories.ContentId,
                     FileName=filerepositories.FileName,
                     ContentType=filerepositories.ContentType,
                     ContentLength=filerepositories.ContentLength,
                     FileFormId=filerepositories.FileFormId,
                     fileformName=tableinterfacevalues.TableValue
                 });
        }
    }
}
