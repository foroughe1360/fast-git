using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TableInterface
    {
        public int TableInterfaceId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string TableName { get; set; }
        public string TableNameFarsi { get; set; }
        public bool Hidden { get; set; }        

        public TableInterface()
        {
            
        }
        public TableInterface(string tableName,string tablenamefarsi)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TableName = tableName;
            TableNameFarsi = tablenamefarsi;
            Hidden = false;
        }
    }
}
