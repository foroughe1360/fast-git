using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListHealthCondition
    {
        public int ListHealthConditionId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int InventoryjobsId { get; set; }
        public int HealthConditionsId { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }

        public ListHealthCondition()
        {
            
        }

        public ListHealthCondition(int inventoryjobsid,int healthconditionsid,string description)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            InventoryjobsId = inventoryjobsid;
            HealthConditionsId = healthconditionsid;
            Description = description;
            Hidden = false;
        }
    }
}
