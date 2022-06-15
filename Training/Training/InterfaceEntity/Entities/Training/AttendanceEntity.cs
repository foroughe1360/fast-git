using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class AttendanceEntity: Attendance
    {
        public enum EmployemeState:int
        {
            preregistration= 180,
            Register=181,
            Dissuasion=182,
            Deleted=183
        }
        public string EmployemesnName { get; set; }
        public string TypeAttendanceName { get; set; }
        public DateTime AttendanceAbsenceDate { get; set; }
        public bool AttendanceAbsenceexist { get; set; }
        public bool StateSave { get; set; }
        public AttendanceEntity() { }
        public AttendanceEntity(int attendancedateid, int typeattendanceid, string hourdelayfrom, string hourdelayto)
        {
            AttendanceDateId = attendancedateid;
            TypeAttendanceId = typeattendanceid;
            HourDelayFrom = hourdelayfrom;
            HourDelayTo = hourdelayto;
        }

        public enum Attendance : int
        {
            Present = 184,
            Absent = 185,
            UnjustifiedAbsences=186
        }
    }
}
