using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class SignatureResponsibility
    {
        public int SignatureResponsibilityId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int UserId { get; set; }
        public int EmployemeId { get; set; }
        public Byte[] Signature { get; set; }
        public bool Hidden { get; set; }

        public SignatureResponsibility()
        {

        }

        public SignatureResponsibility(int userid, int employemeid, Byte[] signature)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            UserId = userid;
            EmployemeId = employemeid;
            Signature = signature;
            Hidden = false;
        }
    }
}
