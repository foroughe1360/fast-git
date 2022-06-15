using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EvaluationTrainingProgramMap : EntityTypeConfiguration<EvaluationTrainingProgram>
    {
        public EvaluationTrainingProgramMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EvaluationTrainingProgramId });

            // Properties
            this.Property(t => t.EvaluationTrainingProgramId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EvaluationTrainingPrograms");
            this.Property(t => t.EvaluationTrainingProgramId).HasColumnName("EvaluationTrainingProgramId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ContentQuestionsId).HasColumnName("ContentQuestionsId");
            this.Property(t => t.ScoreEducationIdForContentQuestionsId).HasColumnName("ScoreEducationIdForContentQuestionsId");
            this.Property(t => t.DirectorEducationQuestionId).HasColumnName("DirectorEducationQuestionId");
            this.Property(t => t.CourseRegistrationId).HasColumnName("CourseRegistrationId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
