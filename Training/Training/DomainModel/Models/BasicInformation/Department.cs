using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int UnitSCenterId { get; set; }
        public string Name { get; set; }
        public bool Hidden { get; set; }

        public Department()
        {

        }

        public Department(int unitscenterid,string name)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            UnitSCenterId = unitscenterid;
            Name = name;
            Hidden = false;
        }
    }
}
