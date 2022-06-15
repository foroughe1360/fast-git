using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models 
{
    public class ListEmployeeEvaluationMap : EntityTypeConfiguration<ListEmployeeEvaluation>
    {
        public ListEmployeeEvaluationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListEmployeeEvaluationId });

            // Properties
            this.Property(t => t.ListEmployeeEvaluationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListEmployeeEvaluations");
            this.Property(t => t.ListEmployeeEvaluationId).HasColumnName("ListEmployeeEvaluationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.EmployemesId).HasColumnName("EmployemesId");
            this.Property(t => t.AssessorsId).HasColumnName("AssessorsId");
            this.Property(t => t.AssessorTypeId).HasColumnName("AssessorTypeId");
            this.Property(t => t.Ver).HasColumnName("Ver");
            this.Property(t => t.Ver).HasColumnName("EmployeeEvaluationState");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
