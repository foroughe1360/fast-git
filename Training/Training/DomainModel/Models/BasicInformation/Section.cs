using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Section
    {
        public int SectionId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public bool Hidden { get; set; }

        public Section()
        {
            
        }

        public Section(string name,int departmentid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Name = name;
            DepartmentId = departmentid;
            Hidden = false;
        }
    }
}
