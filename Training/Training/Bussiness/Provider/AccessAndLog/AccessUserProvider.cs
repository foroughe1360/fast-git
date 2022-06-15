using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class AccessUserProvider : IAccessUserProvider
    {
        private AccessUserDAC _AccessUserDAC;
        public AccessUserProvider()
        {
            _AccessUserDAC = new AccessUserDAC();
        }

        public int Add(AccessUserEntity Current)
        {
            return _AccessUserDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _AccessUserDAC.Delete(ID);
        }

        public bool Edit(AccessUserEntity Current)
        {
            return _AccessUserDAC.Edit(Current);
        }

        public AccessUserEntity Get(int ID)
        {
            AccessUserEntity _AccessUserEntity = new AccessUserEntity();
            var q = _AccessUserDAC.Get(ID);
            _AccessUserEntity.AccessUserId = q.AccessUserId;
            _AccessUserEntity.AccessId = q.AccessId;
            _AccessUserEntity.State = q.State;
            _AccessUserEntity.UserId = q.UserId;
            return _AccessUserEntity;
        }

        public IQueryable<AccessUserEntity> GetAll()
        {
            var query = _AccessUserDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new AccessUserEntity()
                 {
                     AccessUserId = q.AccessUserId,
                     AccessId = q.AccessId,
                     State = q.State,
                     UserId = q.UserId
                 });
            return _query;
        }
    }
}
