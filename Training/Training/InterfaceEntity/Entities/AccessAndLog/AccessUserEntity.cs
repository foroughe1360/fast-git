using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class AccessUserEntity : AccessUser
    {
        public AccessUserEntity()
        {

        }

        public AccessUserEntity(int accessid, int userid, bool state)
        {
            AccessId = accessid;
            UserId = userid;
            State = state;
        }
    }
}
