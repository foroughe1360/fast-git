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
    public class ListEmployeeEvaluationProvider : IListEmployeeEvaluationProvider
    {
        private ListEmployeeEvaluationDAC _ListEmployeeEvaluationDAC;
        public ListEmployeeEvaluationProvider()
        {
            _ListEmployeeEvaluationDAC = new ListEmployeeEvaluationDAC();
        }
        public int Add(ListEmployeeEvaluationEntity Current)
        {
            return _ListEmployeeEvaluationDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListEmployeeEvaluationDAC.Delete(ID);
        }

        public bool Edit(ListEmployeeEvaluationEntity Current)
        {
            return _ListEmployeeEvaluationDAC.Edit(Current);
        }

        public ListEmployeeEvaluationEntity Get(int ID)
        {
            ListEmployeeEvaluationEntity _ListEmployeeEvaluationEntity = new ListEmployeeEvaluationEntity();
            var q = _ListEmployeeEvaluationDAC.Get(ID);
            _ListEmployeeEvaluationEntity.AssessorsId = q.AssessorsId;
            _ListEmployeeEvaluationEntity.AssessorTypeId = q.AssessorTypeId;
            _ListEmployeeEvaluationEntity.EmployeeEvaluationState = q.EmployeeEvaluationState;
            _ListEmployeeEvaluationEntity.EmployemesId = q.EmployemesId;
            _ListEmployeeEvaluationEntity.ListEmployeeEvaluationId = q.ListEmployeeEvaluationId;
            _ListEmployeeEvaluationEntity.Ver = q.Ver;
            return _ListEmployeeEvaluationEntity;

            //return (ListEmployeeEvaluationEntity)_ListEmployeeEvaluationDAC.Get(ID);
        }

        public IQueryable<ListEmployeeEvaluationEntity> GetAll()
        {

            var query = _ListEmployeeEvaluationDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new ListEmployeeEvaluationEntity()
                 {
                     AssessorsId = q.AssessorsId,
                     AssessorTypeId = q.AssessorTypeId,
                     EmployeeEvaluationState = q.EmployeeEvaluationState,
                     EmployemesId = q.EmployemesId,
                     ListEmployeeEvaluationId = q.ListEmployeeEvaluationId,
                     Ver = q.Ver

                 });
            return _query;

            // return (IQueryable<ListEmployeeEvaluationEntity>)_ListEmployeeEvaluationDAC.GetAll();
        }
    }
}
