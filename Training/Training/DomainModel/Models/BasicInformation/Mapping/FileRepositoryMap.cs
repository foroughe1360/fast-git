using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class FileRepositoryMap: EntityTypeConfiguration<FileRepository>
    {
        public FileRepositoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FileRepositoryId });

            // Properties
            this.Property(t => t.FileRepositoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.FileName)
                .HasMaxLength(50);

            this.Property(t => t.ContentType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FileRepositories");
            this.Property(t => t.FileRepositoryId).HasColumnName("FileRepositoryId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ContentId).HasColumnName("ContentId");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.ContentType).HasColumnName("ContentType");
            this.Property(t => t.ContentLength).HasColumnName("ContentLength");
            this.Property(t => t.FileFormId).HasColumnName("FileFormId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
