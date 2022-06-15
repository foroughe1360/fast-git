using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class HoursCertificationMap : EntityTypeConfiguration<HoursCertification>
    {
        public HoursCertificationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HoursCertificationId });

            // Properties
            this.Property(t => t.HoursCertificationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HoursCertifications");
            this.Property(t => t.HoursCertificationId).HasColumnName("HoursCertificationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.TimePeriod).HasColumnName("TimePeriod");
            this.Property(t => t.HoursCertificationDate).HasColumnName("HoursCertificationDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
