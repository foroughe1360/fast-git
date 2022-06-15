using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class SectionEntity: Section
    {
        public string UnitSCenterName { get; set; }
        public string departmentName { get; set; }
        public SectionEntity()
        {

        }

        public SectionEntity(string name, int departmentid):base(name,departmentid)
        {
        }
    }
}
