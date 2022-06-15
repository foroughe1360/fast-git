using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TeacherLevel
    {
        public int TeacherLevelId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TeacherLevelDateId { get; set; }
        public int TeacherId { get; set; }
        //public int TrainingCourseId { get; set; }
        public string TrainingCourse { get; set; }
        public double EffectivenessOfPreviousPeriod { get; set; }
        public double Rhetorical { get; set; }
        public double EducationId { get; set; }
        public double Experience { get; set; }
        public double CoursePlan { get; set; }
        public double HistoryOfCooperation { get; set; }
        public double Degree { get; set; }
        public bool Hidden { get; set; }

        public TeacherLevel()
        {
            
        }

        public TeacherLevel(int teacherleveldateid, int teacherid,string trainingcourse,
            double effectivenessofpreviousperiod, double rhetorical, double educationid,
            double experience, double courseplan, double historyofcooperation, double degree)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TeacherLevelDateId = teacherleveldateid;
            TeacherId = teacherid;
            TrainingCourse = trainingcourse;
            EffectivenessOfPreviousPeriod = effectivenessofpreviousperiod;
            Rhetorical = rhetorical;
            EducationId = educationid;
            Experience = experience;
            CoursePlan = courseplan;
            HistoryOfCooperation = historyofcooperation;
            Degree = degree;
            Hidden = false;
        }
    }
}
