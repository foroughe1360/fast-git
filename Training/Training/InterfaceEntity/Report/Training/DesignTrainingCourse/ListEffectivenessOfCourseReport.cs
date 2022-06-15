using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report.Training.DesignTrainingCourse
{
    public class ListEffectivenessOfCourseReport
    {
        public enum ListEffectivenessOfCourse : int
        {
            CompareScore = 147,
            SurveyParticipants = 148,
            SurveySupervisor = 149,

        }
        public bool CompareScore { get; set; }
        public bool SurveyParticipants { get; set; }
        public bool SurveySupervisor { get; set; }
        public string OtherNotes { get; set; }

        public ListEffectivenessOfCourseReport()
        {
            CompareScore = false;
            SurveyParticipants = false;
            SurveySupervisor = false;
        }
    }
}
