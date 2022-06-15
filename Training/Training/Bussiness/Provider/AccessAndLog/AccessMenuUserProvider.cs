using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class AccessMenuUserProvider : IAccessMenuUserProvider
    {
        private AccessMenuUserDAC _AccessMenuUserDAC;
        private OperationLog _OperationLog;

        public AccessMenuUserProvider()
        {
            _AccessMenuUserDAC = new AccessMenuUserDAC();
            _OperationLog = new OperationLog();
        }

        public int Add(AccessMenuUserEntity Current)
        {
            AccessMenuUser _AccessMenuUser = new AccessMenuUser(Current.UserId,Current.MenuId,Current.AccessTypeId,Current.Status);
            return _AccessMenuUserDAC.Add(_AccessMenuUser);
        }

        public bool Delete(int ID)
        {
            return _AccessMenuUserDAC.Delete(ID);
        }

        public bool Edit(AccessMenuUserEntity Current)
        {
            AccessMenuUser _AccessMenuUser = new AccessMenuUser();
            _AccessMenuUser.AccessMenuUserId=Current.AccessMenuUserId;
            _AccessMenuUser.TimeLastModified=DateTime.Now;
            _AccessMenuUser.UserId = Current.UserId;
            _AccessMenuUser.MenuId=Current.MenuId;
            _AccessMenuUser.AccessTypeId=Current.AccessTypeId;
            _AccessMenuUser.Status= Current.Status;
            _AccessMenuUser.Hidden = true;
            return _AccessMenuUserDAC.Edit(_AccessMenuUser);
        }

        public AccessMenuUserEntity Get(int ID)
        {
            AccessMenuUserEntity _AccessMenuUserEntity = new AccessMenuUserEntity();
            var q = _AccessMenuUserDAC.Get(ID);
            _AccessMenuUserEntity.AccessMenuUserId = q.AccessMenuUserId;
            _AccessMenuUserEntity.AccessTypeId = q.AccessTypeId;
            _AccessMenuUserEntity.MenuId = q.MenuId;
            _AccessMenuUserEntity.Status = q.Status;
            _AccessMenuUserEntity.UserId = q.UserId;
            return _AccessMenuUserEntity;
        }

        public AccessMenuUserEntity Get(int userid,int menuid)
        {
            AccessMenuUserEntity _AccessMenuUserEntity = new AccessMenuUserEntity();
            var q = _AccessMenuUserDAC.Get(userid,menuid);
            if (q != null)
            {
                _AccessMenuUserEntity.AccessMenuUserId = q.AccessMenuUserId;
                _AccessMenuUserEntity.AccessTypeId = q.AccessTypeId;
                _AccessMenuUserEntity.MenuId = q.MenuId;
                _AccessMenuUserEntity.Status = q.Status;
                _AccessMenuUserEntity.UserId = q.UserId;
            }
            else
                return null;
            return _AccessMenuUserEntity;
        }

        public IQueryable<AccessMenuUserEntity> GetAll()
        {
            return (IQueryable < AccessMenuUserEntity > )_AccessMenuUserDAC.GetAll();
        }

        public  IQueryable<AccessMenuUserEntity> GetAll(int ID)
        {
            return _AccessMenuUserDAC.GetAllAccessMenuUser(ID);
        }

        public IQueryable<AccessMenuUserEntity> GetAllAccessMenuUserTree(int ID)
        {
            return _AccessMenuUserDAC.GetAllAccessMenuUserTree(ID);
        }

        public IQueryable<AccessMenuUserEntity> GetAllAccessMenuUserTreeOnly(int ID)
        {
            return _AccessMenuUserDAC.GetAllAccessMenuUserTreeOnly(ID);
        }


        public bool AddList(List<AccessMenuUserEntity> Current)
        {
            int resultadd;
            bool resultedit;
            foreach (AccessMenuUserEntity item in Current)
            {
                var GetAccessMenuUserEntity = Get(item.UserId, item.MenuId);
                if (GetAccessMenuUserEntity == null && item.Status)
                {
                    resultadd = Add(item);
                    if (resultadd == 0)
                        return false;
                }
                else if (GetAccessMenuUserEntity != null && item.Status == false)
                {
                    resultedit = Edit(GetAccessMenuUserEntity);
                    if (resultedit == false)
                        return false;
                }
            }
            return true;
        }

    }
}
