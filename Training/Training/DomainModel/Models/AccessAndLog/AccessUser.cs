using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class AccessUser
    {
        public int AccessUserId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int AccessId { get; set; }
        public int UserId { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public AccessUser()
        {
            
        }

        public AccessUser(int accessid,int userid,bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            AccessId = accessid;
            UserId = userid;
            State = state;
            Hidden = false;
        }
    }
}
