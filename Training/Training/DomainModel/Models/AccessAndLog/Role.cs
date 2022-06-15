using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }

        public Role()
        {

        }

        public Role(string rolename,string description)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            RoleName = rolename;
            Description = description;
            Hidden = false;
        }
    }
}
