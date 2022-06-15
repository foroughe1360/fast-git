using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EmployemeMap : EntityTypeConfiguration<Employeme>
    {
        public EmployemeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EmployemeId });

            // Properties
            this.Property(t => t.EmployemeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.FirstName)
               .HasMaxLength(50);
            this.Property(t => t.LastName)
               .HasMaxLength(50);
            this.Property(t => t.FatherName)
               .HasMaxLength(50);
            this.Property(t => t.PlaceOfBirth)
               .HasMaxLength(50);
            this.Property(t => t.FieldOfStudy)
               .HasMaxLength(50);
            this.Property(t => t.IDNumber)
               .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Employemes");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FatherName).HasColumnName("FatherName");
            this.Property(t => t.PlaceOfBirth).HasColumnName("PlaceOfBirth");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.FieldOfStudy).HasColumnName("FieldOfStudy");
            this.Property(t => t.IDNumber).HasColumnName("IDNumber");
            this.Property(t => t.DateOfEmployement).HasColumnName("DateOfEmployement");
            this.Property(t => t.PersonnelCode).HasColumnName("PersonnelCode");
            this.Property(t => t.NationalCode).HasColumnName("NationalCode");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
