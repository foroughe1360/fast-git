using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class AttendanceDateReport
    {
        public string EmployemeName { get; set; }
        public DateTime AttendanceAbsenceDate { get; set; }
        public string AttendanceAbsenceDateFarsi { get; set; }
        public int TypeAttendance { get; set; }
        public string TypeAttendanceDate { get; set; }

        public double PreTestScore { get; set; }
        public double TestScore { get; set; }

        public double PracticalTestScore { get; set; }

        public double FinalTestScore { get; set; }


        public int CourseRegistrationId { get; set; }
        public int DesignTrainingCourseId { get; set; }


    }
}
