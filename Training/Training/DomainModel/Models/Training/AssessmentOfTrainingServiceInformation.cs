using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class AssessmentOfTrainingServiceInformation
    {
        public int AssessmentOfTrainingServiceInformationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Name { get; set; }
        public bool Hidden { get; set; }

        public AssessmentOfTrainingServiceInformation()
        {
            
        }

        public AssessmentOfTrainingServiceInformation(string name)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Name = name;
            Hidden = false;
        }
    }
}
