using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class DetailPlacementTabJobTrainingEntity : DetailPlacementTabJobTraining
    {
        public int OJTLevelName { get; set; }
        public String OJTLevelDescription { get; set; }

        public DetailPlacementTabJobTrainingEntity() { }
        public DetailPlacementTabJobTrainingEntity(int placementtabJobtrainingid, string title, string finalcomment, double numberofhours, int ojtlevelId)
               : base(placementtabJobtrainingid, title, finalcomment, numberofhours, ojtlevelId)
        {
        }
    }
}
