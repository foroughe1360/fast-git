using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class TablesRelatedAssessmentOfTrainingServiceEntity : TablesRelatedAssessmentOfTrainingService
    {
        public string AOTSI { get; set; }
        public TablesRelatedAssessmentOfTrainingServiceEntity() { }
        public TablesRelatedAssessmentOfTrainingServiceEntity
            (int assessmentoftrainingserviceinformationid, int assessmentoftrainingserviceid, string value)
            :base(assessmentoftrainingserviceinformationid, assessmentoftrainingserviceid,value)
        {
        }
    }
}
