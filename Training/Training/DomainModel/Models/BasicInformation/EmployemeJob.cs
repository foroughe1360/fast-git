using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class EmployemeJob
    {
        public int EmployemeJobId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int EmployemeId { get; set; }
        public int PostGroupId { get; set; }
        public int SectionId { get; set; }
        public DateTime DateStartPostGroupName { get; set; }
        public bool ActivePostGroupName { get; set; }
        public bool Hidden { get; set; }

        public EmployemeJob()
        {

        }

        public EmployemeJob(int employemeid, int postgroupid, int sectionid, DateTime datestartpostgroupname, bool activepostgroupname)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            EmployemeId = employemeid;
            PostGroupId = postgroupid;
            SectionId = sectionid;
            DateStartPostGroupName = datestartpostgroupname;
            ActivePostGroupName = activepostgroupname;
            Hidden = false;
        }
    }
}
