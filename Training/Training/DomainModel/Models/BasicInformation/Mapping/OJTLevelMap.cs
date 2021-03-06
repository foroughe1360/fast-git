using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainModel.Models
{
    public class OJTLevelMap : EntityTypeConfiguration<OJTLevel>
    {
        public OJTLevelMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OJTLevelId });

            // Properties
            this.Property(t => t.OJTLevelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.LevelNumber);

            this.Property(t => t.Description)
                .HasMaxLength(1000);
            

            // Table & Column Mappings
            this.ToTable("OJTLevels");
            this.Property(t => t.OJTLevelId).HasColumnName("OJTLevelId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.LevelNumber).HasColumnName("LevelNumber");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
