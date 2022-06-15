using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OfferTrainingForEmployemeMap : EntityTypeConfiguration<OfferTrainingForEmployeme>
    {
        public OfferTrainingForEmployemeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OfferTrainingForEmployemeId });

            // Properties
            this.Property(t => t.OfferTrainingForEmployemeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OfferTrainingForEmployemes");
            this.Property(t => t.OfferTrainingForEmployemeId).HasColumnName("OfferTrainingForEmployemeId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.OfferTrainingForEmployeeDateId).HasColumnName("OfferTrainingForEmployeeDateId");
            this.Property(t => t.SectionId).HasColumnName("SectionId");
            this.Property(t => t.PostGroupId).HasColumnName("PostGroupId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.DateNeeds).HasColumnName("DateNeeds");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
