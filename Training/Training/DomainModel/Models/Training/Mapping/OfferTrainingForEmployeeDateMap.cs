using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OfferTrainingForEmployeeDateMap : EntityTypeConfiguration<OfferTrainingForEmployeeDate>
    {
        public OfferTrainingForEmployeeDateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OfferTrainingForEmployeeDateId });

            // Properties
            this.Property(t => t.OfferTrainingForEmployeeDateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(100);


            // Table & Column Mappings
            this.ToTable("OfferTrainingForEmployeeDates");
            this.Property(t => t.OfferTrainingForEmployeeDateId).HasColumnName("OfferTrainingForEmployeeDateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.OTFJDate).HasColumnName("OTFJDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
