using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListQualificationOfStaffMap : EntityTypeConfiguration<ListQualificationOfStaff>
    {
        public ListQualificationOfStaffMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListQualificationOfStaffId });

            // Properties
            this.Property(t => t.ListQualificationOfStaffId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListQualificationOfStaffs");
            this.Property(t => t.ListQualificationOfStaffId).HasColumnName("ListQualificationOfStaffId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.EmployemesId).HasColumnName("EmployemesId");
            this.Property(t => t.CollectionId).HasColumnName("CollectionId");
            this.Property(t => t.TrainingManagerApprovalDate).HasColumnName("TrainingManagerApprovalDate");
            this.Property(t => t.TrainingManagerApproval).HasColumnName("TrainingManagerApproval");
            this.Property(t => t.CompetencyTestingDatetime).HasColumnName("CompetencyTestingDatetime");
            this.Property(t => t.CompetencyTesting).HasColumnName("CompetencyTesting");
            this.Property(t => t.CompetencyOperateTheMachineDatetime).HasColumnName("CompetencyOperateTheMachineDatetime");
            this.Property(t => t.CompetencyOperateTheMachine).HasColumnName("CompetencyOperateTheMachine");
            this.Property(t => t.CompetencyTestingType).HasColumnName("CompetencyTestingType");
            this.Property(t => t.CompetencyOperateTheMachineType).HasColumnName("CompetencyOperateTheMachineType");
            this.Property(t => t.CompilingReports).HasColumnName("CompilingReports");
            this.Property(t => t.AnalysisAndInterpretationOfResults).HasColumnName("AnalysisAndInterpretationOfResults");
            this.Property(t => t.InitialVerificationReport).HasColumnName("InitialVerificationReport");
            this.Property(t => t.TheFinalVerificationReport).HasColumnName("TheFinalVerificationReport");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
