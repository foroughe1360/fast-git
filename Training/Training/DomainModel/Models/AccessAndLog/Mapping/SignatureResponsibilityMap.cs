﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class SignatureResponsibilityMap : EntityTypeConfiguration<SignatureResponsibility>
    {
        public SignatureResponsibilityMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SignatureResponsibilityId });

            // Properties
            this.Property(t => t.SignatureResponsibilityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SignatureResponsibilities");
            this.Property(t => t.SignatureResponsibilityId).HasColumnName("SignatureResponsibilityId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.EmployemeId).HasColumnName("EmployemeId");
            this.Property(t => t.Signature).HasColumnName("Signature");;
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
