using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TrainingPageFileEntity : TrainingPageFile
    {
        public string ImageUrl { get; set; }
        public TrainingPageFileEntity()
        {

        }

        public TrainingPageFileEntity(int detialhistorytraininguploadpageid,string trainingpagefiledesc, Byte[] filescan)
            :base(detialhistorytraininguploadpageid, trainingpagefiledesc, filescan)
        {

        }
    }
}
