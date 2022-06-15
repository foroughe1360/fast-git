using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListAbilityRequiredJobMap : EntityTypeConfiguration<ListAbilityRequiredJob>
    {
        public ListAbilityRequiredJobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListAbilityRequiredJobId });

            // Properties
            this.Property(t => t.ListAbilityRequiredJobId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListAbilityRequiredJobs");
            this.Property(t => t.ListAbilityRequiredJobId).HasColumnName("ListAbilityRequiredJobId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.InventoryjobsId).HasColumnName("InventoryjobsId");
            this.Property(t => t.AbilityRequiredJobId).HasColumnName("AbilityRequiredJobId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
