using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public   class EmployemeSignatury
    {
        public int EmployemeSignaturyId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int SideSignatoryId { get; set; }
        public int EmployemeId { get; set; }
        public DateTime EmployemeSignaturyDate { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public EmployemeSignatury()
        {

        }

        public EmployemeSignatury(int sidesignatoryid,int employemeid, DateTime employemesignaturydate, bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            SideSignatoryId = sidesignatoryid;
            EmployemeId = employemeid;
            EmployemeSignaturyDate = employemesignaturydate;
            State = state;
            Hidden = false;
        }
    }
}
