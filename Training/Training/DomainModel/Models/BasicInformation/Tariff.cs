using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Tariff
    {
        public int TariffId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public Int64 Cost { get; set; }
        public int CourseTypeId { get; set; }
        public DateTime TariffDate { get; set; }
        public bool Hidden { get; set; }

        public Tariff()
        {
            
        }

        public Tariff(Int64 cost, int coursetypeid,DateTime tariffdate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Cost = cost;
            CourseTypeId = coursetypeid;
            TariffDate = tariffdate;
            Hidden = false;
        }
    }
}
