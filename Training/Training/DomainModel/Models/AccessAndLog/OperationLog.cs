using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class OperationLog
    {
        public int OperationLogId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TableId { get; set; }
        public string Description { get; set; }
        public int OperationTypeId { get; set; }
        public int FormId { get; set; }
        public int UserId { get; set; }
        public string HostName { get; set; }
        public string UserSystem { get; set; }
        public int RecordId { get; set; }
        public bool Hidden { get; set; }

        public OperationLog()
        {
            
        }

        public OperationLog(int tableid,string description,int operationtypeid, int formid,int userid,string hostname,string usersystem,int recordid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TableId = tableid;
            Description = description;
            OperationTypeId = operationtypeid;
            FormId = formid;
            UserId = userid;
            HostName = hostname;
            UserSystem = usersystem;
            RecordId = recordid;
            Hidden = false;
        }
    }
}
