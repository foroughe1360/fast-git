using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TrainingPageFile
    {
        public int TrainingPageFileId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DetialHistoryTrainingUploadPageId { get; set; }
        public Byte[] FileScan { get; set; }
        public string TrainingPageFileDesc { get; set; }
        public bool Hidden { get; set; }

        public TrainingPageFile()
        {

        }

        public TrainingPageFile(int detialhistorytraininguploadpageid ,string trainingpagefiledesc, Byte[] filescan)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DetialHistoryTrainingUploadPageId = detialhistorytraininguploadpageid;
            TrainingPageFileDesc = trainingpagefiledesc;
            FileScan = filescan;
            Hidden = false;
        }
    }
}
