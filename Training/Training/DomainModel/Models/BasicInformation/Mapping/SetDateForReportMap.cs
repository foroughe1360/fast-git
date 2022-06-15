using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class SetDateForReportMap : EntityTypeConfiguration<SetDateForReport>
    {
        public SetDateForReportMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SetDateForReportId });

            // Properties
            this.Property(t => t.SetDateForReportId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SetDateForRepors");
            this.Property(t => t.SetDateForReportId).HasColumnName("SetDateForReportId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ReportNameId).HasColumnName("ReportNameId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.PublicCode).HasColumnName("PublicCode");
            this.Property(t => t.DateOfProducer).HasColumnName("DateOfProducer");
            this.Property(t => t.DateOfApprover).HasColumnName("DateOfApprover");
            this.Property(t => t.DateOfRegistrar).HasColumnName("DateOfRegistrar");
            
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
