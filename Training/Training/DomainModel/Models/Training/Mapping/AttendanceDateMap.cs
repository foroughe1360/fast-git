using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AttendanceDateMap : EntityTypeConfiguration<AttendanceDate>
    {
        public AttendanceDateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AttendanceDateId });

            // Properties
            this.Property(t => t.AttendanceDateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AttendanceDates");
            this.Property(t => t.AttendanceDateId).HasColumnName("AttendanceDateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DesignTrainingCourseId).HasColumnName("DesignTrainingCourseId");
            this.Property(t => t.AttendanceAbsenceDate).HasColumnName("AttendanceAbsenceDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
