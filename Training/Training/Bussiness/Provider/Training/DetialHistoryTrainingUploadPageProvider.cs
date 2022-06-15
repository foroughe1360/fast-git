using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess.Training;
using DomainModel.Models;

namespace Bussiness.Provider
{
    public class DetialHistoryTrainingUploadPageProvider : IDetialHistoryTrainingUploadPageProvider
    {
        private DetialHistoryTrainingUploadPageDAC _DetialHistoryTrainingUploadPageDAC;
        public DetialHistoryTrainingUploadPageProvider()
        {
            _DetialHistoryTrainingUploadPageDAC = new DetialHistoryTrainingUploadPageDAC();        
        }
        public int Add(DetialHistoryTrainingUploadPageEntity Current)
        {
            DetialHistoryTrainingUploadPage _DetialHistoryTrainingUploadPage = new DetialHistoryTrainingUploadPage
                (Current.HistoryTrainingUploadPageId, Current.CodingTrainingPageId);
            return _DetialHistoryTrainingUploadPageDAC.Add(_DetialHistoryTrainingUploadPage);
        }

        public bool Delete(int ID)
        {
            return _DetialHistoryTrainingUploadPageDAC.Delete(ID);
        }

        public bool Edit(DetialHistoryTrainingUploadPageEntity Current)
        {
            DetialHistoryTrainingUploadPage _DetialHistoryTrainingUploadPage = new DetialHistoryTrainingUploadPage();
            _DetialHistoryTrainingUploadPage.DetialHistoryTrainingUploadPageId = Current.DetialHistoryTrainingUploadPageId;
            _DetialHistoryTrainingUploadPage.TimeLastModified = DateTime.Now;
            _DetialHistoryTrainingUploadPage.HistoryTrainingUploadPageId = Current.HistoryTrainingUploadPageId;
            _DetialHistoryTrainingUploadPage.CodingTrainingPageId = Current.CodingTrainingPageId;
            return _DetialHistoryTrainingUploadPageDAC.Edit(_DetialHistoryTrainingUploadPage);
        }

        public DetialHistoryTrainingUploadPageEntity Get(int ID)
        {
            DetialHistoryTrainingUploadPageEntity _DetialHistoryTrainingUploadPageEntity = new DetialHistoryTrainingUploadPageEntity();
            var q = _DetialHistoryTrainingUploadPageDAC.Get(ID);
            if (q != null)
            {
                _DetialHistoryTrainingUploadPageEntity.DetialHistoryTrainingUploadPageId = q.DetialHistoryTrainingUploadPageId;
                _DetialHistoryTrainingUploadPageEntity.HistoryTrainingUploadPageId = q.HistoryTrainingUploadPageId;
                _DetialHistoryTrainingUploadPageEntity.CodingTrainingPageId = q.CodingTrainingPageId;
            }
            else
            {
                _DetialHistoryTrainingUploadPageEntity = null;
            }
            return _DetialHistoryTrainingUploadPageEntity;
        }

        public IQueryable<DetialHistoryTrainingUploadPageEntity> GetAll()
        {
            return (IQueryable < DetialHistoryTrainingUploadPageEntity > )_DetialHistoryTrainingUploadPageDAC.GetAll();
        }

        public IQueryable<DetialHistoryTrainingUploadPageEntity> GetAll(int historytraininguploadpageid)
        {
            return _DetialHistoryTrainingUploadPageDAC.GetAllDetialHistoryTrainingUploadPage(historytraininguploadpageid);
        }
    }
}
