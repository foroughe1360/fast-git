using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report.Training.DesignTrainingCourse
{
    public class ListStyleCourseReport
    {
        public enum ListStyleCourse : int
        {
            Classroom = 142,
            OJT = 143,
            SD = 144,
            Workshop = 145,
            PracticalWork = 146
                
        }
        public bool Classroom { get; set; }
        public bool OJT { get; set; }
        public bool SD { get; set; }
        public bool Workshop { get; set; }
        public bool PracticalWork { get; set; }

        public ListStyleCourseReport()
        {
            Classroom = false;
            OJT = false;
            SD = false;
            Workshop = false;
            PracticalWork = false;
        }
    }
}
