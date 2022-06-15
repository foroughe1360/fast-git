using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class PointMap: EntityTypeConfiguration<Point>
    {
        public PointMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PointId });

            // Properties
            this.Property(t => t.PointId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.PointName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Points");
            this.Property(t => t.PointId).HasColumnName("PointId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DetailTypeRateId).HasColumnName("DetailTypeRateId");
            this.Property(t => t.PointName).HasColumnName("PointName");
            this.Property(t => t.NumPoint).HasColumnName("NumPoint");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
