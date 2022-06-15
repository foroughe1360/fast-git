using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TestsCollection
    {
        public int TestsCollectionId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int CollectionId { get; set; }
        public string TestsCollectionName { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public TestsCollection()
        {
            
        }

        public TestsCollection(int collectionid,string testscollectionname,bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            CollectionId = collectionid;
            TestsCollectionName = testscollectionname;
            State = state;
            Hidden = false;
        }
    }
}
