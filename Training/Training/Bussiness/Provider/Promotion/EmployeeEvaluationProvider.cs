using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class EmployeeEvaluationProvider : IEmployeeEvaluationProvider
    {
        private EmployeeEvaluationDAC _EmployeeEvaluationDAC;
        public EmployeeEvaluationProvider()
        {
            _EmployeeEvaluationDAC = new EmployeeEvaluationDAC();
        }
        public int Add(EmployeeEvaluationEntity Current)
        {
            return _EmployeeEvaluationDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _EmployeeEvaluationDAC.Delete(ID);
        }

        public bool Edit(EmployeeEvaluationEntity Current)
        {
            return _EmployeeEvaluationDAC.Edit(Current);
        }

        public EmployeeEvaluationEntity Get(int ID)
        {
            EmployeeEvaluationEntity _EmployeeEvaluationEntity = new EmployeeEvaluationEntity();
            var q = _EmployeeEvaluationDAC.Get(ID);
            _EmployeeEvaluationEntity.Accountability = q.Accountability;
            _EmployeeEvaluationEntity.AccountabilityDetail = q.AccountabilityDetail;
            _EmployeeEvaluationEntity.EmployeeEvaluationId = q.EmployeeEvaluationId;
            _EmployeeEvaluationEntity.Experience = q.Experience;
            _EmployeeEvaluationEntity.ExperienceDetail = q.ExperienceDetail;
            _EmployeeEvaluationEntity.IndividualBehavior = q.IndividualBehavior;
            _EmployeeEvaluationEntity.IndividualBehaviorDetail = q.IndividualBehaviorDetail;
            _EmployeeEvaluationEntity.ListEmployeeEvaluationId = q.ListEmployeeEvaluationId;
            _EmployeeEvaluationEntity.Skill = q.Skill;
            _EmployeeEvaluationEntity.SkillDetail = q.SkillDetail;
            _EmployeeEvaluationEntity.TheoreticalKnowledge = q.TheoreticalKnowledge;
            _EmployeeEvaluationEntity.TheoreticalKnowledgeDetail = q.TheoreticalKnowledgeDetail;
            _EmployeeEvaluationEntity.UpgradeConfirmation = q.UpgradeConfirmation;
            _EmployeeEvaluationEntity.WorkPerformance = q.WorkPerformance;
            _EmployeeEvaluationEntity.WorkPerformanceDetail = q.WorkPerformanceDetail;
            return _EmployeeEvaluationEntity;
        }

        public IQueryable<EmployeeEvaluationEntity> GetAll()
        {
            var query = _EmployeeEvaluationDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new EmployeeEvaluationEntity()
                 {
                     Accountability = q.Accountability,
                     AccountabilityDetail = q.AccountabilityDetail,
                     EmployeeEvaluationId = q.EmployeeEvaluationId,
                     Experience = q.Experience,
                     ExperienceDetail = q.ExperienceDetail,
                     IndividualBehavior = q.IndividualBehavior,
                     IndividualBehaviorDetail = q.IndividualBehaviorDetail,
                     ListEmployeeEvaluationId = q.ListEmployeeEvaluationId,
                     Skill = q.Skill,
                     SkillDetail = q.SkillDetail,
                     TheoreticalKnowledge = q.TheoreticalKnowledge,
                     TheoreticalKnowledgeDetail = q.TheoreticalKnowledgeDetail,
                     UpgradeConfirmation = q.UpgradeConfirmation,
                     WorkPerformance = q.WorkPerformance,
                     WorkPerformanceDetail = q.WorkPerformanceDetail


                 });
            return _query;
        }
    }
}
