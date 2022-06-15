using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class DesignTrainingCourse
    {
        public int DesignTrainingCourseId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DesignTrainingCourseDateId { get; set; }
        public int TrainingCourseId { get; set; }
        public int TeacherId { get; set; }
        public DateTime TookHold { get; set; }
        public int TrainingVenueId { get; set; }
        public int Duration { get; set; }
        public int NumberOfParticipants { get; set; }
        public Int64 CostCourses { get; set; }
        public string CourseObjectives { get; set; }
        public string CourseContent { get; set; }
        public string OtherNotes { get; set; }
        public DateTime ExamDates { get; set; }
        public int TypesOfTrainingId { get; set; }
        public int MaximumScore { get; set; }
        public string HoursHolding { get; set; }
        public int MinutesHolding { get; set; }
        public string ListLearningAssistToolComment { get; set; }
        public Double EffectivenessOfCourse { get; set; }
        public bool Hidden { get; set; }

        public DesignTrainingCourse()
        {
            
        }

        public DesignTrainingCourse(int designtrainingcoursedateid, int trainingcourseid, int teacherId,DateTime tookHold, int trainingvenueid, 
            int duration,int numberofparticipants,Int64 costcourses,string courseobjectives,string coursecontent,string othernotes,DateTime examdates, 
            int typesoftrainingid,int maximumscore,string hoursholding,int minutesholding,string listlearningassisttoolcomment, Double effectivenessofcourse)
        {

            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DesignTrainingCourseDateId = designtrainingcoursedateid;
            TrainingCourseId = trainingcourseid;
            TeacherId = teacherId;
            TookHold = tookHold;
            TrainingVenueId = trainingvenueid;
            Duration = duration;
            NumberOfParticipants = numberofparticipants;
            CostCourses = costcourses;
            CourseObjectives = courseobjectives;
            CourseContent = coursecontent;
            OtherNotes = othernotes;
            ExamDates = examdates;
            TypesOfTrainingId = typesoftrainingid;
            MaximumScore = maximumscore;
            HoursHolding = hoursholding;
            MinutesHolding = minutesholding;
            ListLearningAssistToolComment = listlearningassisttoolcomment;
            EffectivenessOfCourse = effectivenessofcourse;
            Hidden = false;
        }
    }
}
