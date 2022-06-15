using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models.AccessAndLog
{
    public class Supervisor
    {
        public int SupervisorId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DepartmentId { get; set; }
        public int EmployemeId { get; set; }
        public int PostTypeId { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public Supervisor()
        {

        }

        public Supervisor(int departmentid, int employemeid, int posttypeid, bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DepartmentId = departmentid;
            EmployemeId = employemeid;
            PostTypeId = posttypeid;
            State = state;
            Hidden = false;
        }

    }
}
