﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListOfCorporateJobDateMap : EntityTypeConfiguration<ListOfCorporateJobDate>
    {
        public ListOfCorporateJobDateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListOfCorporateJobDateId });

            // Properties
            this.Property(t => t.ListOfCorporateJobDateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ListOfCorporateJobDates");
            this.Property(t => t.ListOfCorporateJobDateId).HasColumnName("ListOfCorporateJobDateId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LOCJDate).HasColumnName("LOCJDate");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
