using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;

namespace Bussiness
{
    public class FileRepositoryProvider : IFileRepositoryProvider
    {
        private FileRepositoryDAC _FileRepositoryDAC;

        public FileRepositoryProvider()
        {
            _FileRepositoryDAC = new FileRepositoryDAC();
        }

        public int Add(FileRepositoryEntity Current)
        {
            General _General = new General();
            FileRepository _FileRepository = new FileRepository(Current.ContentId,Current.FileName, Current.ContentType, Current.ContentLength, Current.FileFormId);
            return _FileRepositoryDAC.Add(_FileRepository);
        }

        public bool Delete(int ID)
        {
            return _FileRepositoryDAC.Delete(ID);
        }

        public int Delete(int contentid, int fileformid)
        {
            return _FileRepositoryDAC.Delete(contentid, fileformid);
        }

        public bool Edit(FileRepositoryEntity Current)
        {
            FileRepository _FileRepository = new FileRepository();
            _FileRepository.FileRepositoryId = Current.FileRepositoryId;
            _FileRepository.TimeLastModified = DateTime.Now;
            _FileRepository.ContentId = Current.ContentId;
            _FileRepository.FileName = Current.FileName;
            _FileRepository.ContentType = Current.ContentType;
            _FileRepository.ContentLength = Current.ContentLength;
            _FileRepository.FileFormId = Current.FileFormId;
            return _FileRepositoryDAC.Edit(_FileRepository);
        }

        public FileRepositoryEntity Get(int ID)
        {
            FileRepositoryEntity _FileRepositoryEntity = new FileRepositoryEntity();
            var q = _FileRepositoryDAC.Get(ID);
            _FileRepositoryEntity.FileRepositoryId = q.FileRepositoryId;
            _FileRepositoryEntity.ContentId = q.ContentId;
            _FileRepositoryEntity.FileName = q.FileName;
            _FileRepositoryEntity.ContentType = q.ContentType;
            _FileRepositoryEntity.ContentLength = q.ContentLength;
            _FileRepositoryEntity.FileFormId = q.FileFormId;
            return _FileRepositoryEntity;
        }

        public FileRepositoryEntity Get(int contentid, int fileformid)
        {
            FileRepositoryEntity _FileRepositoryEntity = new FileRepositoryEntity();
            var q = _FileRepositoryDAC.Get(contentid, fileformid);
            if (q != null)
            {
                _FileRepositoryEntity.FileRepositoryId = q.FileRepositoryId;
                _FileRepositoryEntity.ContentId = q.ContentId;
                _FileRepositoryEntity.FileName = q.FileName;
                _FileRepositoryEntity.ContentType = q.ContentType;
                _FileRepositoryEntity.ContentLength = q.ContentLength;
                _FileRepositoryEntity.FileFormId = q.FileFormId;
            }
            else
                _FileRepositoryEntity = null;
            return _FileRepositoryEntity;
        }

        public IQueryable<FileRepositoryEntity> GetAll()
        {
            return _FileRepositoryDAC.GetAllFileRepository();
        }
        
    }
}
