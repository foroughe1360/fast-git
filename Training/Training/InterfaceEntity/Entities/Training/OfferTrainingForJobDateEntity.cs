using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class OfferTrainingForJobDateEntity: OfferTrainingForJobDate
    {
        public string OTFJDateStr { get; set; }
        public OfferTrainingForJobDateEntity()
        {

        }

        public OfferTrainingForJobDateEntity(string description, DateTime otfjdate) :base(description, otfjdate)
        {

        }
    }
}
