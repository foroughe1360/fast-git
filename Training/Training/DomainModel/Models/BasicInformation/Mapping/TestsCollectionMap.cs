using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TestsCollectionMap : EntityTypeConfiguration<TestsCollection>
    {
        public TestsCollectionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TestsCollectionId });

            // Properties
            this.Property(t => t.TestsCollectionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);
            this.Property(t => t.TestsCollectionName)
               .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TestsCollections");
            this.Property(t => t.TestsCollectionId).HasColumnName("TestsCollectionId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.CollectionId).HasColumnName("CollectionId");
            this.Property(t => t.TestsCollectionName).HasColumnName("TestsCollectionName");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
