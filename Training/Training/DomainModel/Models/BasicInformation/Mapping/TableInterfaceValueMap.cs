using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TableInterfaceValueMap : EntityTypeConfiguration<TableInterfaceValue>
    {
        public TableInterfaceValueMap()
        {
            //Primary Key
            this.HasKey(t => new { t.TableInterfaceValueId });

            // Properties
            this.Property(t => t.TableInterfaceValueId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.TableValue)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TableInterfaceValues");
            this.Property(t => t.TableInterfaceValueId).HasColumnName("TableInterfaceValueId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.TableInterfaceId).HasColumnName("TableInterfaceId");
            this.Property(t => t.TableValue).HasColumnName("TableValue");
            this.Property(t => t.TableInterfaceValueCode).HasColumnName("TableInterfaceValueCode");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
