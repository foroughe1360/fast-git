using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListHealthConditionMap : EntityTypeConfiguration<ListHealthCondition>
    {
        public ListHealthConditionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListHealthConditionId });

            // Properties
            this.Property(t => t.ListHealthConditionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.Description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("ListHealthConditions");
            this.Property(t => t.ListHealthConditionId).HasColumnName("ListHealthConditionId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.InventoryjobsId).HasColumnName("InventoryjobsId");
            this.Property(t => t.HealthConditionsId).HasColumnName("HealthConditionsId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
