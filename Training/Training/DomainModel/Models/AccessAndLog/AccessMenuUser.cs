using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class AccessMenuUser
    {
        public int AccessMenuUserId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public int AccessTypeId { get; set; }
        public bool Status { get; set; }
        public bool Hidden { get; set; }
         
        public AccessMenuUser()
        {
            
        }

        public AccessMenuUser(int userid,int menuid,int accesstypeid,bool status)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            UserId = userid;
            MenuId = menuid;
            AccessTypeId = accesstypeid;
            Status = status;
            Hidden = false;
        }
    }
}
