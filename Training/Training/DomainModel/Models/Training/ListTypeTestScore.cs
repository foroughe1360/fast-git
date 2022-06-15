using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListTypeTestScore
    {

        public int ListTypeTestScoreId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DesignTrainingCourseId { get; set; }
        public int VarietyOfTestId { get; set; }
        public DateTime ExamDates { get; set; }
        public int PurposeTest { get; set; }
        public bool Hidden { get; set; }

        public ListTypeTestScore()
        {

        }

        public ListTypeTestScore(int designtrainingcourseid,int varietyoftestid,DateTime examdates,int purposetest)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DesignTrainingCourseId = designtrainingcourseid;
            VarietyOfTestId = varietyoftestid;
            ExamDates = examdates;
            PurposeTest = purposetest;
            Hidden = false;

        }
    }
}
