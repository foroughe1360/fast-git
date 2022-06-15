using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AssessorMap : EntityTypeConfiguration<Assessor>
    {
        public AssessorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AssessorId });

            // Properties
            this.Property(t => t.AssessorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Assessors");
            this.Property(t => t.AssessorId).HasColumnName("AssessorId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
