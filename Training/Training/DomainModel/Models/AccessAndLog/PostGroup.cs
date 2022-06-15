using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class PostGroup
    {
        public int PostGroupId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int CollectionId { get; set; }
        public int PostTypeId { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public PostGroup()
        {
            
        }

        public PostGroup(int collectionid,int posttypeid,bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            CollectionId = collectionid;
            PostTypeId = posttypeid;
            State = state;
            Hidden = false;
        }
    }
}
