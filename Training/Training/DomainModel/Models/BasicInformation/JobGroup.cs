using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class JobGroup
    {
        public int JobGroupId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string JobGroupName { get; set; }
        public int PonitJobGroup { get; set; }
        public int GroupNumber { get; set; }
        public bool Hidden { get; set; }

        public JobGroup()
        {
            
        }

        public JobGroup(string jobgroupname,int ponitjobgroup,int groupnumber)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            JobGroupName = jobgroupname;
            PonitJobGroup = ponitjobgroup;
            GroupNumber = groupnumber;
            Hidden = false;
        }
    }
}
