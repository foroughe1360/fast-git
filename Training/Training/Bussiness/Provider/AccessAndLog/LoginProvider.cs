using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class LoginProvider
    {
        public UserEntity DoesUserExist(string userName,string password)
        {
            UserProvider _UserProvider = new UserProvider();
            UserEntity _UserEntity = new UserEntity();
            General _General = new General();

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "Razi"))
            {
                using (var foundUser = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, userName))
                {
                    if (foundUser == null)
                        return null;
                    // find the group in question
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, "Training");
                    // check if user is member of that group
                    if (foundUser.IsMemberOf(group))
                    {
                        //check Uer from DB
                        var userinfo = _UserProvider.Get(userName);
                        if (userinfo != null)
                        {
                            var hashCode = userinfo.VCode;
                            //Password Hasing Process Call Helper Class Method
                            var encodingPasswordString = _General.EncodePassword(password, hashCode);

                            //Check Login Detail User Name Or Password
                            if (userinfo.Password == encodingPasswordString)
                                return userinfo;
                        }
                        //check password from DB
                        //_UserEntity = _UserProvider.Get(userName,password);
                        //return _UserEntity;
                    } 
                }
            }
            return null;
        } 
    }
}
