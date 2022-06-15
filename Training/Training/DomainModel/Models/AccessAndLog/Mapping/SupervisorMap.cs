using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models.AccessAndLog.Mapping
{
    public class SupervisorMap : EntityTypeConfiguration<Supervisor>
    {
        public SupervisorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SupervisorId });

            // Properties
            this.Property(t => t.SupervisorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            

            // Table & Column Mappings
            this.ToTable("Supervisors");
            this.Property(t => t.SupervisorId).HasColumnName("SupervisorId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
