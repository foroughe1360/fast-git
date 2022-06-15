using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class NameOfSignatoryMap : EntityTypeConfiguration<NameOfSignatory>
    {
        public NameOfSignatoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.NameOfSignatoryId });

            // Properties
            this.Property(t => t.NameOfSignatoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("NameOfSignatories");
            this.Property(t => t.NameOfSignatoryId).HasColumnName("NameOfSignatoryId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.SideSignatoryId).HasColumnName("SideSignatoryId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.NameOfSignatoryDate).HasColumnName("NameOfSignatoryDate");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
