using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report.Training.ListCommunityOrganization
{
    public class CommunityOrganization
    {
        public bool Facetoface { get; set; }
        public bool written { get; set; }
        public bool AutomationAndNetwork { get; set; }
        public bool Phone { get; set; }
        public bool SmsAndMobile { get; set; }
        public bool Email { get; set; }
        public bool Session { get; set; }
        public bool Other { get; set; } 
    }
}
