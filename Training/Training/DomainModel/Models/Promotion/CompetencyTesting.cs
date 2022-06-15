using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class CompetencyTesting
    {
        public int CompetencyTestingId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ListQualificationOfStaffId { get; set; }
        public int LaboratoryTestsId { get; set; }
        public bool Hidden { get; set; }

        public CompetencyTesting()
        {
            
        }

        public CompetencyTesting(int listqualificationofstaffid,int laboratorytestsid)
        {
            ListQualificationOfStaffId = listqualificationofstaffid;
            LaboratoryTestsId = laboratorytestsid;
        }
    }
}
