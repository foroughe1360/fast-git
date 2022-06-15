using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListLearningAssistTool
    {
        public int ListLearningAssistToolId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DesignTrainingCourseId { get; set; }
        public int LearningAssistToolId { get; set; }
        public bool Hidden { get; set; }

        public ListLearningAssistTool()
        {
        }

        public ListLearningAssistTool(int designtrainingcourseid,int learningassisttoolid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DesignTrainingCourseId = designtrainingcourseid;
            LearningAssistToolId = learningassisttoolid;
            Hidden = false;
        }
    }
}
