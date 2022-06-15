using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TrainingCalendarDateMap : EntityTypeConfiguration<TrainingCalendarDate>
    {
        public TrainingCalendarDateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TrainingCalendarDateId });

            // Properties
            this.Property(t => t.TrainingCalendarDateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TrainingCalendarDates");
            this.Property(t => t.TrainingCalendarDateId).HasColumnName("TrainingCalendarDateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.TrCalendarDate).HasColumnName("TrCalendarDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
