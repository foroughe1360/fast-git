using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DeviceCollectionMap : EntityTypeConfiguration<DeviceCollection>
    {
        public DeviceCollectionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DeviceCollectionId });

            // Properties
            this.Property(t => t.DeviceCollectionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.JobDeviceCollection)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DeviceCollections");
            this.Property(t => t.DeviceCollectionId).HasColumnName("DeviceCollectionId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.CollectionsId).HasColumnName("CollectionsId");
            this.Property(t => t.JobDeviceCollection).HasColumnName("JobDeviceCollection");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
