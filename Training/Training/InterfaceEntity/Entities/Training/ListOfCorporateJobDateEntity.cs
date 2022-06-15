using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public  class ListOfCorporateJobDateEntity: ListOfCorporateJobDate
    {
        public string LOCJDateStr { get; set; }
        public ListOfCorporateJobDateEntity()
        {

        }

        public ListOfCorporateJobDateEntity(string description, DateTime locjdate):base(description, locjdate)
        {

        }
    }
}
