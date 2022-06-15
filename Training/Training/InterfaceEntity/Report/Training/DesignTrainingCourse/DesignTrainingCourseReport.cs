using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report.Training.DesignTrainingCourse
{
    public class DesignTrainingCourseReport
    {
        public string TrainingCourse { get; set; }
        public string Teacher { get; set; }
        public DateTime TookHold { get; set; }
        public string TookHoldStr { get; set; }
        public string TrainingVenue { get; set; }
        public int Duration { get; set; }
        public int NumberOfParticipants { get; set; }
        public long CostCourses { get; set; }
        public string CourseObjectives { get; set; }
        public string CourseContent { get; set; }
        public string ListLearningAssistToolComment { get; set; }
        public string HoursHolding { get; set; }
        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }

        public string OtherNotes { get; set; }

    }
}
