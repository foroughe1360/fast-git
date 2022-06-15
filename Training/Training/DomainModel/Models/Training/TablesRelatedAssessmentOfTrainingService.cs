using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TablesRelatedAssessmentOfTrainingService
    {
        public int TablesRelatedAssessmentOfTrainingServiceId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int AssessmentOfTrainingServiceInformationId { get; set; }
        public int AssessmentOfTrainingServiceId { get; set; }
        public string Value { get; set; }
        public bool Hidden { get; set; }

        public TablesRelatedAssessmentOfTrainingService()
        {
            
        }

        public TablesRelatedAssessmentOfTrainingService(int assessmentoftrainingserviceinformationid,int assessmentoftrainingserviceid,string value)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            AssessmentOfTrainingServiceInformationId = assessmentoftrainingserviceinformationid;
            AssessmentOfTrainingServiceId = assessmentoftrainingserviceid;
            Value = value;
            Hidden = false;
        }
    }
}
