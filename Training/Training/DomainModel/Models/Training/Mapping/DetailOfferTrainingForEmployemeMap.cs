using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DetailOfferTrainingForEmployemeMap : EntityTypeConfiguration<DetailOfferTrainingForEmployeme>
    {
        public DetailOfferTrainingForEmployemeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DetailOfferTrainingForEmployemeId });

            // Properties
            this.Property(t => t.DetailOfferTrainingForEmployemeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DetailOfferTrainingForEmployemes");
            this.Property(t => t.DetailOfferTrainingForEmployemeId).HasColumnName("DetailOfferTrainingForEmployemeId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.OfferTrainingForEmployemesId).HasColumnName("OfferTrainingForEmployemesId");
            this.Property(t => t.NeedTraining).HasColumnName("NeedTraining");
            this.Property(t => t.PriorityId).HasColumnName("PriorityId");
            this.Property(t => t.TableTypeOfTrainingOfferId).HasColumnName("TableTypeOfTrainingOfferId");
            this.Property(t => t.TableTypeOfTrainingSetId).HasColumnName("TableTypeOfTrainingSetId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }

}
