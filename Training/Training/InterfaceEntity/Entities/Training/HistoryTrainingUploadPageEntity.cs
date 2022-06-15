using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class HistoryTrainingUploadPageEntity : HistoryTrainingUploadPage
    {
        public DateTime HistoryTrainingUploadPageDateStr { get; set; }

        public HistoryTrainingUploadPageEntity()
        {

        }


        public HistoryTrainingUploadPageEntity(string htupdescripption, DateTime historytraininguploadpagedate) 
            :base(htupdescripption, historytraininguploadpagedate)
        {

        }
    }
}
