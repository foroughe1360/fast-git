using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class HistoryTrainingUploadPage
    {
        public int HistoryTrainingUploadPageId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string HTUPDescripption { get; set; }
        public DateTime HistoryTrainingUploadPageDate { get; set; }
        public bool Hidden { get; set; }

        public HistoryTrainingUploadPage()
        {

        }

        public HistoryTrainingUploadPage(string htupdescripption,DateTime historytraininguploadpagedate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            HTUPDescripption = htupdescripption;
            HistoryTrainingUploadPageDate = historytraininguploadpagedate;
            Hidden = false;
        }

    }
}
