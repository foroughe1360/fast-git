using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class HistoryTrainingUploadPageMap : EntityTypeConfiguration<HistoryTrainingUploadPage>
    {
        public HistoryTrainingUploadPageMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HistoryTrainingUploadPageId });

            // Properties
            this.Property(t => t.HistoryTrainingUploadPageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.HTUPDescripption)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("HistoryTrainingUploadPages");
            this.Property(t => t.HistoryTrainingUploadPageId).HasColumnName("HistoryTrainingUploadPageId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.HTUPDescripption).HasColumnName("HTUPDescripption");
            this.Property(t => t.HistoryTrainingUploadPageDate).HasColumnName("HistoryTrainingUploadPageDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
