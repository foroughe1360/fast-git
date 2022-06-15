using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TariffMap : EntityTypeConfiguration<Tariff>
    {
        public TariffMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TariffId });

            // Properties
            this.Property(t => t.TariffId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tariffs");
            this.Property(t => t.TariffId).HasColumnName("TariffId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.CourseTypeId).HasColumnName("CourseTypeId");
            this.Property(t => t.TariffDate).HasColumnName("TariffDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
