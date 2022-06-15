using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OfferTrainingForEmployeme
    {
        public int OfferTrainingForEmployemeId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int OfferTrainingForEmployeeDateId { get; set; }
        public int SectionId { get; set; }
        public int PostGroupId { get; set; }
        public int EmployemeId { get; set; }
        public DateTime DateNeeds { get; set; }
        public bool Hidden { get; set; }

        public OfferTrainingForEmployeme()
        {

        }

        public OfferTrainingForEmployeme(int offertrainingforemployeedateid, int sectionid, int postgroupId, int employemeid,  DateTime dateneeds)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            OfferTrainingForEmployeeDateId = offertrainingforemployeedateid;
            SectionId = sectionid;
            PostGroupId = postgroupId;
            EmployemeId = employemeid;
            DateNeeds = dateneeds;
        }
    }

}
