using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListLearningAssistToolMap : EntityTypeConfiguration<ListLearningAssistTool>
    {
        public ListLearningAssistToolMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListLearningAssistToolId });

            // Properties
            this.Property(t => t.ListLearningAssistToolId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListLearningAssistTools");
            this.Property(t => t.ListLearningAssistToolId).HasColumnName("ListLearningAssistToolId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.DesignTrainingCourseId).HasColumnName("DesignTrainingCourseId");
            this.Property(t => t.LearningAssistToolId).HasColumnName("LearningAssistToolId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
