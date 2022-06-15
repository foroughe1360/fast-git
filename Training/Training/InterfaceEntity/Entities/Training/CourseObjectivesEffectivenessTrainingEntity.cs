using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
  public  class CourseObjectivesEffectivenessTrainingEntity : CourseObjectivesEffectivenessTraining
    {

        public string CourseObjectiveName { get; set; }
        public CourseObjectivesEffectivenessTrainingEntity() { }
        public CourseObjectivesEffectivenessTrainingEntity(int effectivenesstrainingid, int courseobjectiveid , int amountaccesspurposeid)
        {
            EffectivenessTrainingId = effectivenesstrainingid;
            CourseObjectiveId = courseobjectiveid;
            AmountAccessPurposeId = amountaccesspurposeid;
        }
    }
}
