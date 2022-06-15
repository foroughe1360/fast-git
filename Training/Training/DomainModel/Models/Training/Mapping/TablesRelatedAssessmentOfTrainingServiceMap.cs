using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TablesRelatedAssessmentOfTrainingServiceMap : EntityTypeConfiguration<TablesRelatedAssessmentOfTrainingService>
    {
        public TablesRelatedAssessmentOfTrainingServiceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TablesRelatedAssessmentOfTrainingServiceId });

            // Properties
            this.Property(t => t.TablesRelatedAssessmentOfTrainingServiceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Value)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TablesRelatedAssessmentOfTrainingServices");
            this.Property(t => t.TablesRelatedAssessmentOfTrainingServiceId).HasColumnName("TablesRelatedAssessmentOfTrainingServiceId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.AssessmentOfTrainingServiceInformationId).HasColumnName("AssessmentOfTrainingServiceInformationId");
            this.Property(t => t.AssessmentOfTrainingServiceId).HasColumnName("AssessmentOfTrainingServiceId");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
