using Bussiness.InfraStructre.AccessAndLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.AccessAndLog;
using DomainModel.Models.AccessAndLog;
using InterfaceEntity;

namespace Bussiness.Provider.AccessAndLog
{
    public class SupervisorProvider : ISupervisorProvider
    {
        private SupervisorDAC SupervisorDAC;

        public SupervisorProvider()
        {
            SupervisorDAC = new SupervisorDAC();
        }

        public int Add(SupervisorEntity Current)
        {
            Supervisor supervisor = new Supervisor(Current.DepartmentId,Current.EmployemeId,Current.PostTypeId,Current.State);
            return SupervisorDAC.Add(supervisor);
        }

        public bool Delete(int ID)
        {
            return SupervisorDAC.Delete(ID);
        }

        public bool Edit(SupervisorEntity Current)
        {
            Supervisor supervisor = new Supervisor();
            supervisor.SupervisorId = Current.SupervisorId;
            supervisor.TimeLastModified = DateTime.Now;
            supervisor.DepartmentId = Current.DepartmentId;
            supervisor.EmployemeId = Current.EmployemeId;
            supervisor.PostTypeId = Current.PostTypeId;
            supervisor.State = Current.State;        
            return SupervisorDAC.Edit(supervisor);
        }

        public SupervisorEntity Get(int ID)
        {
            SupervisorEntity supervisorentity = new SupervisorEntity();
            var q = SupervisorDAC.Get(ID);
            if (q != null)
            {
                supervisorentity.SupervisorId = q.SupervisorId;
                supervisorentity.DepartmentId = q.DepartmentId;
                supervisorentity.EmployemeId = q.EmployemeId;
                supervisorentity.PostTypeId = q.PostTypeId;
                supervisorentity.State = q.State;
            }
            else
                supervisorentity = null;
            return supervisorentity;
        }

        public IQueryable<SupervisorEntity> GetAll()
        {
            return SupervisorDAC.GetAllSupervisor();
        }
    }
}
