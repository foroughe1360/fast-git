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
    public class JobGroupProvider : IJobGroupProvider
    {
        private JobGroupDAC _JobGroupDAC;
        public JobGroupProvider()
        {
            _JobGroupDAC = new JobGroupDAC();
        }
        public int Add(JobGroupEntity Current)
        {
            JobGroup _JobGroup = new JobGroup(Current.JobGroupName,Current.PonitJobGroup,Current.GroupNumber);
            return _JobGroupDAC.Add(_JobGroup);
        }
        public bool Delete(int ID)
        {
            return _JobGroupDAC.Delete(ID);
        }
        public bool Edit(JobGroupEntity Current)
        {
            JobGroup _JobGroup = new JobGroup();
            _JobGroup.JobGroupId=Current.JobGroupId;
            _JobGroup.TimeLastModified = DateTime.Now;
            _JobGroup.JobGroupName=Current.JobGroupName;
            _JobGroup.PonitJobGroup=Current.PonitJobGroup;
            _JobGroup.GroupNumber=Current.GroupNumber;
            return _JobGroupDAC.Edit(_JobGroup);
        }
        public JobGroupEntity Get(int ID)
        {
            JobGroupEntity _JobGroupEntity = new JobGroupEntity();
            var q = _JobGroupDAC.Get(ID);
            
            _JobGroupEntity.GroupNumber = q.GroupNumber;
            _JobGroupEntity.JobGroupName = q.JobGroupName;
            _JobGroupEntity.JobGroupId = q.JobGroupId;
            _JobGroupEntity.PonitJobGroup = q.PonitJobGroup;
            return _JobGroupEntity;

            //return (JobGroupEntity)_JobGroupDAC.Get(ID);
        }
        public IQueryable<JobGroupEntity> GetAll()
        {
            var query = _JobGroupDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new JobGroupEntity()
                 {
                     GroupNumber = q.GroupNumber,
                     JobGroupName = q.JobGroupName,
                     JobGroupId = q.JobGroupId,
                     PonitJobGroup = q.PonitJobGroup

                 });
            return _query;
        }
    }
}
