using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Assessor
    {
        public int AssessorId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int UserId { get; set; }
        public bool Hidden { get; set; }

        public Assessor()
        {

        }

        public Assessor(int userid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            UserId = userid;
            Hidden = false;
        }
    }
}
