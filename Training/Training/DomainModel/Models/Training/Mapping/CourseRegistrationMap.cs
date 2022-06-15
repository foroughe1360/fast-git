using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CourseRegistrationMap : EntityTypeConfiguration<CourseRegistration>
    {
        public CourseRegistrationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CourseRegistrationId });

            // Properties
            this.Property(t => t.CourseRegistrationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CourseRegistrations");
            this.Property(t => t.CourseRegistrationId).HasColumnName("CourseRegistrationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DesignTrainingCourseId).HasColumnName("DesignTrainingCourseId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.EmployemeStateID).HasColumnName("EmployemeStateID");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
