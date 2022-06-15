using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class CodingTrainingPageMap : EntityTypeConfiguration<CodingTrainingPage>
    {
        public CodingTrainingPageMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CodingTrainingPageId });

            // Properties
            this.Property(t => t.CodingTrainingPageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CodingTrainings");
            this.Property(t => t.CodingTrainingPageId).HasColumnName("CodingTrainingPageId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.TrainingPageCode).HasColumnName("TrainingPageCode");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
