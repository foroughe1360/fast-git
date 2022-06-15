using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Inventoryjob
    {
        public int InventoryjobId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int SectionId { get; set; }
        public string PostGroupName { get; set; }
        public int NumberEmployees { get; set; }
        public string AsJobs2 { get; set; }
        public string AsJobs3 { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public int ListResponsibilitiePowerId { get; set; }
        public string PercentPhysicalActivity { get; set; }
        public string PercentMentalActivity { get; set; }
        public string TheoreticalKnowledge { get; set; }
        public string Qualified { get; set; }
        public string OtherTraining { get; set; }
        public string OtherAbilityRequiredJob { get; set; }
        public string ListCommunityOrganizationComment { get; set; }

        public bool Hidden { get; set; }

        public Inventoryjob()
        {

        }

        public Inventoryjob(int sectionid, string postgroupname, int numberemployees, string asjobs2,
            string asjobs3, string education, string experience,
            int listresponsibilitiepowerid, string percentphysicalactivity, string percentmentalactivity, string theoreticalknowledge,
            string qualified, string othertraining , string otherabilityrequiredjob,string listcommunityorganizationcomment)
        {

            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            SectionId = sectionid;
            PostGroupName = postgroupname;
            NumberEmployees = numberemployees;
            AsJobs2 = asjobs2;
            AsJobs3 = asjobs3;
            Education = education;
            Experience = experience;
            ListResponsibilitiePowerId = listresponsibilitiepowerid;
            PercentPhysicalActivity = percentphysicalactivity;
            PercentMentalActivity = percentmentalactivity;
            TheoreticalKnowledge = theoreticalknowledge;
            Qualified = qualified;
            OtherTraining = othertraining;
            OtherAbilityRequiredJob = otherabilityrequiredjob;
            ListCommunityOrganizationComment = listcommunityorganizationcomment;
        }
    }
}
