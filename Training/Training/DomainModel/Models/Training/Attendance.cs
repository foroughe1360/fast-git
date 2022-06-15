using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int AttendanceDateId { get; set; }
        public int CourseRegistrationId { get; set; }
        public int TypeAttendanceId { get; set; }
        public string HourDelayFrom { get; set; }
        public string HourDelayTo { get; set; }
        public bool Hidden { get; set; }

        public Attendance()
        {
             
        }

        public Attendance(int attendancedateid,int courseregistrationid, int typeattendanceid, string hourdelayfrom,string hourdelayto)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            AttendanceDateId = attendancedateid;
            TypeAttendanceId = typeattendanceid;
            CourseRegistrationId = courseregistrationid;
            HourDelayFrom = hourdelayfrom;
            HourDelayTo = hourdelayto;
            Hidden = false;
        }
    }
}
