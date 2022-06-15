using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListOfCorporateJobDate
    {
        public int ListOfCorporateJobDateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Description { get; set; }
        public DateTime LOCJDate { get; set; }
        public bool Hidden { get; set; }

        public ListOfCorporateJobDate()
        {

        }

        public ListOfCorporateJobDate(string description, DateTime locjdate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Description = description;
            LOCJDate = locjdate;
            Hidden = false;
        }
    }
}
