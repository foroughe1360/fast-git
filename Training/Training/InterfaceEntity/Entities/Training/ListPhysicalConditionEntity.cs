using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public  class ListPhysicalConditionEntity: ListPhysicalCondition
    {
        public enum ListPhysicalCondition:int
        {
            FullHealth=168,
            OtherPhysicalConditionsAcceptable=169
        }


        public string PhysicalConditionsName { get; set; }
        public bool ListPhysicalConditionsState { get; set; }
        public bool State { get; set; }

        public ListPhysicalConditionEntity() { }
        public ListPhysicalConditionEntity(int inventoryjobsid, int physicalconditionsid)
            :base(inventoryjobsid,physicalconditionsid)
        {
        }
    }
}
