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
    public class LogErrorProvider : ILogErrorProvider
    {
        private LogErrorDAC _LogErrorDAC;
        public LogErrorProvider()
        {
            _LogErrorDAC = new LogErrorDAC();
        }

        public int Add(LogErrorEntity Current)
        {
            LogError LogError = new LogError(Current.FormId,Current.ErrorMessage,Current.OperationTypeId,Current.Description);
            return _LogErrorDAC.Add(LogError);
        }

        public bool Delete(int ID)
        {
            return _LogErrorDAC.Delete(ID);
        }

        public bool Edit(LogErrorEntity Current)
        {
            return _LogErrorDAC.Edit(Current);
        }

        public LogErrorEntity Get(int ID)
        {
            LogErrorEntity _LogErrorEntity = new LogErrorEntity();
            var q = _LogErrorDAC.Get(ID);
            _LogErrorEntity.LogErrorId = q.LogErrorId;
            _LogErrorEntity.OperationTypeId = q.OperationTypeId;
            _LogErrorEntity.Description = q.Description;
            _LogErrorEntity.ErrorMessage = q.ErrorMessage;
            _LogErrorEntity.FormId = q.FormId;
            return _LogErrorEntity;
        }

        public IQueryable<LogErrorEntity> GetAll()
        {
            var query = _LogErrorDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new LogErrorEntity()
                 {
                    LogErrorId = q.LogErrorId,
                    OperationTypeId = q.OperationTypeId,
                    Description = q.Description,
                    ErrorMessage = q.ErrorMessage,
                    FormId = q.FormId

                 });
            return _query;
        }
    }
}
