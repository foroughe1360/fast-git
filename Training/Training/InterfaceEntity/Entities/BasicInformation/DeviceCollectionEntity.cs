using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class DeviceCollectionEntity: DeviceCollection
    {
        public string collectionName { get; set; }
        public DeviceCollectionEntity()
        {

        }

        public DeviceCollectionEntity(int collectionsid, string jobdevicecollection, bool state):base(collectionsid,jobdevicecollection,state)
        {
        }
    }
}
