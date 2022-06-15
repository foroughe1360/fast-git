using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class InventoryjobMap : EntityTypeConfiguration<Inventoryjob>
    {
        public InventoryjobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.InventoryjobId });

            // Properties
            this.Property(t => t.InventoryjobId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.PostGroupName)
                .HasMaxLength(50);

            this.Property(t => t.AsJobs2)
                .HasMaxLength(100);

            this.Property(t => t.AsJobs3)
                .HasMaxLength(100);

            this.Property(t => t.Education)
                .HasMaxLength(500);

            this.Property(t => t.Experience)
                .HasMaxLength(1000);

            this.Property(t => t.TheoreticalKnowledge)
                .HasMaxLength(1000);

            this.Property(t => t.PercentPhysicalActivity)
                .HasMaxLength(1000);

            this.Property(t => t.PercentMentalActivity)
                .HasMaxLength(1000);

            this.Property(t => t.Qualified)
                .HasMaxLength(1000);

            this.Property(t => t.OtherTraining)
                .HasMaxLength(1000);

            this.Property(t => t.OtherAbilityRequiredJob)
                .HasMaxLength(1000);

            this.Property(t => t.ListCommunityOrganizationComment)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Inventoryjobs");
            this.Property(t => t.InventoryjobId).HasColumnName("InventoryjobId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.SectionId).HasColumnName("SectionId");
            this.Property(t => t.PostGroupName).HasColumnName("PostGroupName");
            this.Property(t => t.NumberEmployees).HasColumnName("NumberEmployees");
            this.Property(t => t.AsJobs2).HasColumnName("AsJobs2");
            this.Property(t => t.AsJobs3).HasColumnName("AsJobs3");
            this.Property(t => t.Education).HasColumnName("Education");
            this.Property(t => t.Experience).HasColumnName("Experience");
            this.Property(t => t.ListResponsibilitiePowerId).HasColumnName("ListResponsibilitiePowerId");
            this.Property(t => t.PercentPhysicalActivity).HasColumnName("PercentPhysicalActivity");
            this.Property(t => t.PercentMentalActivity).HasColumnName("PercentMentalActivity");
            this.Property(t => t.TheoreticalKnowledge).HasColumnName("TheoreticalKnowledge");
            this.Property(t => t.Qualified).HasColumnName("Qualified");
            this.Property(t => t.OtherTraining).HasColumnName("OtherTraining");
            this.Property(t => t.OtherAbilityRequiredJob).HasColumnName("OtherAbilityRequiredJob");
            this.Property(t => t.ListCommunityOrganizationComment).HasColumnName("ListCommunityOrganizationComment");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
