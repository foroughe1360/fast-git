using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class ListTrainingCoursesWithAttendancesEntity
    {
        public ListTrainingCoursesWithAttendancesEntity()
        {
        }

        public int DesignTrainingCourseId { get; set; }
        public int EmployemeId { get; set; }
        public int CountTypeAttendanceId { get; set; }
        public string EmployemeName { get; set; }
        public string CourseName { get; set; }
        public double PreTestScore { get; set; }
        public double MidtermScore { get; set; }
        public int Duration { get; set; }
        public double FinalTestScore { get; set; }
        public DateTime ExamDates { get; set; }
        public string TrainingVenueName { get; set; }
        public string TeacherName { get; set; }


    }
}
