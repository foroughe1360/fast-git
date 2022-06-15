using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListOfCorporateJobMap : EntityTypeConfiguration<ListOfCorporateJob>
    {
        public ListOfCorporateJobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListOfCorporateJobId });

            // Properties
            this.Property(t => t.ListOfCorporateJobId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("ListOfCorporateJobs");
            this.Property(t => t.ListOfCorporateJobId).HasColumnName("ListOfCorporateJobId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ListOfCorporateJobDateId).HasColumnName("ListOfCorporateJobDateId"); 
            this.Property(t => t.CollectionId).HasColumnName("CollectionId");
            this.Property(t => t.PostTypeId).HasColumnName("PostTypeId");
            this.Property(t => t.NumberOfPeopleEmployed).HasColumnName("NumberOfPeopleEmployed");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
