using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TestScoreMap : EntityTypeConfiguration<TestScore>
    {
        public TestScoreMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TestScoreId });

            // Properties
            this.Property(t => t.TestScoreId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TestScores");
            this.Property(t => t.TestScoreId).HasColumnName("TestScoreId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.ListTypeTestScoresId).HasColumnName("ListTypeTestScoresId"); 
            this.Property(t => t.CourseRegistrationId).HasColumnName("CourseRegistrationId");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
