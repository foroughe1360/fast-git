using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CriterionAssessmentOfTrainingServiceMap : EntityTypeConfiguration<CriterionAssessmentOfTrainingService>
    {
        public CriterionAssessmentOfTrainingServiceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CriterionAssessmentOfTrainingServiceId });

            // Properties
            this.Property(t => t.CriterionAssessmentOfTrainingServiceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CriterionAssessmentOfTrainingServices");
            this.Property(t => t.CriterionAssessmentOfTrainingServiceId).HasColumnName("CriterionAssessmentOfTrainingServiceId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.AssessmentOfTrainingServiceId).HasColumnName("AssessmentOfTrainingServiceId");
            this.Property(t => t.TypeOfEvaluationId).HasColumnName("TypeOfEvaluationId");
            this.Property(t => t.Earnpoints).HasColumnName("Earnpoints");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
