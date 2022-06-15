using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class JobGroupMap : EntityTypeConfiguration<JobGroup>
    {
        public JobGroupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.JobGroupId });

            // Properties
            this.Property(t => t.JobGroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.JobGroupName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("JobGroups");
            this.Property(t => t.JobGroupId).HasColumnName("JobGroupId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.JobGroupName).HasColumnName("JobGroupName");
            this.Property(t => t.PonitJobGroup).HasColumnName("PonitJobGroup");
            this.Property(t => t.GroupNumber).HasColumnName("GroupNumber");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
