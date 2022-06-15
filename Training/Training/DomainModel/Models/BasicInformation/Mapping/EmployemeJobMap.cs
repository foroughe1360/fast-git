using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EmployemeJobMap : EntityTypeConfiguration<EmployemeJob>
    {
        public EmployemeJobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EmployemeJobId });

            // Properties
            this.Property(t => t.EmployemeJobId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EmployemeJobs");
            this.Property(t => t.EmployemeJobId).HasColumnName("EmployemeJobId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.PostGroupId).HasColumnName("PostGroupId");
            this.Property(t => t.SectionId).HasColumnName("SectionId");
            this.Property(t => t.DateStartPostGroupName).HasColumnName("DateStartPostGroupName");
            this.Property(t => t.ActivePostGroupName).HasColumnName("ActivePostGroupName");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
