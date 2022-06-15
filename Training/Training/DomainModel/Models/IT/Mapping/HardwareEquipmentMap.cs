using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class HardwareEquipmentMap : EntityTypeConfiguration<HardwareEquipment>
    {
        public HardwareEquipmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HardwareEquipmentId });

            // Properties
            this.Property(t => t.HardwareEquipmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HardwareEquipments");
            this.Property(t => t.HardwareEquipmentId).HasColumnName("HardwareEquipmentId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.EquipmentNameId).HasColumnName("EquipmentNameId");
            this.Property(t => t.EquipmentModel).HasColumnName("EquipmentModel");
            this.Property(t => t.PropertyNumber).HasColumnName("PropertyNumber");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");

        }
    }
}
