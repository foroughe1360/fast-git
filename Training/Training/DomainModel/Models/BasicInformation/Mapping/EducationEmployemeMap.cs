using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EducationEmployemeMap : EntityTypeConfiguration<EducationEmployeme>
    {
        public EducationEmployemeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EducationEmployemeId });

            // Properties
            this.Property(t => t.EducationEmployemeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.FieldOfStudy)
                .HasMaxLength(50);

            this.Property(t => t.AcademicOrientation)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EducationEmployemes");
            this.Property(t => t.EducationEmployemeId).HasColumnName("EducationEmployemeId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.FieldOfStudy).HasColumnName("FieldOfStudy");
            this.Property(t => t.AcademicOrientation).HasColumnName("AcademicOrientation");
            this.Property(t => t.DateOfGraduation).HasColumnName("DateOfGraduation"); 
            this.Property(t => t.LastEducationalCertificate).HasColumnName("LastEducationalCertificate");
            this.Property(t => t.TableTypeOfUniversityId).HasColumnName("TableTypeOfUniversityId");
            this.Property(t => t.NameOfUniversity).HasColumnName("NameOfUniversity");
            this.Property(t => t.ActiveTypeOfUniversity).HasColumnName("ActiveTypeOfUniversity");

            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
