using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class DesignTrainingCourseEntity : DesignTrainingCourse
    {
        public string TrainingVenueName { get; set; }
        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string typesoftrainingName { get; set; }
        public string TookHoldStr { get; set; }
        public string ExamDatesStr { get; set; }

        public Int32 FinancialYear { get; set; }

        public DesignTrainingCourseEntity() { }
        public DesignTrainingCourseEntity(int designtrainingcoursedateid,int trainingcourseid,int teacherId, DateTime tookHold, 
            int trainingvenueid, int duration, int numberofparticipants, Int64 costcourses, string courseobjectives, 
            string coursecontent, string othernotes, DateTime examdates, int typesoftrainingid, int maximumscore,string hoursholding,
            int minutesholding,string listlearningassisttoolcomment, Double effectivenessofcourse)

              :base(designtrainingcoursedateid,trainingcourseid, teacherId, tookHold, trainingvenueid, duration,  numberofparticipants,
                   costcourses,courseobjectives, coursecontent, othernotes, examdates, typesoftrainingid, maximumscore, 
                   hoursholding, minutesholding, listlearningassisttoolcomment, effectivenessofcourse)
        {
        }
    }
}
