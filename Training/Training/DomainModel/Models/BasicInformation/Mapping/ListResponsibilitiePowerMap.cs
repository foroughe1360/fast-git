using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListResponsibilitiePowerMap:EntityTypeConfiguration<ListResponsibilitiePower>
    {
        public ListResponsibilitiePowerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListResponsibilitiePowerId });

            // Properties
            this.Property(t => t.ListResponsibilitiePowerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);



            // Table & Column Mappings
            this.ToTable("ListResponsibilitiePowers");
            this.Property(t => t.ListResponsibilitiePowerId).HasColumnName("ListResponsibilitiePowerId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.PostGroupId).HasColumnName("PostGroupId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
