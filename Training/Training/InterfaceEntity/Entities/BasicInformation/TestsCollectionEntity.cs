using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TestsCollectionEntity: TestsCollection
    {
        public string CollectionName { get; set; }
        public TestsCollectionEntity()
        {

        }
        public TestsCollectionEntity(int collectionid, string testscollectionname, bool state):base(collectionid, testscollectionname, state)
        {
        }
    }
}
