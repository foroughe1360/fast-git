using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class NoteAbsenceMap : EntityTypeConfiguration<NoteAbsence>
    {
        public NoteAbsenceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.NoteAbsenceId });

            // Properties
            this.Property(t => t.NoteAbsenceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("NoteAbsences");
            this.Property(t => t.NoteAbsenceId).HasColumnName("NoteAbsenceId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.AttendanceId).HasColumnName("AttendanceId");
            this.Property(t => t.WrittenNoticeId).HasColumnName("WrittenNoticeId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
