using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TableTypeOfTraining
    {
        public int TableTypeOfTrainingId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TableId { get; set; }
        public int UsedTableId { get; set; }
        public bool C { get; set; }
        public bool Sd { get; set; }
        public bool Ojt { get; set; }
        public bool Hidden { get; set; }

        public TableTypeOfTraining()
        {
            
        }

        public TableTypeOfTraining(int tableid,int usedtableid,bool c,bool sd,bool ojt)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TableId = tableid;
            UsedTableId = usedtableid;
            C = c;
            Sd = sd;
            Ojt = ojt;
            Hidden = false;
        }
    }
}
