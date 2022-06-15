using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
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
    public class UserProvider : IUserProvider
    {
        private UserDAC _UserDAC;
        public UserProvider()
        {
            _UserDAC = new UserDAC();
        }

        public int Add(UserEntity Current)
        {
            General _General = new General();
            var keyNew = _General.GeneratePassword(10);
            var password = _General.EncodePassword(Current.Password, keyNew);
            User _User = new User(Current.UserGUID,Current.FirstName,Current.LastName,Current.IsActive,Current.UserName,password,keyNew,Current.RoleId);
            return _UserDAC.Add(_User);
        }

        public bool Delete(int ID)
        {
            return _UserDAC.Delete(ID);
        }

        public bool Edit(UserEntity Current)
        {
            User _User = new User();
            _User.UserId = Current.UserId;
            _User.TimeLastModified = DateTime.Now;
            _User.FirstName = Current.FirstName;
            _User.LastName = Current.LastName;
            _User.UserName = Current.UserName;
            _User.IsActive = Current.IsActive;
            _User.RoleId = Current.RoleId;
            return _UserDAC.Edit(_User);
        }

        public bool Edit(int ID,string password)
        {
            General _General = new General();
            var keyNew = _General.GeneratePassword(10);
            var Password = _General.EncodePassword(password, keyNew);
            var TimeLastModified = DateTime.Now;
            return _UserDAC.Edit(ID,TimeLastModified, Password, keyNew);
        }

        public UserEntity Get(int ID)
        {
            UserEntity _UserEntity = new UserEntity();
            var q = _UserDAC.Get(ID);
            _UserEntity.UserId = q.UserId;
            _UserEntity.LastName = q. LastName;
            _UserEntity.FirstName = q.FirstName;
            _UserEntity.IsActive = q.IsActive;
            _UserEntity.UserName = q.UserName;
            _UserEntity.RoleId = q.RoleId;
            return _UserEntity;
        }

        public UserEntity Get(string UserName)
        {
            UserEntity _UserEntity = new UserEntity();
            var q = _UserDAC.Get(UserName);
            if (q != null)
            {
                _UserEntity.UserId = q.UserId;
                _UserEntity.LastName = q.LastName;
                _UserEntity.FirstName = q.FirstName;
                _UserEntity.IsActive = q.IsActive;
                _UserEntity.UserName = q.UserName;
                _UserEntity.Password = q.Password;
                _UserEntity.VCode = q.VCode;
                _UserEntity.Roles = q.Roles;
            }
            else
                _UserEntity = null;
            return _UserEntity;
        }

        public UserEntity Get(string UserName,string password)
        {
            UserEntity _UserEntity = new UserEntity();
            var q = _UserDAC.Get(UserName, password);
            if (q != null)
            {
                _UserEntity.UserId = q.UserId;
                _UserEntity.LastName = q.LastName ;
                _UserEntity.FirstName = q.FirstName;
                _UserEntity.IsActive = q.IsActive;
                _UserEntity.UserName = q.UserName;
                _UserEntity.VCode = q.VCode;
                _UserEntity.Password = q.Password;
            }
            else
                _UserEntity = null;
            return _UserEntity;
        }

        public IQueryable<UserEntity> GetAll()
        {
            return _UserDAC.GetAllUser();
        }

        //--------------------------------------------------------------------------
        //Operation Active Directory razi.cc
        public bool ValidateAgainstADAndGroup(string username, string password, string groupname)
        {
            var ok = false;
            using (var pc = new PrincipalContext(ContextType.Domain, "razi.cc"))
            {
                if (pc.ValidateCredentials(username, password))
                {
                    //User is alright
                    using (var searcher = new PrincipalSearcher(new UserPrincipal(pc)))
                    {
                        searcher.QueryFilter.SamAccountName = username;
                        Principal u = searcher.FindOne();
                        foreach (Principal p in u.GetGroups())
                        {
                            if (p.Name == groupname)
                            {
                                //User is in group
                                ok = true;
                            }
                        }
                    }
                }
            }

            return ok;
        }

        //Return List All Users in Activr Directory
        public List<UserEntity> listuser ()
        {
            List<UserEntity> listuserentity = new List<UserEntity>();
            using (var context = new PrincipalContext(ContextType.Domain, "razi.cc"))
            {
                bool isValid = context.ValidateCredentials("mortezaei", "2081363!@#");

                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        UserEntity _UserEntity = new UserEntity();
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        //string s = (string)de.Properties. .Value;
                        _UserEntity.FirstName = (string)de.Properties["givenName"].Value;
                        _UserEntity.LastName = (string)de.Properties["sn"].Value;
                        _UserEntity.UserName = (string)de.Properties["sAMAccountName"].Value;
                        _UserEntity.UserNameFamily = (string)de.Properties["displayname"].Value;
                        _UserEntity.UserGUID = de.Guid.ToString();
                        listuserentity.Add(_UserEntity);
                    }
                }
            }
            return listuserentity;
        }

        public UserEntity UserInfo(string username)
        {
            var list = listuser();
            return list.FirstOrDefault(a => a.UserName == username);
        }
    }
}
