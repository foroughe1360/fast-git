using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AttendanceMap : EntityTypeConfiguration<Attendance>
    {
        public AttendanceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AttendanceId });

            // Properties
            this.Property(t => t.AttendanceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.HourDelayFrom)
                .HasMaxLength(50);

            this.Property(t => t.HourDelayFrom)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Attendances");
            this.Property(t => t.AttendanceId).HasColumnName("AttendanceId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.AttendanceDateId).HasColumnName("AttendanceDateId");
            this.Property(t => t.CourseRegistrationId).HasColumnName("CourseRegistrationId");
            this.Property(t => t.TypeAttendanceId).HasColumnName("TypeAttendanceId");
            this.Property(t => t.HourDelayFrom).HasColumnName("HourDelayFrom");
            this.Property(t => t.HourDelayTo).HasColumnName("HourDelayTo");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
