using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EffectivenessTrainingMap : EntityTypeConfiguration<EffectivenessTraining>
    {
        public EffectivenessTrainingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EffectivenessTrainingId });

            // Properties
            this.Property(t => t.EffectivenessTrainingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EffectivenessTrainings");
            this.Property(t => t.EffectivenessTrainingId).HasColumnName("EffectivenessTrainingId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.CourseRegistrationId).HasColumnName("CourseRegistrationId");
            this.Property(t => t.EffectivenessTrainingDate).HasColumnName("EffectivenessTrainingDate");
           this.Property(t => t.SupervisorId).HasColumnName("SupervisorId");
            this.Property(t => t.CorrectiveactionDescription).HasColumnName("CorrectiveactionDescription");
            this.Property(t => t.Correctiveaction).HasColumnName("Correctiveaction");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
