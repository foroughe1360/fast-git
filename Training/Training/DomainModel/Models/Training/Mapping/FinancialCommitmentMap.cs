using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class FinancialCommitmentMap : EntityTypeConfiguration<FinancialCommitment>
    {
        public FinancialCommitmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FinancialCommitmentId });

            // Properties
            this.Property(t => t.FinancialCommitmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FinancialCommitments");
            this.Property(t => t.FinancialCommitmentId).HasColumnName("FinancialCommitmentId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.TrainingCourseId).HasColumnName("TrainingCourseId");
            this.Property(t => t.TrainingVenueId).HasColumnName("TrainingVenueId");
            this.Property(t => t.AmountPierced).HasColumnName("AmountPierced");
            this.Property(t => t.TimeEmployment).HasColumnName("TimeEmployment");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.FinancialYear).HasColumnName("FinancialYear");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
