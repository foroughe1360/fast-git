using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class EffectivenessTraining
    {
        public int EffectivenessTrainingId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int CourseRegistrationId { get; set; }
        public DateTime EffectivenessTrainingDate { get; set; }
        public int SupervisorId { get; set; }
        public string CorrectiveactionDescription { get; set; }
        public bool Correctiveaction { get; set; }
        public bool Hidden { get; set; }

        public EffectivenessTraining()
        {
            
        }

        public EffectivenessTraining(int courseregistrationid, DateTime effectivenesstrainingdate, int supervisorid, string correctiveactiondescription, bool correctiveaction)
        {
            CourseRegistrationId = courseregistrationid;
            EffectivenessTrainingDate = effectivenesstrainingdate;
            SupervisorId = supervisorid;
            CorrectiveactionDescription = correctiveactiondescription;
            Correctiveaction = correctiveaction;
        }
    }
}
