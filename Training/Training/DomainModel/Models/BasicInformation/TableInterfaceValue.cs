using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TableInterfaceValue
    {
        
        public int TableInterfaceValueId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TableInterfaceId { get; set; }
        public string TableValue { get; set; }
        public int TableInterfaceValueCode { get; set; }
        public bool Hidden { get; set; }

        public TableInterfaceValue()
        {

        }

        public TableInterfaceValue(int tableinterfaceid, string tablevalue,int tableinterfacevaluecode)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TableInterfaceId = tableinterfaceid;
            TableValue = tablevalue;
            TableInterfaceValueCode = tableinterfacevaluecode;
            Hidden = false;
        }
    }
}
