using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DesignTrainingCourseMap : EntityTypeConfiguration<DesignTrainingCourse>
    {
        public DesignTrainingCourseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DesignTrainingCourseId });

            // Properties
            this.Property(t => t.DesignTrainingCourseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.CourseObjectives)
                .HasMaxLength(1500);

            this.Property(t => t.CourseContent)
                .HasMaxLength(1500);

            this.Property(t => t.OtherNotes)
                .HasMaxLength(1500);

            this.Property(t => t.HoursHolding)
                .HasMaxLength(150);

            this.Property(t => t.ListLearningAssistToolComment)
                .HasMaxLength(1000);



            // Table & Column Mappings
            this.ToTable("DesignTrainingCourses");
            this.Property(t => t.DesignTrainingCourseId).HasColumnName("DesignTrainingCourseId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DesignTrainingCourseDateId).HasColumnName("DesignTrainingCourseDateId");
            this.Property(t => t.TrainingCourseId).HasColumnName("TrainingCourseId");
            this.Property(t => t.TeacherId).HasColumnName("TeacherId");
            this.Property(t => t.TookHold).HasColumnName("TookHold");
            this.Property(t => t.TrainingVenueId).HasColumnName("TrainingVenueId");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.NumberOfParticipants).HasColumnName("NumberOfParticipants");
            this.Property(t => t.CostCourses).HasColumnName("CostCourses");
            this.Property(t => t.CourseObjectives).HasColumnName("CourseObjectives");
            this.Property(t => t.CourseContent).HasColumnName("CourseContent");
            this.Property(t => t.OtherNotes).HasColumnName("OtherNotes");
            this.Property(t => t.ExamDates).HasColumnName("ExamDates");
            this.Property(t => t.TypesOfTrainingId).HasColumnName("TypesOfTrainingId");
            this.Property(t => t.MaximumScore).HasColumnName("MaximumScore");
            this.Property(t => t.HoursHolding).HasColumnName("HoursHolding");
            this.Property(t => t.MinutesHolding).HasColumnName("MinutesHolding");
            this.Property(t => t.ListLearningAssistToolComment).HasColumnName("ListLearningAssistToolComment");
            this.Property(t => t.EffectivenessOfCourse).HasColumnName("EffectivenessOfCourse");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
