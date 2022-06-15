using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DesignTrainingCourseDate
    {
        public int DesignTrainingCourseDateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Description { get; set; }
        public DateTime DTCDate { get; set; }
        public int FinancialYear { get; set; }
        public bool Hidden { get; set; }

        public DesignTrainingCourseDate()
        {

        }

        public DesignTrainingCourseDate(string description, DateTime dtcdate,int financialyear)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Description = description;
            DTCDate = dtcdate;
            FinancialYear = financialyear;
            Hidden = false;
        }

    }
}
