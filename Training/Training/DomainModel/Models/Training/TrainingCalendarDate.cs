using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TrainingCalendarDate
    {
        public int TrainingCalendarDateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Description { get; set; }
        public DateTime TrCalendarDate { get; set; }
        public bool Hidden { get; set; }

        public TrainingCalendarDate()
        {

        }

        public TrainingCalendarDate(string description, DateTime trcalendardate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Description = description;
            TrCalendarDate = trcalendardate;
            Hidden = false;
        }
    }
}
