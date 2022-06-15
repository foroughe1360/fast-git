using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TrainingCalendarMap : EntityTypeConfiguration<TrainingCalendar>
    {
        public TrainingCalendarMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TrainingCalendarId });

            // Properties
            this.Property(t => t.TrainingCalendarId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.Participantlevel)
                .HasMaxLength(500);
            this.Property(t => t.Description)
                .HasMaxLength(1000);

            this.Property(t => t.TrainingCalendarDay)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TrainingCalendars");
            this.Property(t => t.TrainingCalendarId).HasColumnName("TrainingCalendarId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified"); 
            this.Property(t => t.TrainingCalendarDateId).HasColumnName("TrainingCalendarDateId");
            this.Property(t => t.CourseName).HasColumnName("CourseName");
            this.Property(t => t.TeacherId).HasColumnName("TeacherId");
            this.Property(t => t.Participantlevel).HasColumnName("Participantlevel");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.TrainingCalendarDate).HasColumnName("TrainingCalendarDate");
            this.Property(t => t.TrainingCalendarDay).HasColumnName("TrainingCalendarDay");
            this.Property(t => t.TableTypeTrainingCalendarDateId).HasColumnName("TableTypeTrainingCalendarDateId");
            
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
