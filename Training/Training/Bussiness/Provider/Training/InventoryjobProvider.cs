using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;

namespace Bussiness
{
    public class InventoryjobProvider : IInventoryjobProvider
    {
        private InventoryjobDAC _InventoryjobDAC;
        public InventoryjobProvider()
        {
            _InventoryjobDAC = new InventoryjobDAC();
        }

        public int Add(InventoryjobEntity Current)
        {
            Inventoryjob _Inventoryjob = new Inventoryjob(Current.SectionId, Current.PostGroupName, Current.NumberEmployees
                , Current.AsJobs2, Current.AsJobs3, Current.Education, Current.Experience, Current.ListResponsibilitiePowerId, Current.PercentPhysicalActivity,
                Current.PercentMentalActivity, Current.TheoreticalKnowledge, Current.Qualified, Current.OtherTraining,
                Current.OtherAbilityRequiredJob,Current.ListCommunityOrganizationComment);
            return _InventoryjobDAC.Add(_Inventoryjob);
        }

        public bool Delete(int ID)
        {
            return _InventoryjobDAC.Delete(ID);
        }

        public bool Edit(InventoryjobEntity Current)
        {
            Inventoryjob _Inventoryjob = new Inventoryjob();
            _Inventoryjob.InventoryjobId = Current.InventoryjobId;
            _Inventoryjob.TimeLastModified = DateTime.Now;
            _Inventoryjob.SectionId = Current.SectionId;
            _Inventoryjob.PostGroupName = Current.PostGroupName;
            _Inventoryjob.NumberEmployees = Current.NumberEmployees;
            _Inventoryjob.AsJobs2 = Current.AsJobs2;
            _Inventoryjob.AsJobs3 = Current.AsJobs3;
            _Inventoryjob.Education = Current.Education;
            _Inventoryjob.Experience = Current.Experience;
            _Inventoryjob.ListResponsibilitiePowerId = Current.ListResponsibilitiePowerId;
            _Inventoryjob.PercentPhysicalActivity = Current.PercentPhysicalActivity;
            _Inventoryjob.PercentMentalActivity = Current.PercentMentalActivity;
            _Inventoryjob.TheoreticalKnowledge = Current.TheoreticalKnowledge;
            _Inventoryjob.Qualified = Current.Qualified;
            _Inventoryjob.OtherTraining = Current.OtherTraining;
            _Inventoryjob.OtherAbilityRequiredJob = Current.OtherAbilityRequiredJob;
            _Inventoryjob.ListCommunityOrganizationComment = Current.ListCommunityOrganizationComment;


            return _InventoryjobDAC.Edit(_Inventoryjob);
        }

        public InventoryjobEntity Get(int ID)
        {
            InventoryjobEntity _InventoryjobEntity = new InventoryjobEntity();
            var q = _InventoryjobDAC.Get(ID);
            _InventoryjobEntity.AsJobs2 = q.AsJobs2;
            _InventoryjobEntity.AsJobs3 = q.AsJobs3;
            _InventoryjobEntity.Education = q.Education;
            _InventoryjobEntity.Experience = q.Experience;
            _InventoryjobEntity.InventoryjobId = q.InventoryjobId;
            _InventoryjobEntity.NumberEmployees = q.NumberEmployees;
            _InventoryjobEntity.OtherTraining = q.OtherTraining;
            _InventoryjobEntity.PercentMentalActivity = q.PercentMentalActivity;
            _InventoryjobEntity.PercentPhysicalActivity = q.PercentPhysicalActivity;
            _InventoryjobEntity.PostGroupName = q.PostGroupName;
            _InventoryjobEntity.Qualified = q.Qualified;
            _InventoryjobEntity.ListResponsibilitiePowerId = q.ListResponsibilitiePowerId;
            _InventoryjobEntity.SectionId = q.SectionId;
            _InventoryjobEntity.TheoreticalKnowledge = q.TheoreticalKnowledge;
            _InventoryjobEntity.OtherAbilityRequiredJob = q.OtherAbilityRequiredJob;
            _InventoryjobEntity.ListCommunityOrganizationComment = q.ListCommunityOrganizationComment;

            return _InventoryjobEntity;
        }

        public InventoryjobEntity GetInventoryjob(int ID)
        {
            InventoryjobEntity _InventoryjobEntity = new InventoryjobEntity();
            return  _InventoryjobDAC.GetInventoryjob(ID);
        }

        public InventoryjobsReport GetInventoryjobsReport(int ID)
        {
            return _InventoryjobDAC.GetInventoryjobsReport(ID);
        }

        public IQueryable<InventoryjobEntity> GetAll()
        {
            return _InventoryjobDAC.GetAllInventoryjob();
        }


        public bool CopyDataInventoryjob(int ID)
        {
            return _InventoryjobDAC.CopyDataInventoryjob(ID);
        }

    
    }
}
