using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public  class ListHealthConditionEntity : ListHealthCondition
    {
        public string ListHealthConditionName { get; set; }
        public bool ListHealthConditionState { get; set; }
        public bool State { get; set; }
        public ListHealthConditionEntity() { }
        public ListHealthConditionEntity(int inventoryjobsid, int healthconditionsid,string description)
            :base(inventoryjobsid,healthconditionsid,description)
        {
        }

    }
}
