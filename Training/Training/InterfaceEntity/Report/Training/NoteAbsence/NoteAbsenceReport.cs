using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class NoteAbsenceReport
    {
        public string EmployemesName { get; set; }
        public string AttendanceDateStr { get; set; }
        public string HourDelayFrom { get; set; }
        public string HourDelayTo { get; set; }
        public string CourseName { get; set; }
        public string WrittenNoticeName { get; set; }
        public bool WrittenNoticeJE { get; set; }
        public bool WrittenNoticeDP { get; set; }
        public DateTime AttendanceDate { get; set; }

    }
}
