using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListPhysicalCondition
    {
        public int ListPhysicalConditionId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int InventoryjobsId { get; set; }
        public int PhysicalConditionsId { get; set; }
        public bool Hidden { get; set; }

        public ListPhysicalCondition()
        {
            
        }

        public ListPhysicalCondition(int inventoryjobsid,int physicalconditionsid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            InventoryjobsId = inventoryjobsid;
            PhysicalConditionsId = physicalconditionsid;
            Hidden = false;
        }
    }
}
