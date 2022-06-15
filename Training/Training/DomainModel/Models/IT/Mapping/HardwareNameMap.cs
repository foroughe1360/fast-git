﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
   public class HardwareNameMap : EntityTypeConfiguration<HardwareName>
    {
        public HardwareNameMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HardwareNameId });

            // Properties
            this.Property(t => t.HardwareNameId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HardwareNames");
            this.Property(t => t.HardwareNameId).HasColumnName("HardwareNameId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.HardwareTitle).HasColumnName("HardwareTitle");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}