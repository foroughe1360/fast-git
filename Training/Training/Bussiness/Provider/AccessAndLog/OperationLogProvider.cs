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
    public class OperationLogProvider : IOperationLogProvider
    {
        private OperationLogDAC _OperationLogDAC;

        public OperationLogProvider()
        {
            _OperationLogDAC = new OperationLogDAC();
        }

        public int Add(OperationLogEntity Current)
        {
            OperationLog OperationLog = new OperationLog(Current.TableId,Current.Description,Current.OperationTypeId,Current.FormId,Current.UserId,Current.HostName,Current.UserSystem,Current.RecordId);
            return _OperationLogDAC.Add(OperationLog);
        }

        public bool Delete(int ID)
        {
            return _OperationLogDAC.Delete(ID);
        }

        public bool Edit(OperationLogEntity Current)
        {
            return _OperationLogDAC.Edit(Current);
        }

        public OperationLogEntity Get(int ID)
        {
            OperationLogEntity _OperationLogEntity = new OperationLogEntity();
            var q = _OperationLogDAC.Get(ID);
            _OperationLogEntity.OperationLogId = q.OperationLogId;
            _OperationLogEntity.OperationTypeId = q.OperationTypeId;
            _OperationLogEntity.Description = q.Description;
            _OperationLogEntity.FormId = q.FormId;
            _OperationLogEntity.HostName = q.HostName;
            _OperationLogEntity.TableId = q.TableId;
            _OperationLogEntity.UserId = q.UserId;
            _OperationLogEntity.UserSystem = q.UserSystem;
            _OperationLogEntity.RecordId = q.RecordId;
            return _OperationLogEntity;
        }

        public IQueryable<OperationLogEntity> GetAll()
        {
            var query = _OperationLogDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new OperationLogEntity()
                 {
                     OperationLogId = q.OperationLogId,
                     OperationTypeId = q.OperationTypeId,
                     Description = q.Description,
                     FormId = q.FormId,
                     HostName = q.HostName,
                     TableId = q.TableId,
                     UserId = q.UserId,
                     UserSystem = q.UserSystem,
                     RecordId = q.RecordId
                 });
            return _query;
        }
    }
}
