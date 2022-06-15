using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class DeviceCollection
    {
        public int DeviceCollectionId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int CollectionsId { get; set; }
        public string JobDeviceCollection { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public DeviceCollection()
        {
            
        }

        public DeviceCollection(int collectionsid,string jobdevicecollection,bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            CollectionsId = collectionsid;
            JobDeviceCollection = jobdevicecollection;
            State = state;
            Hidden = false;
        }
    }
}
