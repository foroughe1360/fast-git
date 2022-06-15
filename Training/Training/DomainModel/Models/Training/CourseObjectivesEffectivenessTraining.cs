using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class CourseObjectivesEffectivenessTraining
    {
        public int CourseObjectivesEffectivenessTrainingId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int EffectivenessTrainingId { get; set; }
        public int CourseObjectiveId { get; set; }
        public int AmountAccessPurposeId { get; set; }
        public bool Hidden { get; set; }

        public CourseObjectivesEffectivenessTraining()
        {
            
        }

        public CourseObjectivesEffectivenessTraining(int effectivenesstrainingid,int courseobjectiveid,int amountaccesspurposeid)
        {
            EffectivenessTrainingId = effectivenesstrainingid;
            CourseObjectiveId = courseobjectiveid;
            AmountAccessPurposeId = amountaccesspurposeid;
        }
    }
}
