using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class NumberSucceed
    {
        public int NumberSucceedId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int Number { get; set; }
        public DateTime NumberSucceedDate { get; set; }
        public bool Hidden { get; set; }

        public NumberSucceed()
        {

        }

        public NumberSucceed(int number,DateTime numbersucceeddate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Number = number;
            NumberSucceedDate = numbersucceeddate;
            Hidden = false;
        }
    }
}
