using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DetailTypeRateMap: EntityTypeConfiguration<DetailTypeRate>
    {
        public DetailTypeRateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DetailTypeRateId });

            // Properties
            this.Property(t => t.DetailTypeRateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.DetailTypeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DetailTypeRates");
            this.Property(t => t.DetailTypeRateId).HasColumnName("DetailTypeRateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.TypesRateId).HasColumnName("TypesRateId");
            this.Property(t => t.Parent).HasColumnName("Parent");
            this.Property(t => t.DetailTypeName).HasColumnName("DetailTypeName");
            this.Property(t => t.NumDetailType).HasColumnName("NumDetailType");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
