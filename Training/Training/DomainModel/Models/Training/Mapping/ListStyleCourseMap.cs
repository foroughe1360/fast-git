using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListStyleCourseMap : EntityTypeConfiguration<ListStyleCourse>
    {
        public ListStyleCourseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListStyleCourseId });

            // Properties
            this.Property(t => t.ListStyleCourseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListStyleCourses");
            this.Property(t => t.ListStyleCourseId).HasColumnName("ListStyleCourseId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DesignTrainingCourseId).HasColumnName("DesignTrainingCourseId");
            this.Property(t => t.StyleCoursesId).HasColumnName("StyleCoursesId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
