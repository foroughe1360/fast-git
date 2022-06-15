using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class AccessMenuUserEntity: AccessMenuUser
    {
        public string AccessTypeName { get; set; }
        public string MenuName { get; set; }
        public string UserNameFamily { get; set; }
        public bool Opened { get; set; }
        public bool disabled { get; set; }
        public bool Selected { get; set; }
        public int Parent { get; set; }
        public AccessMenuUserEntity()
        {

        }

        public AccessMenuUserEntity(int userid, int menuid, int accesstypeid, bool status)
        {
            UserId = userid;
            MenuId = menuid;
            AccessTypeId = accesstypeid;
            Status = status;
        }
    }
}
