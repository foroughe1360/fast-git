using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess.Training;
using DomainModel.Models;

namespace Bussiness.Provider.Training
{
    public class HistoryTrainingUploadPageProvider : IHistoryTrainingUploadPageProvider
    {
        HistoryTrainingUploadPageDAC _HistoryTrainingUploadPageDAC;

        public HistoryTrainingUploadPageProvider()
        {
            _HistoryTrainingUploadPageDAC = new HistoryTrainingUploadPageDAC();
        }
        public int Add(HistoryTrainingUploadPageEntity Current)
        {
            General _General = new General();
            Current.HistoryTrainingUploadPageDate = _General.ShamsiToMiladi(Current.HistoryTrainingUploadPageDateStr);
            HistoryTrainingUploadPage _HistoryTrainingUploadPage = new HistoryTrainingUploadPage
                (Current.HTUPDescripption, Current.HistoryTrainingUploadPageDate);
            return _HistoryTrainingUploadPageDAC.Add(_HistoryTrainingUploadPage);
        }

        public bool Delete(int ID)
        {
            return _HistoryTrainingUploadPageDAC.Delete(ID);
        }

        public bool Edit(HistoryTrainingUploadPageEntity Current)
        {
            General _General = new General();
            HistoryTrainingUploadPage _HistoryTrainingUploadPage = new HistoryTrainingUploadPage();
           _HistoryTrainingUploadPage.HistoryTrainingUploadPageId = Current.HistoryTrainingUploadPageId;
           _HistoryTrainingUploadPage.TimeLastModified = DateTime.Now;
           _HistoryTrainingUploadPage.HTUPDescripption = Current.HTUPDescripption;
           _HistoryTrainingUploadPage.HistoryTrainingUploadPageDate = _General.ShamsiToMiladi(Current.HistoryTrainingUploadPageDateStr);
            return _HistoryTrainingUploadPageDAC.Edit(_HistoryTrainingUploadPage);
        }

        public HistoryTrainingUploadPageEntity Get(int ID)
        {
            HistoryTrainingUploadPageEntity _HistoryTrainingUploadPageEntity = new HistoryTrainingUploadPageEntity();
            var q = _HistoryTrainingUploadPageDAC.Get(ID);
            _HistoryTrainingUploadPageEntity.HistoryTrainingUploadPageId = q.HistoryTrainingUploadPageId;
            _HistoryTrainingUploadPageEntity.HTUPDescripption = q.HTUPDescripption;
            _HistoryTrainingUploadPageEntity.HistoryTrainingUploadPageDate = q.HistoryTrainingUploadPageDate;
            return _HistoryTrainingUploadPageEntity;
        }

        public IQueryable<HistoryTrainingUploadPageEntity> GetAll()
        {
            var q =  _HistoryTrainingUploadPageDAC.GetAll();
            return from list in q
                   select new HistoryTrainingUploadPageEntity
                   {
                       HistoryTrainingUploadPageId = list.HistoryTrainingUploadPageId,
                       HTUPDescripption = list.HTUPDescripption,
                       HistoryTrainingUploadPageDate = list.HistoryTrainingUploadPageDate
                   };
        }
    }
}
