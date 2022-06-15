using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AssessmentOfTrainingServiceInformationMap : EntityTypeConfiguration<AssessmentOfTrainingServiceInformation>
    {
        public AssessmentOfTrainingServiceInformationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AssessmentOfTrainingServiceInformationId });

            // Properties
            this.Property(t => t.AssessmentOfTrainingServiceInformationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AssessmentOfTrainingServiceInformations");
            this.Property(t => t.AssessmentOfTrainingServiceInformationId).HasColumnName("AssessmentOfTrainingServiceInformationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
