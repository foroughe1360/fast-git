using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class CriterionAssessmentOfTrainingServiceEntity : CriterionAssessmentOfTrainingService
    {
        public int MaxScore { get; set; }
        public string TypeOfEvaluationName { get; set; }

        public CriterionAssessmentOfTrainingServiceEntity() { }
        public CriterionAssessmentOfTrainingServiceEntity(int assessmentoftrainingserviceid, int typeofevaluationid,
            int earnpoints, string description)
        {
            AssessmentOfTrainingServiceId = assessmentoftrainingserviceid;
            TypeOfEvaluationId = typeofevaluationid;
            Earnpoints = earnpoints;
            Description = description;
        }
    }
}
