using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class MasterRateItMap : EntityTypeConfiguration<MasterRateIt>
    {
        public MasterRateItMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MasterRateItId });

            // Properties
            this.Property(t => t.MasterRateItId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MasterRateIts");
            this.Property(t => t.MasterRateItId).HasColumnName("MasterRateItId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.TypesRateItId).HasColumnName("TypesRateItId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MinRating).HasColumnName("MinRating");
            this.Property(t => t.MaxRating).HasColumnName("MaxRating");
            this.Property(t => t.Parent).HasColumnName("Parent");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
