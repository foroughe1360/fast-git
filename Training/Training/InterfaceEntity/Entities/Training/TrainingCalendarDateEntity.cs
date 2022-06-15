using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TrainingCalendarDateEntity: TrainingCalendarDate
    {
        public string TrCalendarDateStr { get; set; }
        public TrainingCalendarDateEntity()
        {

        }

        public TrainingCalendarDateEntity(string description, DateTime trcalendardate) :base(description, trcalendardate)
        {

        }
    }
}
