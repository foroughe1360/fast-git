using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class DesignTrainingCourseDateMap : EntityTypeConfiguration<DesignTrainingCourseDate>
    {
        public DesignTrainingCourseDateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DesignTrainingCourseDateId });

            // Properties
            this.Property(t => t.DesignTrainingCourseDateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("DesignTrainingCourseDates");
            this.Property(t => t.DesignTrainingCourseDateId).HasColumnName("DesignTrainingCourseDateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DTCDate).HasColumnName("DTCDate");
            this.Property(t => t.FinancialYear).HasColumnName("FinancialYear");

            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
