using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TestScore
    {
        public int TestScoreId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ListTypeTestScoresId { get; set; }
        public int CourseRegistrationId { get; set; }
        public double Score { get; set; }
        public bool Hidden { get; set; }

        public TestScore()
        {

        }

        public TestScore(int listtypetestscoresid,int courseregistrationid, double score)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            ListTypeTestScoresId = listtypetestscoresid;
            CourseRegistrationId = courseregistrationid;
            Score = score;
            Hidden = false;
        }
    }
}
