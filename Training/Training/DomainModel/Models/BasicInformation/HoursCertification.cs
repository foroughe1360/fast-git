using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class HoursCertification
    {
        public int HoursCertificationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TimePeriod { get; set; }
        public DateTime HoursCertificationDate { get; set; }
        public bool Hidden { get; set; }

        public HoursCertification()
        {

        }

        public HoursCertification(int timeperiod,DateTime hourscertificationdate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TimePeriod = timeperiod;
            HoursCertificationDate = hourscertificationdate;
            Hidden = false;
        }
    }
}
