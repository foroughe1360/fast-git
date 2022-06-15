using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TypeOfEvaluationMap : EntityTypeConfiguration<TypeOfEvaluation>
    {
        public TypeOfEvaluationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TypeOfEvaluationId });

            // Properties
            this.Property(t => t.TypeOfEvaluationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Title)
               .HasMaxLength(50);

                                      

            // Table & Column Mappings
            this.ToTable("TypeOfEvaluations");
            this.Property(t => t.TypeOfEvaluationId).HasColumnName("TypeOfEvaluationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.MaxScore).HasColumnName("MaxScore");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
