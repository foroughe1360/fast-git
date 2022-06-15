using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class HistoryQualificationOfStaffMap : EntityTypeConfiguration<HistoryQualificationOfStaff>
    {
        public HistoryQualificationOfStaffMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HistoryQualificationOfStaffId });

            // Properties
            this.Property(t => t.HistoryQualificationOfStaffId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HistoryQualificationOfStaffs");
            this.Property(t => t.HistoryQualificationOfStaffId).HasColumnName("HistoryQualificationOfStaffId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.SignatureResponsibilityId).HasColumnName("SignatureResponsibilityId");
            this.Property(t => t.StageNameId).HasColumnName("StageNameId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.WorkFlowState).HasColumnName("WorkFlowState");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
