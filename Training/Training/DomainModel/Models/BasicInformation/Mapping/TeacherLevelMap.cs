using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TeacherLevelMap : EntityTypeConfiguration<TeacherLevel>
    {
        public TeacherLevelMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TeacherLevelId });

            // Properties
            this.Property(t => t.TeacherLevelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.TrainingCourse)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TeacherLevels");
            this.Property(t => t.TeacherLevelId).HasColumnName("TeacherLevelId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified"); 
            this.Property(t => t.TeacherLevelDateId).HasColumnName("TeacherLevelDateId");
            this.Property(t => t.TeacherId).HasColumnName("TeacherId");
            this.Property(t => t.TrainingCourse).HasColumnName("TrainingCourse");
            this.Property(t => t.EffectivenessOfPreviousPeriod).HasColumnName("EffectivenessOfPreviousPeriod");
            this.Property(t => t.Rhetorical).HasColumnName("Rhetorical");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.Experience).HasColumnName("Experience");
            this.Property(t => t.CoursePlan).HasColumnName("CoursePlan");
            this.Property(t => t.HistoryOfCooperation).HasColumnName("HistoryOfCooperation");
            this.Property(t => t.Degree).HasColumnName("Degree");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
