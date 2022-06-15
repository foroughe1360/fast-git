using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListTrainingRequiredMap : EntityTypeConfiguration<ListTrainingRequired>
    {
        public ListTrainingRequiredMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListTrainingRequiredId });

            // Properties
            this.Property(t => t.ListTrainingRequiredId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ListTrainingRequireds");
            this.Property(t => t.ListTrainingRequiredId).HasColumnName("ListTrainingRequiredId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.InventoryjobsId).HasColumnName("InventoryjobsId");
            //this.Property(t => t.TrainingRequiredId).HasColumnName("TrainingRequiredId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.TableTypeOfTrainingFaceId).HasColumnName("TableTypeOfTrainingFaceId");

            this.Property(t => t.TitleTraining).HasColumnName("TitleTraining");
            this.Property(t => t.SDTime).HasColumnName("SDTime");
            this.Property(t => t.OJTTime).HasColumnName("OJTTime");
            this.Property(t => t.CTime).HasColumnName("CTime");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
