
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string UserGUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VCode { get; set; }
        public int RoleId { get; set; }
        public bool Hidden { get; set; }
        public User()
        {
            
        }

        public User(string userguid, string firstname,string lastname,bool isactive,string username,string password,string vcode,int roleid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            UserGUID = userguid;
            FirstName = firstname;
            LastName = lastname ;
            IsActive = isactive;
            UserName = username;
            Password = password;
            VCode = vcode;
            RoleId = roleid;
            Hidden = false;
        }
    }
}
