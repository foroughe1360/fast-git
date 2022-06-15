using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class HoursCertificationEntity: HoursCertification
    {
        public string HoursCertificationDateStr { get; set; }
        public HoursCertificationEntity()
        {

        }

        public HoursCertificationEntity(int timeperiod, DateTime hourscertificationdate) :base(timeperiod, hourscertificationdate)
        {

        }
    }
}
