using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DetailPlacementTabJobTrainingMap : EntityTypeConfiguration<DetailPlacementTabJobTraining>
    {
        public DetailPlacementTabJobTrainingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DetailPlacementTabJobTrainingId });

            // Properties
            this.Property(t => t.DetailPlacementTabJobTrainingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DetailPlacementTabJobTrainings");
            this.Property(t => t.DetailPlacementTabJobTrainingId).HasColumnName("DetailPlacementTabJobTrainingId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.PlacementTabJobTrainingId).HasColumnName("PlacementTabJobTrainingId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FinalComment).HasColumnName("FinalComment");
            this.Property(t => t.NumberOfHours).HasColumnName("NumberOfHours");
            this.Property(t => t.OJTLevelId).HasColumnName("OJTLevelId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
