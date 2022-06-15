using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TariffEntity: Tariff
    {
        public string CourseTypeName{ get; set; }
        public string TariffDateStr { get; set; }
        public TariffEntity()
        {

        }

        public TariffEntity(Int64 cost, int coursetypeid, DateTime tariffdate):
            base(cost, coursetypeid, tariffdate)
        {

        }
    }
}
