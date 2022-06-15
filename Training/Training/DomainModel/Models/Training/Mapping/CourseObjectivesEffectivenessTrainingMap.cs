using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CourseObjectivesEffectivenessTrainingMap : EntityTypeConfiguration<CourseObjectivesEffectivenessTraining>
    {
        public CourseObjectivesEffectivenessTrainingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CourseObjectivesEffectivenessTrainingId });

            // Properties
            this.Property(t => t.CourseObjectivesEffectivenessTrainingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CourseObjectivesEffectivenessTrainings");
            this.Property(t => t.CourseObjectivesEffectivenessTrainingId).HasColumnName("CourseObjectivesEffectivenessTrainingId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.EffectivenessTrainingId).HasColumnName("EffectivenessTrainingId");
            this.Property(t => t.CourseObjectiveId).HasColumnName("CourseObjectiveId");
            this.Property(t => t.AmountAccessPurposeId).HasColumnName("AmountAccessPurposeId");

            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
