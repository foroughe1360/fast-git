using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListCommunityOrganizationMap : EntityTypeConfiguration<ListCommunityOrganization>
    {
        public ListCommunityOrganizationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ListCommunityOrganizationId });

            // Properties
            this.Property(t => t.ListCommunityOrganizationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GUID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ListCommunityOrganizations");
            this.Property(t => t.ListCommunityOrganizationId).HasColumnName("ListCommunityOrganizationId");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TimeCreated).HasColumnName("TimeCreated");
            this.Property(t => t.TimeLastModified).HasColumnName("TimeLastModified");
            this.Property(t => t.InventoryjobsId).HasColumnName("InventoryjobsId");
            this.Property(t => t.CommunicationOrganizationId).HasColumnName("CommunicationOrganizationId");
            this.Property(t => t.CommunityOrganizationsId).HasColumnName("CommunityOrganizationsId");
            this.Property(t => t.Hidden).HasColumnName("Hidden");
        }
    }
}
