using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class PostGroupEntity: PostGroup
    {
        public string CollectionName { get; set; }
        public string PostTypeName { get; set; }
        public string PostGroupName { get; set; }

        public PostGroupEntity()
        {

        }

        public PostGroupEntity(int collectionid, int posttypeid, bool state)
        {
            CollectionId = collectionid;
            PostTypeId = posttypeid;
            State = state;
        }
    }
}
