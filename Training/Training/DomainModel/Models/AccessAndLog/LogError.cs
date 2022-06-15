using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class LogError
    {
        public int LogErrorId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int FormId { get; set; }
        public string ErrorMessage { get; set; }
        public int OperationTypeId { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }

        public LogError()
        {
            
        }

        public LogError(int formid,string errormessage,int operationtypeid, string description)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            FormId = formid;
            ErrorMessage = errormessage;
            OperationTypeId = operationtypeid;
            Description = description;
            Hidden = false;
        }
    }
}
