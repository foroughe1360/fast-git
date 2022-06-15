using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EmployeeTrainingPassedMap : EntityTypeConfiguration<EmployeeTrainingPassed>
    {
        public EmployeeTrainingPassedMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EmployeeTrainingPassedId });

            // Properties
            this.Property(t => t.EmployeeTrainingPassedId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EmployeeTrainingPasseds");
            this.Property(t => t.EmployeeTrainingPassedId).HasColumnName("EmployeeTrainingPassedId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Employemeid).HasColumnName("Employemeid");
            this.Property(t => t.TrainingCourseId).HasColumnName("TrainingCourseId");
            this.Property(t => t.TableTypeOfTrainingId).HasColumnName("TableTypeOfTrainingId");
            this.Property(t => t.TrainingVenueId).HasColumnName("TrainingVenueId");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.DateCourse).HasColumnName("DateCourse");
            this.Property(t => t.CertificateState).HasColumnName("CertificateState");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
