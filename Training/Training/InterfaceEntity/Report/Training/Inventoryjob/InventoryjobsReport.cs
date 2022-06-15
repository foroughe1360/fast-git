using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class InventoryjobsReport
    {
        public string UnitCenter { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string PostGroupName { get; set; }
        public bool OnePerson { get; set; }
        public bool MoreThanOnePerson { get; set; }
        public string AsJobs2 { get; set; }
        public string AsJobs3 { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string ListResponsibilitiePower { get; set; }
        public bool FullHealth { get; set; }
        public bool OtherPhysicalConditionsAcceptable { get; set; }
        public string PercentPhysicalActivity { get; set; }
        public string PercentMentalActivity { get; set; }
        public string TheoreticalKnowledge { get; set; }
        public string Qualified { get; set; }
        public string OtherTraining { get; set; }
        public int NumberEmployees { get; set; }
        public string OtherAbilityRequiredJob { get; set; }
        public string ListCommunityOrganizationComment { get; set; }

        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }

    }
}
