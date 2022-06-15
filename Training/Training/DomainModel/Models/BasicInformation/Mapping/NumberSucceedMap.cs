using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class NumberSucceedMap : EntityTypeConfiguration<NumberSucceed>
    {
        public NumberSucceedMap()
        {
            // Primary Key
            this.HasKey(t => new { t.NumberSucceedId });

            // Properties
            this.Property(t => t.NumberSucceedId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            

            // Table & Column Mappings
            this.ToTable("NumberSucceeds");
            this.Property(t => t.NumberSucceedId).HasColumnName("NumberSucceedId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.NumberSucceedDate).HasColumnName("NumberSucceedDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
