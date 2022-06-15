using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OperationLogMap : EntityTypeConfiguration<OperationLog>
    {
        public OperationLogMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OperationLogId });

            // Properties
            this.Property(t => t.OperationLogId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.HostName)
                .HasMaxLength(50);

            this.Property(t => t.UserSystem)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OperationLogs");
            this.Property(t => t.OperationLogId).HasColumnName("OperationLogId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.TableId).HasColumnName("TableId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.OperationTypeId).HasColumnName("OperationTypeId");
            this.Property(t => t.FormId).HasColumnName("FormId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.HostName).HasColumnName("HostName");
            this.Property(t => t.UserSystem).HasColumnName("UserSystem");
            this.Property(t => t.RecordId).HasColumnName("RecordId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
