using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class PointEntity: Point
    {
        public string Typ { get; set; }
        public string detailtyperateName { get; set; }

        public PointEntity()
        {

        }

        public PointEntity(int detailtyperateid, string pointname, int numpoint):base(detailtyperateid,pointname,numpoint)
        {
        }
    }
}
