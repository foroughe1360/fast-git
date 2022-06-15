using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class DetailOfferTrainingForJob
    {
        public int DetailOfferTrainingForJobId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int OfferTrainingForJobsId { get; set; }
        public string NeedTraining { get; set; }
        public int PriorityId { get; set; }
        public int TableTypeOfTrainingOfferId { get; set; }
        public int TableTypeOfTrainingSetId { get; set; }
        public bool Hidden { get; set; }
        
        public DetailOfferTrainingForJob()
        {

        }

        public DetailOfferTrainingForJob(int offertrainingforjobsid, string needtraining, int priorityid, int tabletypeOftrainingofferId, int tabletypeOftrainingsetId)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            OfferTrainingForJobsId = offertrainingforjobsid;
            NeedTraining = needtraining;
            PriorityId = priorityid;
            TableTypeOfTrainingOfferId = tabletypeOftrainingofferId;
            TableTypeOfTrainingSetId = tabletypeOftrainingsetId;
            Hidden = false;
        }
    }
}
