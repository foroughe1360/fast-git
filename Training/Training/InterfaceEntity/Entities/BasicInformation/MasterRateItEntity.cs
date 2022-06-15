using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class MasterRateItEntity: MasterRateIt
    {
        public string TypesRateItName { get; set; }

        public MasterRateItEntity()
        {

        }

        public MasterRateItEntity(int typesrateitid, string name, double minrating, double maxrating, int parent)
            :base(typesrateitid, name, minrating,maxrating, parent)
        {
        }
    }
}
