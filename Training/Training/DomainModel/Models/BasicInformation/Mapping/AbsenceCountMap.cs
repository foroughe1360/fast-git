using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AbsenceCountMap : EntityTypeConfiguration<AbsenceCount>
    {
        public AbsenceCountMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AbsenceCountId });

            // Properties
            this.Property(t => t.AbsenceCountId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("AbsenceCounts");
            this.Property(t => t.AbsenceCountId).HasColumnName("AbsenceCountId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.MaxAbsenceCount).HasColumnName("MaxAbsenceCount");
            this.Property(t => t.AbsenceCountDate).HasColumnName("AbsenceCountDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
