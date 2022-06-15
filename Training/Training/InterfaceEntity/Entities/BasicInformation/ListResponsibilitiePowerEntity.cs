using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class ListResponsibilitiePowerEntity : ListResponsibilitiePower
    {
        public string PostGroupName { get; set; }

        public ListResponsibilitiePowerEntity()
        {

        }

        public ListResponsibilitiePowerEntity(int postgroupid, string description) :base(postgroupid, description)
        {

        }
    }
}
