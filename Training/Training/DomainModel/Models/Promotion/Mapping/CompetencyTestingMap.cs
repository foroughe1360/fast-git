using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CompetencyTestingMap : EntityTypeConfiguration<CompetencyTesting>
    {
        public CompetencyTestingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompetencyTestingId });

            // Properties
            this.Property(t => t.CompetencyTestingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CompetencyTestings");
            this.Property(t => t.CompetencyTestingId).HasColumnName("CompetencyTestingId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ListQualificationOfStaffId).HasColumnName("ListQualificationOfStaffId");
            this.Property(t => t.LaboratoryTestsId).HasColumnName("LaboratoryTestsId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
