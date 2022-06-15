using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
  public  class PlacementTabJobTrainingMap : EntityTypeConfiguration<PlacementTabJobTraining>
    {
        public PlacementTabJobTrainingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PlacementTabJobTrainingId });

            // Properties
            this.Property(t => t.PlacementTabJobTrainingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.PreviousJobs)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("PlacementTabJobTrainings");
            this.Property(t => t.PlacementTabJobTrainingId).HasColumnName("PlacementTabJobTrainingId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.PlacementTabJobTrainingDateId).HasColumnName("PlacementTabJobTrainingDateId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.PostGroupId).HasColumnName("PostGroupId");
            this.Property(t => t.SectionId).HasColumnName("SectionId");
            this.Property(t => t.DateStartPostGroupName).HasColumnName("DateStartPostGroupName");
            this.Property(t => t.PreviousJobs).HasColumnName("PreviousJobs");
            this.Property(t => t.CorporateResponsibility).HasColumnName("CorporateResponsibility");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
