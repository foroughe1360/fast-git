using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;

namespace Bussiness
{
    public class EvaluationTrainingProgramProvider : IEvaluationTrainingProgramProvider
    {
        private EvaluationTrainingProgramDAC _EvaluationTrainingProgramDAC;
        public EvaluationTrainingProgramProvider()
        {
            _EvaluationTrainingProgramDAC = new EvaluationTrainingProgramDAC();
        }
        public int Add(EvaluationTrainingProgramEntity Current)
        {
            return _EvaluationTrainingProgramDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _EvaluationTrainingProgramDAC.Delete(ID);
        }

        public bool Edit(EvaluationTrainingProgramEntity Current)
        {
            return _EvaluationTrainingProgramDAC.Edit(Current);
        }

        public EvaluationTrainingProgramEntity Get(int ID)
        {
            EvaluationTrainingProgramEntity _EvaluationTrainingProgramEntity = new EvaluationTrainingProgramEntity();
            var q = _EvaluationTrainingProgramDAC.Get(ID);
            _EvaluationTrainingProgramEntity.ContentQuestionsId = q.ContentQuestionsId;
            _EvaluationTrainingProgramEntity.CourseRegistrationId = q.CourseRegistrationId;
            _EvaluationTrainingProgramEntity.DirectorEducationQuestionId = q.DirectorEducationQuestionId;
            _EvaluationTrainingProgramEntity.EvaluationTrainingProgramId = q.EvaluationTrainingProgramId;
            _EvaluationTrainingProgramEntity.ScoreEducationIdForContentQuestionsId = q.ScoreEducationIdForContentQuestionsId;
            return _EvaluationTrainingProgramEntity;

            //return (EvaluationTrainingProgramEntity)_EvaluationTrainingProgramDAC.Get(ID);
        }


        public IQueryable<EvaluationTrainingProgramEntity> GetAll()
        {
            //var query = _EvaluationTrainingProgramDAC.GetAll();
            //var _query =
            //    (from q in query.Where(a => a.Hidden == false)
            //     select new EvaluationTrainingProgramEntity()
            //     {
            //         ContentQuestionsId = q.ContentQuestionsId,
            //         DesignTrainingCourseId = q.DesignTrainingCourseId,
            //         DirectorEducationQuestionId = q.DirectorEducationQuestionId,
            //         EvaluationTrainingProgramId = q.EvaluationTrainingProgramId,
            //         ScoreEducationIdForContentQuestionsId = q.ScoreEducationIdForContentQuestionsId

            //     });
            //return _query;
            return (IQueryable<EvaluationTrainingProgramEntity>)_EvaluationTrainingProgramDAC.GetAll();
        }

        public IQueryable<EvaluationTrainingProgramEntity> GetAll(int ID)
        {
            return _EvaluationTrainingProgramDAC.GetAllEvaluationTrainingProgram(ID);
        }

       
    }
}
