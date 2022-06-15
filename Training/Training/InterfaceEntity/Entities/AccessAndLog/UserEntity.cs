using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class UserEntity :User
    {
        public string UserNameFamily { get; set; }
        public string Roles { get; set; }
        public string AccessMenu { get; set; }
        public UserEntity()
        {

        }

        public UserEntity(string userguid ,string firstname, string lastname, bool isactive, string username, string password,string vcode,int roleid)
            :base(userguid,firstname, lastname, isactive, username,password,vcode,roleid)
        {
        }
        
    }
}
