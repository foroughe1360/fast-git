using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DepartmentMap:EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DepartmentId });

            // Properties
            this.Property(t => t.DepartmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.Name)
                .HasMaxLength(50);

            

            // Table & Column Mappings
            this.ToTable("Departments");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.UnitSCenterId).HasColumnName("UnitSCenterId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }

    }
}
