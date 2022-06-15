using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class OfferTrainingForJob
    {
        public int OfferTrainingForJobId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int OfferTrainingForJobDateId { get; set; }
        public int SectionId { get; set; }
        public int PostGroupId { get; set; }
        public DateTime DateNeeds { get; set; }
        public bool Hidden { get; set; }
       
        public OfferTrainingForJob()
        {
            
        }

        public OfferTrainingForJob(int offertrainingforjobdateid,int sectionid,int postgroupId, DateTime dateneeds)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            OfferTrainingForJobDateId = offertrainingforjobdateid;
            SectionId = sectionid;
            PostGroupId = postgroupId;
            DateNeeds = dateneeds;
            
        }
    }
}
