using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TrainingCourseMap : EntityTypeConfiguration<TrainingCourse>
    {
        public TrainingCourseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TrainingCourseId });

            // Properties
            this.Property(t => t.TrainingCourseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.CourseName)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("TrainingCourses");
            this.Property(t => t.TrainingCourseId).HasColumnName("TrainingCourseId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.CourseName).HasColumnName("CourseName"); 
                this.Property(t => t.CourseTypeId).HasColumnName("CourseTypeId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
