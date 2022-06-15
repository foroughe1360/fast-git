using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AttendanceDate
    {
        public int AttendanceDateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified{ get; set; }
        public int DesignTrainingCourseId { get; set; }
        public DateTime AttendanceAbsenceDate { get; set; }
        public bool Hidden { get; set; }

        public AttendanceDate()
        {

        }

        public AttendanceDate(int designtrainingcourseid,DateTime attendanceabsencedate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DesignTrainingCourseId = designtrainingcourseid;
            AttendanceAbsenceDate = attendanceabsencedate;
            Hidden = false;
        }
    }
}
