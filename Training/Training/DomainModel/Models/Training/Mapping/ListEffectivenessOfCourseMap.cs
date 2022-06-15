using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListEffectivenessOfCourseMap : EntityTypeConfiguration<ListEffectivenessOfCourse>
    {
        public ListEffectivenessOfCourseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListEffectivenessOfCourseId });

            // Properties
            this.Property(t => t.ListEffectivenessOfCourseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListEffectivenessOfCourses");
            this.Property(t => t.ListEffectivenessOfCourseId).HasColumnName("ListEffectivenessOfCourseId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DesignTrainingCourseId).HasColumnName("DesignTrainingCourseId");
            this.Property(t => t.EffectivenessOfCoursesId).HasColumnName("EffectivenessOfCoursesId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
