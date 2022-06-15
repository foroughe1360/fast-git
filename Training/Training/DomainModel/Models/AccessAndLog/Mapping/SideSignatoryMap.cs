using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class SideSignatoryMap : EntityTypeConfiguration<SideSignatory>
    {
        public SideSignatoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SideSignatoryId });

            // Properties
            this.Property(t => t.SideSignatoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.TitleEN)
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("SideSignatories");
            this.Property(t => t.SideSignatoryId).HasColumnName("SideSignatoryId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.TitleEN).HasColumnName("TitleEN");
            this.Property(t => t.SideSignatoryCode).HasColumnName("SideSignatoryCode");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
