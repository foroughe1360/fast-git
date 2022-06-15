using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DetialHistoryTrainingUploadPage
    {
        public int DetialHistoryTrainingUploadPageId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int HistoryTrainingUploadPageId { get; set; }
        public int CodingTrainingPageId { get; set; }
        public bool Hidden { get; set; }
        public DetialHistoryTrainingUploadPage()
        {

        }

        public DetialHistoryTrainingUploadPage(int historytraininguploadpageid, int codingtrainingpageid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            HistoryTrainingUploadPageId = historytraininguploadpageid;
            CodingTrainingPageId = codingtrainingpageid;
            Hidden = false;
        }
    }
}
