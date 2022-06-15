using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class EffectivenessTrainingEntity : EffectivenessTraining
    {

        public string EffectivenessOfCoursesName { get; set; }

        public int EmployemeJobId { get; set; }
        public int PostGroupId { get; set; }
        public string PostGroupName { get; set; }

        public string SupervisorName { get; set; }

        public EffectivenessTrainingEntity() { }

        public EffectivenessTrainingEntity(int courseregistrationid, DateTime effectivenesstrainingdate, int supervisorid, string correctiveactiondescription, bool correctiveaction)
            : base(courseregistrationid, effectivenesstrainingdate, supervisorid, correctiveactiondescription, correctiveaction)
        {
        }
    }
}
