using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AccessUserMap : EntityTypeConfiguration<AccessUser>
    {
        public AccessUserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AccessUserId });

            // Properties
            this.Property(t => t.AccessUserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AccessUsers");
            this.Property(t => t.AccessUserId).HasColumnName("AccessUserId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.AccessId).HasColumnName("AccessId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
