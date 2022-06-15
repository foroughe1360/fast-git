using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class PlacementTabJobTrainingDateMap : EntityTypeConfiguration<PlacementTabJobTrainingDate>
    {
        public PlacementTabJobTrainingDateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PlacementTabJobTrainingDateId });

            // Properties
            this.Property(t => t.PlacementTabJobTrainingDateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PlacementTabJobTrainingDates");
            this.Property(t => t.PlacementTabJobTrainingDateId).HasColumnName("PlacementTabJobTrainingDateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PTJTDate).HasColumnName("PTJTDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
