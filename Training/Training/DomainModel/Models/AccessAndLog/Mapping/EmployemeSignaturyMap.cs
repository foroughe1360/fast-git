using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models.AccessAndLog.Mapping 
{
   public class EmployemeSignaturyMap : EntityTypeConfiguration<EmployemeSignatury>
    {
        public EmployemeSignaturyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EmployemeSignaturyId });

            // Properties
            this.Property(t => t.EmployemeSignaturyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

           

            // Table & Column Mappings
            this.ToTable("EmployemeSignaturies");
            this.Property(t => t.EmployemeSignaturyId).HasColumnName("NameOfSignatoryId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.SideSignatoryId).HasColumnName("SideSignatoryId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.EmployemeSignaturyDate).HasColumnName("NameOfSignatoryDate");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
