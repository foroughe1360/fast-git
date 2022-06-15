using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class CriterionAssessmentOfTrainingService
    {
        public int CriterionAssessmentOfTrainingServiceId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int AssessmentOfTrainingServiceId { get; set; }
        public int TypeOfEvaluationId { get; set; }
        public int Earnpoints { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }

        public CriterionAssessmentOfTrainingService()
        {
            
        }

        public CriterionAssessmentOfTrainingService(int assessmentoftrainingserviceid,int typeofevaluationid,
            int earnpoints,string description)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            AssessmentOfTrainingServiceId = assessmentoftrainingserviceid;
            TypeOfEvaluationId = typeofevaluationid;
            Earnpoints = earnpoints;
            Description = description;
            Hidden = false;
        }
    }
}
