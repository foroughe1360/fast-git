using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public  class AssessmentOfTrainingServiceMap : EntityTypeConfiguration<AssessmentOfTrainingService>
    {
        public AssessmentOfTrainingServiceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AssessmentOfTrainingServiceId });

            // Properties
            this.Property(t => t.AssessmentOfTrainingServiceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.InstitutionName)
                .HasMaxLength(50);

            this.Property(t => t.ManagingDirector)
                .HasMaxLength(50);

            this.Property(t => t.ScopeOfTheActivities)
                .HasMaxLength(50);

            this.Property(t => t.TeacherName)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("AssessmentOfTrainingServices");
            this.Property(t => t.AssessmentOfTrainingServiceId).HasColumnName("AssessmentOfTrainingServiceId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.InstitutionName).HasColumnName("InstitutionName");
            this.Property(t => t.ManagingDirector).HasColumnName("ManagingDirector");
            this.Property(t => t.TypeOfCompanyId).HasColumnName("TypeOfCompanyId");
            this.Property(t => t.TypeOfInstitutionId).HasColumnName("TypeOfInstitutionId");
            this.Property(t => t.ScopeOfTheActivities).HasColumnName("ScopeOfTheActivities");
            this.Property(t => t.EconomicCode).HasColumnName("EconomicCode");
            this.Property(t => t.TeacherName).HasColumnName("TeacherName");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
