using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
  public  class AssessmentOfTrainingServiceInformationEntity : AssessmentOfTrainingServiceInformation
    {
        public enum AssessmentOfTrainingServiceInformation:int
        {
            Phone = 1,
            Mobile = 2,
            Fax = 3,
            Email = 4
        }
        public AssessmentOfTrainingServiceInformationEntity() { }
        public AssessmentOfTrainingServiceInformationEntity(string name)
        {
            Name = name;
        }
    }
}
