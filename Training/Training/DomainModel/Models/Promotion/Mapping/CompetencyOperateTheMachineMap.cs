using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{ 
    public class CompetencyOperateTheMachineMap : EntityTypeConfiguration<CompetencyOperateTheMachine>
    {
        public CompetencyOperateTheMachineMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompetencyOperateTheMachineId });

            // Properties
            this.Property(t => t.CompetencyOperateTheMachineId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CompetencyOperateTheMachines");
            this.Property(t => t.CompetencyOperateTheMachineId).HasColumnName("CompetencyOperateTheMachineId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ListQualificationOfStaffId).HasColumnName("ListQualificationOfStaffId");
            this.Property(t => t.LaboratoryDevicesId).HasColumnName("LaboratoryDevicesId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
