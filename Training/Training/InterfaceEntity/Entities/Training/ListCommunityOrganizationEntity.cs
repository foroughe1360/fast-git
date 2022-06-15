using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public  class ListCommunityOrganizationEntity: ListCommunityOrganization
    {
        public enum CommunicationOrganization : int
        {

            //UpstreamCommunications = 228,
            //ExternalCommunication = 229,
            //CommunicationRow = 230,
            //DownstreamCommunications = 231

            UpstreamCommunications = 257,
            ExternalCommunication = 258,
            CommunicationRow = 259,
            DownstreamCommunications = 260
        }

        public enum ListCommunityOrganization : int
        {

            Facetoface = 160,
            written = 161,
            AutomationAndNetwork = 162,
            Phone = 163,
            SmsAndMobile = 164,
            Email = 165,
            Session = 166,
            Other = 167
        }

        public string ListCommunityOrganizationName { get; set; }
        public bool ListCommunityOrganizationState { get; set; }
        public bool State { get; set; }

        public ListCommunityOrganizationEntity() { }

        public ListCommunityOrganizationEntity(int inventoryjobsid,int communicationorganizationid, int communityorganizationsid)
            :base(inventoryjobsid, communicationorganizationid, communityorganizationsid)
        {
            
        }
    }
}
