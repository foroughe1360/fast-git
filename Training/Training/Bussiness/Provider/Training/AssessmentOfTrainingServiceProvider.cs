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
    public class AssessmentOfTrainingServiceProvider : IAssessmentOfTrainingServiceProvider
    {
        private AssessmentOfTrainingServiceDAC _AssessmentOfTrainingServiceDAC;

        public AssessmentOfTrainingServiceProvider()
        {
            _AssessmentOfTrainingServiceDAC = new AssessmentOfTrainingServiceDAC();
        }

        public int Add(AssessmentOfTrainingServiceEntity Current)
        {
            AssessmentOfTrainingService _AssessmentOfTrainingService = new AssessmentOfTrainingService(
                Current.InstitutionName, Current.ManagingDirector, Current.TypeOfCompanyId, Current.TypeOfInstitutionId ,Current.ScopeOfTheActivities, Current.EconomicCode, Current.TeacherName, Current.EducationId, Current.Address);
            return _AssessmentOfTrainingServiceDAC.Add(_AssessmentOfTrainingService);
        }

        public bool Delete(int ID)
        {
            return _AssessmentOfTrainingServiceDAC.Delete(ID);
        }

        public bool Edit(AssessmentOfTrainingServiceEntity Current)
        {
            AssessmentOfTrainingService _AssessmentOfTrainingService = new AssessmentOfTrainingService();
            _AssessmentOfTrainingService.AssessmentOfTrainingServiceId = Current.AssessmentOfTrainingServiceId;
            _AssessmentOfTrainingService.TimeLastModified = DateTime.Now;
            _AssessmentOfTrainingService.InstitutionName = Current.InstitutionName;
            _AssessmentOfTrainingService.ManagingDirector = Current.ManagingDirector;
            _AssessmentOfTrainingService.TypeOfCompanyId = Current.TypeOfCompanyId;
            _AssessmentOfTrainingService.TypeOfInstitutionId = Current.TypeOfInstitutionId;
            _AssessmentOfTrainingService.ScopeOfTheActivities = Current.ScopeOfTheActivities;
            _AssessmentOfTrainingService.EconomicCode = Current.EconomicCode;
            _AssessmentOfTrainingService.TeacherName = Current.TeacherName;
            _AssessmentOfTrainingService.EducationId = Current.EducationId;
            _AssessmentOfTrainingService.Address = Current.Address;
            
            return _AssessmentOfTrainingServiceDAC.Edit(_AssessmentOfTrainingService);
        }

        public AssessmentOfTrainingServiceEntity Get(int ID)
        {
            AssessmentOfTrainingServiceEntity _AssessmentOfTrainingServiceEntity = new AssessmentOfTrainingServiceEntity();
            //var q = _AssessmentOfTrainingServiceDAC.Get(ID);
            //_AssessmentOfTrainingServiceEntity.AssessmentOfTrainingServiceId = q.AssessmentOfTrainingServiceId;
            //_AssessmentOfTrainingServiceEntity.EconomicCode = q.EconomicCode;
            //_AssessmentOfTrainingServiceEntity.EducationId = q.EducationId;
            //_AssessmentOfTrainingServiceEntity.TeacherName = q.TeacherName;
            //_AssessmentOfTrainingServiceEntity.ManagingDirector = q.ManagingDirector;
            //_AssessmentOfTrainingServiceEntity.InstitutionName = q.InstitutionName;
            //_AssessmentOfTrainingServiceEntity.ScopeOfTheActivities = q.ScopeOfTheActivities;
            //_AssessmentOfTrainingServiceEntity.Address = q.Address;
            //_AssessmentOfTrainingServiceEntity.TypeOfCompanyId = q.TypeOfCompanyId;
            //return _AssessmentOfTrainingServiceEntity;
            return _AssessmentOfTrainingServiceDAC.GetAOTSE(ID);
        }

        public IQueryable<AssessmentOfTrainingServiceEntity> GetAll()
        {
           return _AssessmentOfTrainingServiceDAC.GetAllAssessmentOfTrainingService();
        }
    }
}
