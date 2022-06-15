using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
   public class HardwareInformationMap : EntityTypeConfiguration<HardwareInformation>
    {
        public HardwareInformationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HardwareInformationId });

            // Properties
            this.Property(t => t.HardwareInformationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            // one-to-many
            //this.HasRequired(x => x.Employeme)
            //    .WithMany(x => x.ICollectionHardwareInformation)
            //    .HasForeignKey(m => m.EmployemeId)
            //    .WillCascadeOnDelete(false);


            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HardwareInformations");
            this.Property(t => t.HardwareInformationId).HasColumnName("HardwareInformationId");
            this.Property(t => t.HardwareEquipmentId).HasColumnName("HardwareEquipmentId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.NetworkID).HasColumnName("NetworkID");
            this.Property(t => t.NetworkIP).HasColumnName("NetworkIP");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.Descriptions).HasColumnName("Descriptions");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");

        }
    }
}
