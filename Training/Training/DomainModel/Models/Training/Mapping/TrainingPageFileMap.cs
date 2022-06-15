using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TrainingPageFileMap : EntityTypeConfiguration<TrainingPageFile>
    {
        public TrainingPageFileMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TrainingPageFileId });

            // Properties
            this.Property(t => t.TrainingPageFileId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.TrainingPageFileDesc)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("TrainingPageFiles");
            this.Property(t => t.TrainingPageFileId).HasColumnName("TrainingPageFileId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DetialHistoryTrainingUploadPageId).HasColumnName("DetialHistoryTrainingUploadPageId");
            this.Property(t => t.FileScan).HasColumnName("FileScan");
            this.Property(t => t.TrainingPageFileDesc).HasColumnName("TrainingPageFileDesc");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
