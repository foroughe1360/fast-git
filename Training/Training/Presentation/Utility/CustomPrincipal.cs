using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsInRolesConfigKey(string RolesConfigKey)
        {
            string[] tokens = AccessMenu.Split(',');
            foreach (string item in tokens)
            {
                if (item == RolesConfigKey)
                    return true;
            }
            return false;
            if (AccessMenu.Any(r => RolesConfigKey.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string roles { get; set; }
        public string AccessMenu { get; set; }
    }
}
