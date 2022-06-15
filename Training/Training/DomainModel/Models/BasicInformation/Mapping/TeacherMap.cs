using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TeacherId });

            // Properties
            this.Property(t => t.TeacherId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Family)
                .HasMaxLength(50);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Teachers");
            this.Property(t => t.TeacherId).HasColumnName("TeacherId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.DateOfEmployement).HasColumnName("DateOfEmployement");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
