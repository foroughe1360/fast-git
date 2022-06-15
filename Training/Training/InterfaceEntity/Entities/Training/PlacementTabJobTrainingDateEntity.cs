using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class PlacementTabJobTrainingDateEntity: PlacementTabJobTrainingDate
    {
        public string PTJTDatetStr { get; set; }
        public PlacementTabJobTrainingDateEntity()
        {

        }

        public PlacementTabJobTrainingDateEntity(string description, DateTime ptjtdate) :base(description, ptjtdate)
        {

        }
    }
}
