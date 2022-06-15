using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class AttendanceDateEntity : AttendanceDate
    {
        public string AttendanceAbsenceDateStr { get; set; }
        public string CourceName { get; set; }
        public AttendanceDateEntity()
        {

        }

        public AttendanceDateEntity(int designtrainingcourseid, DateTime attendanceabsencedate)
            :base(designtrainingcourseid,attendanceabsencedate)
        {

        }
    }
}
