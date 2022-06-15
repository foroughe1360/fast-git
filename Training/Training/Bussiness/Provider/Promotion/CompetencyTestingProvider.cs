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
    public class CompetencyTestingProvider : ICompetencyTestingProvider
    {
        private CompetencyTestingDAC _CompetencyTestingDAC;
        public CompetencyTestingProvider()
        {
            _CompetencyTestingDAC = new CompetencyTestingDAC();
        }
        public int Add(CompetencyTestingEntity Current)
        {
            return _CompetencyTestingDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _CompetencyTestingDAC.Delete(ID);
        }

        public bool Edit(CompetencyTestingEntity Current)
        {
            return _CompetencyTestingDAC.Edit(Current);
        }

        public CompetencyTestingEntity Get(int ID)
        {
            CompetencyTestingEntity _CompetencyTestingEntity = new CompetencyTestingEntity();
            var q = _CompetencyTestingDAC.Get(ID);
            _CompetencyTestingEntity.CompetencyTestingId = q.CompetencyTestingId;
            _CompetencyTestingEntity.LaboratoryTestsId = q.LaboratoryTestsId;
            _CompetencyTestingEntity.ListQualificationOfStaffId = q.ListQualificationOfStaffId;
           return _CompetencyTestingEntity; 
        }

        public IQueryable<CompetencyTestingEntity> GetAll()
        {
            var query = _CompetencyTestingDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new CompetencyTestingEntity()
                 {
                    CompetencyTestingId = q.CompetencyTestingId,
                    LaboratoryTestsId = q.LaboratoryTestsId,
                    ListQualificationOfStaffId = q.ListQualificationOfStaffId

                 });
            return _query;
        }
    }
}
