using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class ListTypeTestScoreEntity: ListTypeTestScore
    {
        public double TestScoresNumber { get; set; }
        public int CourseRegistrationId { get; set; }
        public int EmployemeId { get; set; }
        public enum VarietyOfTestType : int
        {
            PreTestScore = 187,
            MidtermScore = 103,
            FinalTestScore = 385
        }

        public string VarietyOfTestName { get; set; }
        public string DesignTrainingCourseName { get; set; }
        public string ExamDatesStr { get; set; }
        public ListTypeTestScoreEntity()
        {

        }

        public ListTypeTestScoreEntity(int designtrainingcourseid, int varietyoftestid, DateTime examdates, int purposetest)
            :base(designtrainingcourseid,  varietyoftestid,examdates,purposetest)
        {

        }
    }
}
