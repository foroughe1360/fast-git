using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report.Training.ListAttendance
{
    public class AttendanceDateReport
    {
        public int AttendanceDateId { get; set; }
        public int DesignTrainingCourseId { get; set; }
        public DateTime AttendanceAbsenceDate { get; set; }
    }
}
