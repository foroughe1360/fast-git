using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    class TableTypeOfTrainingMap : EntityTypeConfiguration<TableTypeOfTraining>
    {
        public TableTypeOfTrainingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TableTypeOfTrainingId });

            // Properties
            this.Property(t => t.TableTypeOfTrainingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TableTypeOfTrainings");
            this.Property(t => t.TableTypeOfTrainingId).HasColumnName("TableTypeOfTrainingId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.TableId).HasColumnName("TableId");
            this.Property(t => t.UsedTableId).HasColumnName("UsedTableId");
            this.Property(t => t.C).HasColumnName("C");
            this.Property(t => t.Sd).HasColumnName("Sd");
            this.Property(t => t.Ojt).HasColumnName("Ojt");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
