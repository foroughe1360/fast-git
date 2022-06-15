using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListPhysicalConditionMap : EntityTypeConfiguration<ListPhysicalCondition>
    {
        public ListPhysicalConditionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListPhysicalConditionId });

            // Properties
            this.Property(t => t.ListPhysicalConditionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListPhysicalConditions");
            this.Property(t => t.ListPhysicalConditionId).HasColumnName("ListPhysicalConditionId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.InventoryjobsId).HasColumnName("InventoryjobsId");
            this.Property(t => t.PhysicalConditionsId).HasColumnName("PhysicalConditionsId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
