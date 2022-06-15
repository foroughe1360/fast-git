using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DetailPlacementTabJobTraining
    {
        public int DetailPlacementTabJobTrainingId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int PlacementTabJobTrainingId { get; set; }
        public string Title { get; set; }
        public string FinalComment { get; set; }
        public Double NumberOfHours { get; set; }
        public int OJTLevelId { get; set; }
        public bool Hidden { get; set; }


        public DetailPlacementTabJobTraining()
        {
        }

        public DetailPlacementTabJobTraining(int placementtabjobtrainingid, string title, string finalcomment, double numberofhours,int ojtlevelId)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            PlacementTabJobTrainingId = placementtabjobtrainingid;
            Title = title;
            FinalComment = finalcomment;
            NumberOfHours = numberofhours;
            OJTLevelId = ojtlevelId;
            Hidden = false;
        }
    }
}
