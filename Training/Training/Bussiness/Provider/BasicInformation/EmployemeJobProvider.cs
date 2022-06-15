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
    public class EmployemeJobProvider : IEmployemeJobProvider
    {
        private EmployemeJobDAC _EmployemeJobDAC;
        public EmployemeJobProvider()
        {
            _EmployemeJobDAC = new EmployemeJobDAC();
        }

        public int Add(EmployemeJobEntity Current)
        {
            General _General = new General();
            Current.DateStartPostGroupName = _General.ShamsiToMiladi(Current.DateStartPostGroupNameStr);

            EmployemeJob _EmployemeJob = new EmployemeJob(Current.EmployemeId,Current.PostGroupId,Current.SectionId, Current.DateStartPostGroupName, Current.ActivePostGroupName);
            return _EmployemeJobDAC.Add(_EmployemeJob);
        }

        public bool Delete(int ID)
        {
            return _EmployemeJobDAC.Delete(ID);
        }

        public bool Edit(EmployemeJobEntity Current)
        {
            General _General = new General();
            EmployemeJob _EmployemeJob = new EmployemeJob();
            _EmployemeJob.EmployemeJobId = Current.EmployemeJobId;
            _EmployemeJob.TimeLastModified = DateTime.Now;
            _EmployemeJob.EmployemeId = Current.EmployemeId;
            _EmployemeJob.PostGroupId = Current.PostGroupId;
            _EmployemeJob.SectionId = Current.SectionId;
            _EmployemeJob.DateStartPostGroupName = _General.ShamsiToMiladi(Current.DateStartPostGroupNameStr);
            _EmployemeJob.ActivePostGroupName = Current.ActivePostGroupName;

            return _EmployemeJobDAC.Edit(_EmployemeJob);
        }

        public EmployemeJobEntity Get(int ID)
        {
            EmployemeJobEntity _EmployemeJobEntity = new EmployemeJobEntity();
            var q = _EmployemeJobDAC.Get(ID);
            _EmployemeJobEntity.EmployemeId = q.EmployemeId;
            _EmployemeJobEntity.EmployemeJobId = q.EmployemeJobId;
            _EmployemeJobEntity.PostGroupId = q.PostGroupId;
            _EmployemeJobEntity.SectionId = q.SectionId;
            _EmployemeJobEntity.DateStartPostGroupName = q.DateStartPostGroupName;
            _EmployemeJobEntity.ActivePostGroupName = q.ActivePostGroupName;

            return _EmployemeJobEntity;
        }

        public EmployemeJobEntity GetCurrentPostGroupInfo(int employemejobid)
        {
            return _EmployemeJobDAC.GetCurrentPostGroupInfo(employemejobid);
        }

        public IQueryable<EmployemeJobEntity> GetAll()
        {
            return (IQueryable<EmployemeJobEntity>)_EmployemeJobDAC.GetAll();
        }

        public IQueryable<EmployemeJobEntity> GetAll(int ID)
        {
            return _EmployemeJobDAC.GetAllEmployemeJob(ID);
        }

        public IQueryable<EmployemeJobEntity> GetAllEmployemeJobDPD(int ID)
        {
            return _EmployemeJobDAC.GetAllActivePostGroupNameDPD(ID);
        }

        public IQueryable<EmployemeJobEntity> GetAllPreviousJobs(int employemeid)
        {
            return _EmployemeJobDAC.GetAllPreviousJobs(employemeid);
        }

        public IQueryable<EmployemeJobEntity> GetAllActivePostGroupName(int employemeid)
        {
            return _EmployemeJobDAC.GetAllActivePostGroupName(employemeid);
        }

        

    }
}
