using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class ListAbilityRequiredJobReport
    {
        public bool EffectiveCommunications { get; set; }
        public bool TeamWork { get; set; }
        public bool TheSessions { get; set; }
        public bool ConflictManagement { get; set; }
        public bool Leadership { get; set; }
        public bool CrisisManagement { get; set; }
        public bool PresentationAndLecturing { get; set; }
        public bool OtherCases { get; set; }

        public ListAbilityRequiredJobReport()
        {
            EffectiveCommunications = false;
            TeamWork = false;
            TheSessions = false;
            ConflictManagement = false;
            Leadership = false;
            CrisisManagement = false;
            PresentationAndLecturing = false;
            OtherCases = false;
        }
    }
}
