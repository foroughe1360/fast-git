using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class FinancialCommitment
    {
        public int FinancialCommitmentId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int EmployemeId { get; set; }
        public int TrainingCourseId { get; set; }
        public int TrainingVenueId { get; set; }
        public Int64 AmountPierced { get; set; }
        public int TimeEmployment { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FinancialYear { get; set; }

        public bool Hidden { get; set; }

        public FinancialCommitment()
        {

        }

        public FinancialCommitment(int employemeid, int trainingcourseid, int trainingvenueid, Int64 amountpierced, int timeemployment, DateTime fromdate, DateTime todate, int financialyear)
        {

            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Hidden = false;
            EmployemeId = employemeid;
            TrainingCourseId = trainingcourseid;
            TrainingVenueId = trainingvenueid;
            AmountPierced = amountpierced;
            TimeEmployment = timeemployment;
            FromDate = fromdate;
            FinancialYear = financialyear;
            ToDate = todate;
        }
    }
}
