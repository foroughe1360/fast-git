using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public  class EvaluationTrainingProgramEntity: EvaluationTrainingProgram
    {

        public int QuestionsID { get; set; }
        public string EvaluationTrainingProgramsName { get; set; }
        public int EmployemeId { get; set; }

        public EvaluationTrainingProgramEntity() { }
        public EvaluationTrainingProgramEntity( int contentquestionsid,
            int scoreeducationidforcontentquestionsid, int directoreducationquestionid,int courseregistrationid)
        {
         
            ContentQuestionsId = contentquestionsid;
            ScoreEducationIdForContentQuestionsId = scoreeducationidforcontentquestionsid;
            DirectorEducationQuestionId = directoreducationquestionid;
            CourseRegistrationId = courseregistrationid;
        }

    }
}
