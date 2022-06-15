using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class DetailOfferTrainingForEmployemeReport
    {
        public string NeedTraining { get; set; }
        public bool SuggestedSD { get; set; }
        public bool SuggestedOJT { get; set; }
        public bool SuggestedC { get; set; }
        public bool ApprovalSD { get; set; }
        public bool ApprovalOJT { get; set; }
        public bool ApprovalC { get; set; }
        public string Priority { get; set; }
        public bool PN1 { get; set; }
        public bool PN2 { get; set; }
        public bool PN3 { get; set; }
    }
}
