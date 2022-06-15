using Bussiness.InfraStructre.Traning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;

namespace Bussiness.Provider.Training
{
    public class TrainingPageFileProvider : ITrainingPageFileProvider
    {
        private TrainingPageFileDAC _TrainingPageFileDAC;
        public TrainingPageFileProvider()
        {
            _TrainingPageFileDAC = new TrainingPageFileDAC();
        }
        public int Add(TrainingPageFileEntity Current)
        {
            TrainingPageFile _TrainingPageFile = new TrainingPageFile(Current.DetialHistoryTrainingUploadPageId,Current.TrainingPageFileDesc,Current.FileScan);
            return _TrainingPageFileDAC.Add(_TrainingPageFile);
        }

        public bool Delete(int ID)
        {
            return _TrainingPageFileDAC.Delete(ID);
        }

        public bool Edit(TrainingPageFileEntity Current)
        {
            TrainingPageFile _TrainingPageFile = new TrainingPageFile();
            _TrainingPageFile.TrainingPageFileId = Current.TrainingPageFileId;
            _TrainingPageFile.TimeLastModified = DateTime.Now;
            _TrainingPageFile.FileScan = Current.FileScan;
            _TrainingPageFile.TrainingPageFileDesc = Current.TrainingPageFileDesc;
            return _TrainingPageFileDAC.Edit(_TrainingPageFile);
        }

        public TrainingPageFileEntity Get(int ID)
        {
            TrainingPageFileEntity _TrainingPageFileEntity = new TrainingPageFileEntity();
            var q = _TrainingPageFileDAC.Get(ID);
            _TrainingPageFileEntity.TrainingPageFileId = q.TrainingPageFileId;
            _TrainingPageFileEntity.DetialHistoryTrainingUploadPageId = q.DetialHistoryTrainingUploadPageId;
            _TrainingPageFileEntity.FileScan = q.FileScan;
            _TrainingPageFileEntity.TrainingPageFileDesc = q.TrainingPageFileDesc;
            return _TrainingPageFileEntity;
        }

        public IQueryable<TrainingPageFileEntity> GetAll()
        {
            return (IQueryable<TrainingPageFileEntity>)_TrainingPageFileDAC.GetAll();
        }

        public IQueryable<TrainingPageFileEntity> GetAll(int detialhistorytraininguploadpageid)
        {
            return _TrainingPageFileDAC.GetAll(detialhistorytraininguploadpageid);
        }
    }
}
