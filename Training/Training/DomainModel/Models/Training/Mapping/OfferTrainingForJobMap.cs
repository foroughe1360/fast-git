using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    class OfferTrainingForJobMap : EntityTypeConfiguration<OfferTrainingForJob>
    {
        public OfferTrainingForJobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OfferTrainingForJobId });

            // Properties
            this.Property(t => t.OfferTrainingForJobId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OfferTrainingForJobs");
            this.Property(t => t.OfferTrainingForJobId).HasColumnName("OfferTrainingForJobId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.OfferTrainingForJobDateId).HasColumnName("OfferTrainingForJobDateId");
            this.Property(t => t.SectionId).HasColumnName("SectionId");
            this.Property(t => t.PostGroupId).HasColumnName("PostGroupId");
            this.Property(t => t.DateNeeds).HasColumnName("DateNeeds");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
