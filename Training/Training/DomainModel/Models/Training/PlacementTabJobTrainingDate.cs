using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class PlacementTabJobTrainingDate
    {
        public int PlacementTabJobTrainingDateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Description { get; set; }
        public DateTime PTJTDate { get; set; }
        public bool Hidden { get; set; }

        public PlacementTabJobTrainingDate()
        {

        }

        public PlacementTabJobTrainingDate(string description, DateTime ptjtdate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Description = description;
            PTJTDate = ptjtdate;
            Hidden = false;
        }
    }
}
