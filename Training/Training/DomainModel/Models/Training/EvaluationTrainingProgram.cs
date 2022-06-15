using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class EvaluationTrainingProgram
    {
        public int EvaluationTrainingProgramId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ContentQuestionsId { get; set; }
        public int ScoreEducationIdForContentQuestionsId { get; set; }
        public int DirectorEducationQuestionId { get; set; }
        public int CourseRegistrationId { get; set; }
        public bool Hidden { get; set; }

        public EvaluationTrainingProgram()
        {
            
        }

        public EvaluationTrainingProgram(int contentquestionsid,
            int scoreeducationidforcontentquestionsid,int directoreducationquestionid,
            int scoreeducationidfordirectoreducationquestionid,int courseregistrationid)
        {
            
            ContentQuestionsId = contentquestionsid;
            ScoreEducationIdForContentQuestionsId = scoreeducationidforcontentquestionsid;
            DirectorEducationQuestionId = directoreducationquestionid;
            CourseRegistrationId = courseregistrationid;
        }
    }
}
