using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class PostGroupMap : EntityTypeConfiguration<PostGroup>
    {
        public PostGroupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PostGroupId });

            // Properties
            this.Property(t => t.PostGroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PostGroups");
            this.Property(t => t.PostGroupId).HasColumnName("PostGroupId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.CollectionId).HasColumnName("CollectionId");
            this.Property(t => t.PostTypeId).HasColumnName("PostTypeId");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
