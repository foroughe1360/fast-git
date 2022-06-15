using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class OfferTrainingForEmployeeDateEntity : OfferTrainingForEmployeeDate
    {
        public string OTFJDateStr { get; set; }
        public OfferTrainingForEmployeeDateEntity()
        {

        }
        public OfferTrainingForEmployeeDateEntity(string description, DateTime otfjdate) : base(description, otfjdate)
        {

        }
    }
}
