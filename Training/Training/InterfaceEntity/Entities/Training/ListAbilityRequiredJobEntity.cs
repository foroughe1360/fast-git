using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class ListAbilityRequiredJobEntity: ListAbilityRequiredJob
    {
        public enum ListAbilityRequiredJob : int
        {

            EffectiveCommunications=152,
            TeamWork=153,
            TheSessions=154,
            ConflictManagement=155,
            Leadership=156,
            CrisisManagement=157,
            PresentationAndLecturing=158,
            OtherCases=159
        }
        public string ListAbilityRequiredJobName { get; set; }
        public bool ListAbilityRequiredJobState { get; set; }

        public bool State { get; set; }

        public ListAbilityRequiredJobEntity()
        {

        }

        public ListAbilityRequiredJobEntity(int inventoryjobsid, int abilityrequiredjobid)
        {
            InventoryjobsId = inventoryjobsid;
            AbilityRequiredJobId = abilityrequiredjobid;
        }
    }
}
