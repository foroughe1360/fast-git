using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AccessMenuUserMap : EntityTypeConfiguration<AccessMenuUser>
    {
        public AccessMenuUserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AccessMenuUserId });

            // Properties
            this.Property(t => t.AccessMenuUserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AccessMenuUsers");
            this.Property(t => t.AccessMenuUserId).HasColumnName("AccessMenuUserId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.AccessTypeId).HasColumnName("AccessTypeId");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
