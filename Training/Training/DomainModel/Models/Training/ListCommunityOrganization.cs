using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListCommunityOrganization
    {
        public int ListCommunityOrganizationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int InventoryjobsId { get; set; }
        public int CommunicationOrganizationId { get; set; }
        public int CommunityOrganizationsId { get; set; }
        public bool Hidden { get; set; }

        public ListCommunityOrganization()
        {
            
        }

        public ListCommunityOrganization(int inventoryjobsid,int communicationorganizationid,int communityorganizationsid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            InventoryjobsId = inventoryjobsid;
            CommunicationOrganizationId = communicationorganizationid;
            CommunityOrganizationsId = communityorganizationsid;
            Hidden = false;
        }
    }
}
