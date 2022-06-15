using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EmployeeEvaluationMap : EntityTypeConfiguration<EmployeeEvaluation>
    {
        public EmployeeEvaluationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EmployeeEvaluationId });

            // Properties
            this.Property(t => t.EmployeeEvaluationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EmployeeEvaluations");
            this.Property(t => t.EmployeeEvaluationId).HasColumnName("EmployeeEvaluationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ListEmployeeEvaluationId).HasColumnName("ListEmployeeEvaluationId");
            this.Property(t => t.TheoreticalKnowledge).HasColumnName("TheoreticalKnowledge");
            this.Property(t => t.TheoreticalKnowledgeDetail).HasColumnName("TheoreticalKnowledgeDetail");
            this.Property(t => t.Experience).HasColumnName("Experience");
            this.Property(t => t.ExperienceDetail).HasColumnName("ExperienceDetail");
            this.Property(t => t.Skill).HasColumnName("Skill");
            this.Property(t => t.SkillDetail).HasColumnName("SkillDetail");
            this.Property(t => t.WorkPerformance).HasColumnName("WorkPerformance");
            this.Property(t => t.WorkPerformanceDetail).HasColumnName("WorkPerformanceDetail");
            this.Property(t => t.Accountability).HasColumnName("Accountability");
            this.Property(t => t.AccountabilityDetail).HasColumnName("AccountabilityDetail");
            this.Property(t => t.IndividualBehavior).HasColumnName("IndividualBehavior");
            this.Property(t => t.IndividualBehaviorDetail).HasColumnName("IndividualBehaviorDetail");
            this.Property(t => t.UpgradeConfirmation).HasColumnName("UpgradeConfirmation");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
