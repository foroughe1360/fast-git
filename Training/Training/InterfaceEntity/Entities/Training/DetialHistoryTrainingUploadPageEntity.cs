using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace InterfaceEntity
{
    public class DetialHistoryTrainingUploadPageEntity : DetialHistoryTrainingUploadPage
    {
        public string TitleCodingTrainingPage { get; set; }

        public DetialHistoryTrainingUploadPageEntity()
        {

        }

        public DetialHistoryTrainingUploadPageEntity(int historytraininguploadpageid, int codingtrainingpageid) 
            :base(historytraininguploadpageid,codingtrainingpageid)
        {

        }
    }
}
