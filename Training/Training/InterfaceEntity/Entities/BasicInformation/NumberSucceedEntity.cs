using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class NumberSucceedEntity: NumberSucceed
    {
        public string NumberSucceedDateStr { get; set; }
        public NumberSucceedEntity()
        {

        }

        public NumberSucceedEntity(int number, DateTime numbersucceeddate) :base(number,numbersucceeddate)
        {

        }
    }
}
