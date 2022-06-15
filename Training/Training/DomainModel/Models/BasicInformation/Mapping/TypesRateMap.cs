using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TypesRateMap : EntityTypeConfiguration<TypesRate>
    {
        public TypesRateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TypesRateId });

            // Properties
            this.Property(t => t.TypesRateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.RateName)
               .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TypesRates");
            this.Property(t => t.TypesRateId).HasColumnName("TypesRateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.RateName).HasColumnName("RateName");
            this.Property(t => t.NumberRate).HasColumnName("NumberRate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
