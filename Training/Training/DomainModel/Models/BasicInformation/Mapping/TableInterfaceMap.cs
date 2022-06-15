using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TableInterfaceMap : EntityTypeConfiguration<TableInterface>
    {
        public TableInterfaceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TableInterfaceId });

            // Properties
            this.Property(t => t.TableInterfaceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.TableName)
                .HasMaxLength(500);

            this.Property(t => t.TableNameFarsi)
               .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("TableInterfaces");
            this.Property(t => t.TableInterfaceId).HasColumnName("TableInterfaceId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.TableName).HasColumnName("TableName");
            this.Property(t => t.TableNameFarsi).HasColumnName("TableNameFarsi");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
