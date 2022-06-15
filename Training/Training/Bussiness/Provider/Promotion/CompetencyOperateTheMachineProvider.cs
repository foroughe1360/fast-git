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
    public class CompetencyOperateTheMachineProvider : ICompetencyOperateTheMachineProvider
    {
        private CompetencyOperateTheMachineDAC _CompetencyOperateTheMachineDAC;
        public CompetencyOperateTheMachineProvider()
        {
            _CompetencyOperateTheMachineDAC = new CompetencyOperateTheMachineDAC();
        }
        public int Add(CompetencyOperateTheMachineEntity Current)
        {
            return _CompetencyOperateTheMachineDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _CompetencyOperateTheMachineDAC.Delete(ID);
        }

        public bool Edit(CompetencyOperateTheMachineEntity Current)
        {
            return _CompetencyOperateTheMachineDAC.Edit(Current);
        }

        public CompetencyOperateTheMachineEntity Get(int ID)
        {
            CompetencyOperateTheMachineEntity _CompetencyOperateTheMachineEntity = new CompetencyOperateTheMachineEntity();
            var q = _CompetencyOperateTheMachineDAC.Get(ID);
            _CompetencyOperateTheMachineEntity.CompetencyOperateTheMachineId = q.CompetencyOperateTheMachineId;
            _CompetencyOperateTheMachineEntity.LaboratoryDevicesId = q.LaboratoryDevicesId;
            _CompetencyOperateTheMachineEntity.ListQualificationOfStaffId = q.ListQualificationOfStaffId;
            return _CompetencyOperateTheMachineEntity;
        }

        public IQueryable<CompetencyOperateTheMachineEntity> GetAll()
        {
            var query = _CompetencyOperateTheMachineDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new CompetencyOperateTheMachineEntity()
                 {
                     CompetencyOperateTheMachineId = q.CompetencyOperateTheMachineId,
                     LaboratoryDevicesId = q.LaboratoryDevicesId,
                     ListQualificationOfStaffId = q.ListQualificationOfStaffId

                 });
            return _query;
        }
    }
}
