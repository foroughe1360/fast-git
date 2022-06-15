using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class LogErrorMap : EntityTypeConfiguration<LogError>
    {
        public LogErrorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.LogErrorId });

            // Properties
            this.Property(t => t.LogErrorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.ErrorMessage)
                .HasMaxLength(1000);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LogErrors");
            this.Property(t => t.LogErrorId).HasColumnName("LogErrorId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.FormId).HasColumnName("FormId");
            this.Property(t => t.ErrorMessage).HasColumnName("ErrorMessage");
            this.Property(t => t.OperationTypeId).HasColumnName("OperationTypeId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
