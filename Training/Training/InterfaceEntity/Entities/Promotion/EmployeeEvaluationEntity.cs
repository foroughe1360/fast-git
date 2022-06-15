using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class EmployeeEvaluationEntity : EmployeeEvaluation
    {
        public EmployeeEvaluationEntity() { }
        public EmployeeEvaluationEntity(int listemployeeevaluationid, int theoreticalknowledge, string theoreticalknowledgedetail,
            int experience, string experiencedetail, int skill, string skilldetail, int workperformance,
            string workperformancedetail, int accountability, string accountabilitydetail, int individualbehavior,
            string individualbehaviordetail, bool upgradeconfirmation)
        {
            ListEmployeeEvaluationId = listemployeeevaluationid;
            TheoreticalKnowledge = theoreticalknowledge;
            TheoreticalKnowledgeDetail = theoreticalknowledgedetail;
            Experience = experience;
            ExperienceDetail = experiencedetail;
            Skill = skill;
            SkillDetail = skilldetail;
            WorkPerformance = workperformance;
            WorkPerformanceDetail = workperformancedetail;
            Accountability = accountability;
            AccountabilityDetail = accountabilitydetail;
            IndividualBehavior = individualbehavior;
            IndividualBehaviorDetail = individualbehaviordetail;
            UpgradeConfirmation = upgradeconfirmation;
        }
    }
}
