using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class EmployeeEvaluation
    {
        public int EmployeeEvaluationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ListEmployeeEvaluationId { get; set; }
        public int TheoreticalKnowledge { get; set; }
        public string TheoreticalKnowledgeDetail { get; set; }
        public int Experience { get; set; }
        public string ExperienceDetail { get; set; }
        public int Skill { get; set; }
        public string SkillDetail { get; set; }
        public int WorkPerformance { get; set; }
        public string WorkPerformanceDetail { get; set; }
        public int Accountability { get; set; }
        public string AccountabilityDetail { get; set; }
        public int IndividualBehavior { get; set; }
        public string IndividualBehaviorDetail { get; set; }
        public bool UpgradeConfirmation { get; set; }
        public bool Hidden { get; set; }

        public EmployeeEvaluation()
        {
            
        }

        public EmployeeEvaluation(int listemployeeevaluationid,int theoreticalknowledge,string theoreticalknowledgedetail,
            int experience,string experiencedetail,int skill,string skilldetail,int workperformance,
            string workperformancedetail,int accountability,string accountabilitydetail,int individualbehavior,
            string individualbehaviordetail,bool upgradeconfirmation)
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
