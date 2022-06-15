using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class AssessmentOfTrainingServiceEntity : AssessmentOfTrainingService
    {
        public string EducationName { get; set; }
        public string TypeOfCompanyName { get; set; }
        public string TypeOfInstitutionName { get; set; }
        public bool Real { get; set; }
        public bool Legal { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }


        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }

        public AssessmentOfTrainingServiceEntity() { }
        public AssessmentOfTrainingServiceEntity(string institutionname, string managingdirector, int typeofcompanyid,
            int typeofinstitutionid,string scopeoftheactivities, int economiccode, string teachername, int educationid,string adress)
        : base(institutionname, managingdirector, typeofcompanyid, typeofinstitutionid, scopeoftheactivities, economiccode, teachername, educationid, adress)
        {

        }
    }
}
