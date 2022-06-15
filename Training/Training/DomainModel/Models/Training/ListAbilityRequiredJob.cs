using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListAbilityRequiredJob
    {
        public int ListAbilityRequiredJobId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int InventoryjobsId { get; set; }
        public int AbilityRequiredJobId { get; set; }
        public bool Hidden { get; set; }

        public ListAbilityRequiredJob()
        {
            
        }

        public ListAbilityRequiredJob(int inventoryjobsid,int abilityrequiredjobid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            InventoryjobsId = inventoryjobsid;
            AbilityRequiredJobId = abilityrequiredjobid;
            Hidden = false;
        }
    }
}
