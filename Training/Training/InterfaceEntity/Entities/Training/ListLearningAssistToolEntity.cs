using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public  class ListLearningAssistToolEntity : ListLearningAssistTool
    {
        public string CourseName { get; set; }
        public int TrainingCourseId { get; set; }
        public string LearningAssistToolName { get; set; }
        public bool LearningAssistToolState { get; set; }
        public bool State { get; set; }


        public ListLearningAssistToolEntity() { }
        public ListLearningAssistToolEntity(int designtrainingcourseid, int learningassisttoolid)
        {
            DesignTrainingCourseId = designtrainingcourseid;
            LearningAssistToolId = learningassisttoolid;
        }
    }
}
