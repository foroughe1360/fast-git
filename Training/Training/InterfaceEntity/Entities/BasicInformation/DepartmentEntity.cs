using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class DepartmentEntity: Department
    {
        public string UnitSCenterName { get; set; } 
        public DepartmentEntity()
        {

        }

        public DepartmentEntity(int unitscenterid, string name):base(unitscenterid, name)
        {
        }
    }
}
