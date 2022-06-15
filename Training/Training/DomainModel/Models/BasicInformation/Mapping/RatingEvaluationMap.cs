using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class RatingEvaluationMap : EntityTypeConfiguration<RatingEvaluation>
    {
        public RatingEvaluationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RatingEvaluationId });

            // Properties
            this.Property(t => t.RatingEvaluationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RatingEvaluations");
            this.Property(t => t.RatingEvaluationId).HasColumnName("RatingEvaluationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.RatingEvaluationCoursesID).HasColumnName("RatingEvaluationCoursesID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.RatingEvaluationDate).HasColumnName("RatingEvaluationDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
