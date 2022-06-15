using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TableTypeOfTrainingEntity: TableTypeOfTraining
    {
        public TableTypeOfTrainingEntity()
        {

        }

        public TableTypeOfTrainingEntity(int tableid, int usedtableid, bool c, bool sd, bool ojt)
        {
            TableId = tableid;
            UsedTableId = usedtableid;
            C = c;
            Sd = sd;
            Ojt = Ojt;
        }
    }
}
