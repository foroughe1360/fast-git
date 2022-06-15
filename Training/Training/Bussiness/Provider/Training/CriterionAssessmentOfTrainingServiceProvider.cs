using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using DomainModel.Models;

namespace Bussiness.Provider
{
    public class CriterionAssessmentOfTrainingServiceProvider : ICriterionAssessmentOfTrainingServiceProvider
    {
        private CriterionAssessmentOfTrainingServiceDAC _CriterionAssessmentOfTrainingServiceDAC;

        public CriterionAssessmentOfTrainingServiceProvider()
        {
            _CriterionAssessmentOfTrainingServiceDAC = new CriterionAssessmentOfTrainingServiceDAC();
        }

        public int Add(CriterionAssessmentOfTrainingServiceEntity Current)
        {
            return _CriterionAssessmentOfTrainingServiceDAC.Add(Current);
        }

        public bool Add(List<CriterionAssessmentOfTrainingServiceEntity> Current)
        {
            foreach (var item in Current)
            {
                if (Get(item.AssessmentOfTrainingServiceId, item.TypeOfEvaluationId) == null)
                {
                    CriterionAssessmentOfTrainingService _CriterionAssessmentOfTrainingService = new CriterionAssessmentOfTrainingService
                        (item.AssessmentOfTrainingServiceId, item.TypeOfEvaluationId, item.Earnpoints, item.Description);

                    _CriterionAssessmentOfTrainingServiceDAC.Add(_CriterionAssessmentOfTrainingService);
                }
                else if (Get(item.CriterionAssessmentOfTrainingServiceId) != null)
                {
                    CriterionAssessmentOfTrainingService _CriterionAssessmentOfTrainingService = new CriterionAssessmentOfTrainingService();
                    _CriterionAssessmentOfTrainingService.CriterionAssessmentOfTrainingServiceId = item.CriterionAssessmentOfTrainingServiceId;
                    _CriterionAssessmentOfTrainingService.TimeLastModified = DateTime.Now;
                    _CriterionAssessmentOfTrainingService.AssessmentOfTrainingServiceId = item.AssessmentOfTrainingServiceId;
                    _CriterionAssessmentOfTrainingService.TypeOfEvaluationId = item.TypeOfEvaluationId;
                    _CriterionAssessmentOfTrainingService.Earnpoints = item.Earnpoints;
                    _CriterionAssessmentOfTrainingService.Description = item.Description;
                    _CriterionAssessmentOfTrainingServiceDAC.Edit(_CriterionAssessmentOfTrainingService);
                }
            }
            return true;
        }

        public bool Delete(int ID)
        {
            return _CriterionAssessmentOfTrainingServiceDAC.Delete(ID);
        }

        public bool Edit(CriterionAssessmentOfTrainingServiceEntity Current)
        {
            return _CriterionAssessmentOfTrainingServiceDAC.Edit(Current);
        }

        public CriterionAssessmentOfTrainingServiceEntity Get(int ID)
        {
            CriterionAssessmentOfTrainingServiceEntity _CriterionAssessmentOfTrainingServiceEntity = new CriterionAssessmentOfTrainingServiceEntity();
            var q = _CriterionAssessmentOfTrainingServiceDAC.Get(ID);
            if (q != null)
            {
                _CriterionAssessmentOfTrainingServiceEntity.AssessmentOfTrainingServiceId = q.AssessmentOfTrainingServiceId;
                _CriterionAssessmentOfTrainingServiceEntity.CriterionAssessmentOfTrainingServiceId = q.CriterionAssessmentOfTrainingServiceId;
                _CriterionAssessmentOfTrainingServiceEntity.Description = q.Description;
                _CriterionAssessmentOfTrainingServiceEntity.Earnpoints = q.Earnpoints;
                _CriterionAssessmentOfTrainingServiceEntity.TypeOfEvaluationId = q.TypeOfEvaluationId;
            }
            else
            {
                _CriterionAssessmentOfTrainingServiceEntity = null;
            }
            return _CriterionAssessmentOfTrainingServiceEntity;
        }

        public CriterionAssessmentOfTrainingServiceEntity Get(int assessmentoftrainingserviceid, int typeofevaluationid)
        {
            CriterionAssessmentOfTrainingServiceEntity _CriterionAssessmentOfTrainingServiceEntity = new CriterionAssessmentOfTrainingServiceEntity();
            var q = _CriterionAssessmentOfTrainingServiceDAC.Get(assessmentoftrainingserviceid, typeofevaluationid);
            if (q != null)
            {
                _CriterionAssessmentOfTrainingServiceEntity.AssessmentOfTrainingServiceId = q.AssessmentOfTrainingServiceId;
                _CriterionAssessmentOfTrainingServiceEntity.CriterionAssessmentOfTrainingServiceId = q.CriterionAssessmentOfTrainingServiceId;
                _CriterionAssessmentOfTrainingServiceEntity.Description = q.Description;
                _CriterionAssessmentOfTrainingServiceEntity.Earnpoints = q.Earnpoints;
                _CriterionAssessmentOfTrainingServiceEntity.TypeOfEvaluationId = q.TypeOfEvaluationId;
            }
            else
            {
                _CriterionAssessmentOfTrainingServiceEntity = null;
            }
            return _CriterionAssessmentOfTrainingServiceEntity;
        }

        public IQueryable<CriterionAssessmentOfTrainingServiceEntity> GetAll()
        {
            return (IQueryable < CriterionAssessmentOfTrainingServiceEntity > )_CriterionAssessmentOfTrainingServiceDAC.GetAll();
        }

        public IQueryable<CriterionAssessmentOfTrainingServiceEntity> GetAll(int ID)
        {
            return _CriterionAssessmentOfTrainingServiceDAC.GetAll(ID);
        }
    }
}
