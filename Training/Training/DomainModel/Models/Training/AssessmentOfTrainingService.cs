using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class AssessmentOfTrainingService
    {
        public int AssessmentOfTrainingServiceId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string InstitutionName { get; set; }
        public string ManagingDirector { get; set; }
        public int TypeOfCompanyId { get; set; }
        public int TypeOfInstitutionId { get; set; }
        public string ScopeOfTheActivities { get; set; }
        public int EconomicCode { get; set; }
        public string TeacherName { get; set; }
        public int EducationId { get; set; }
        public string Address { get; set; }
        public bool Hidden { get; set; }

        public AssessmentOfTrainingService()
        {
            
        }

        public AssessmentOfTrainingService(string institutionname,string managingdirector,int typeofcompanyid,
            int typeofinstitutionid,string scopeoftheactivities,int economiccode,string teachername,int educationid,string address)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;

            InstitutionName = institutionname;
            ManagingDirector = managingdirector;
            TypeOfCompanyId = typeofcompanyid;
            TypeOfInstitutionId = typeofinstitutionid;
            ScopeOfTheActivities = scopeoftheactivities;
            EconomicCode = economiccode;
            TeacherName = teachername;
            EducationId = educationid;
            Address = address;
        }
    }
}
