using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class DetailOfferTrainingForJobEntity : DetailOfferTrainingForJob
    {
        public enum DetailOfferTrainingForJob:int
        {
            //pN1 = 219,
	        //pN2 = 220,
	        //pN3 = 221

            pN1 = 225,
            pN2 = 226,
            pN3 = 227
        }


        public string PriorityName { get; set; }
        public bool C { get; set; }
        public bool OJT { get; set; }
        public bool SD { get; set; }
        public bool CSet { get; set; }
        public bool OJTSet { get; set; }
        public bool SDSet { get; set; }
        

        public DetailOfferTrainingForJobEntity() { }
        public DetailOfferTrainingForJobEntity(int offertrainingforjobsid, string needtraining, int priorityid, int tabletypeoftrainingofferId, int tabletypeoftrainingsetId)
            : base(offertrainingforjobsid, needtraining, priorityid, tabletypeoftrainingofferId, tabletypeoftrainingsetId)
        {
        }
    }
}
