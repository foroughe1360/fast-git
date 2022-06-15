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
    public class HistoryQualificationOfStaffProvider : IHistoryQualificationOfStaffProvider
    {
        private HistoryQualificationOfStaffDAC _HistoryQualificationOfStaffDAC;
        public HistoryQualificationOfStaffProvider()
        {
            _HistoryQualificationOfStaffDAC = new HistoryQualificationOfStaffDAC();
        }
        public int Add(HistoryQualificationOfStaffEntity Current)
        {
            return _HistoryQualificationOfStaffDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _HistoryQualificationOfStaffDAC.Delete(ID);
        }

        public bool Edit(HistoryQualificationOfStaffEntity Current)
        {
            return _HistoryQualificationOfStaffDAC.Edit(Current);
        }

        public HistoryQualificationOfStaffEntity Get(int ID)
        {
            HistoryQualificationOfStaffEntity _HistoryQualificationOfStaffEntity = new HistoryQualificationOfStaffEntity();
            var q = _HistoryQualificationOfStaffDAC.Get(ID);
            _HistoryQualificationOfStaffEntity.Description = q.Description;
            _HistoryQualificationOfStaffEntity.HistoryQualificationOfStaffId = q.HistoryQualificationOfStaffId;
            _HistoryQualificationOfStaffEntity.ListQualificationOfStaffId = q.ListQualificationOfStaffId;
            _HistoryQualificationOfStaffEntity.SignatureResponsibilityId = q.SignatureResponsibilityId;
            _HistoryQualificationOfStaffEntity.StageNameId = q.StageNameId;
            _HistoryQualificationOfStaffEntity.WorkFlowState = q.WorkFlowState;
            return _HistoryQualificationOfStaffEntity;

            //return (HistoryQualificationOfStaffEntity)_HistoryQualificationOfStaffDAC.Get(ID);
        }

        public IQueryable<HistoryQualificationOfStaffEntity> GetAll()
        {
            var query = _HistoryQualificationOfStaffDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new HistoryQualificationOfStaffEntity()
                 {
                     Description = q.Description,
            HistoryQualificationOfStaffId = q.HistoryQualificationOfStaffId,
            ListQualificationOfStaffId = q.ListQualificationOfStaffId,
            SignatureResponsibilityId = q.SignatureResponsibilityId,
            StageNameId = q.StageNameId,
            WorkFlowState = q.WorkFlowState

        });
            return _query;

            // return (IQueryable<HistoryQualificationOfStaffEntity>)_HistoryQualificationOfStaffDAC.GetAll();
        }
    }
}
