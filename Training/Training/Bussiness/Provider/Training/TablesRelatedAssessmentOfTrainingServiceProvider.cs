using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using DomainModel.Models;

namespace Bussiness
{
    public class TablesRelatedAssessmentOfTrainingServiceProvider : ITablesRelatedAssessmentOfTrainingServiceProvider
    {
        private TablesRelatedAssessmentOfTrainingServiceDAC _TablesRelatedAssessmentOfTrainingServiceDAC;

        public TablesRelatedAssessmentOfTrainingServiceProvider()
        {
            _TablesRelatedAssessmentOfTrainingServiceDAC = new TablesRelatedAssessmentOfTrainingServiceDAC();
        }

        public int Add(TablesRelatedAssessmentOfTrainingServiceEntity Current)
        {
            TablesRelatedAssessmentOfTrainingService _TablesRelatedAssessmentOfTrainingService = new
                TablesRelatedAssessmentOfTrainingService(Current.AssessmentOfTrainingServiceInformationId,Current.AssessmentOfTrainingServiceId,Current.Value);
            return _TablesRelatedAssessmentOfTrainingServiceDAC.Add (_TablesRelatedAssessmentOfTrainingService);
        }

        public bool Delete(int ID)
        {
            return _TablesRelatedAssessmentOfTrainingServiceDAC.Delete(ID);
        }

        public bool Edit(TablesRelatedAssessmentOfTrainingServiceEntity Current)
        {
            TablesRelatedAssessmentOfTrainingService _TablesRelatedAssessmentOfTrainingService = new TablesRelatedAssessmentOfTrainingService();
            _TablesRelatedAssessmentOfTrainingService.TablesRelatedAssessmentOfTrainingServiceId = Current.TablesRelatedAssessmentOfTrainingServiceId;
            _TablesRelatedAssessmentOfTrainingService.TimeLastModified = DateTime.Now;
            _TablesRelatedAssessmentOfTrainingService.AssessmentOfTrainingServiceId = Current.AssessmentOfTrainingServiceId;
            _TablesRelatedAssessmentOfTrainingService.AssessmentOfTrainingServiceInformationId = Current.AssessmentOfTrainingServiceInformationId;
            _TablesRelatedAssessmentOfTrainingService.Value = Current.Value;

            return _TablesRelatedAssessmentOfTrainingServiceDAC.Edit(_TablesRelatedAssessmentOfTrainingService);
        }

        public TablesRelatedAssessmentOfTrainingServiceEntity Get(int ID)
        {
            TablesRelatedAssessmentOfTrainingServiceEntity _TablesRelatedAssessmentOfTrainingServiceEntity = new TablesRelatedAssessmentOfTrainingServiceEntity();
            var q = _TablesRelatedAssessmentOfTrainingServiceDAC.Get(ID);
            _TablesRelatedAssessmentOfTrainingServiceEntity.AssessmentOfTrainingServiceId = q.AssessmentOfTrainingServiceId;
            _TablesRelatedAssessmentOfTrainingServiceEntity.AssessmentOfTrainingServiceInformationId = q.AssessmentOfTrainingServiceInformationId;
            _TablesRelatedAssessmentOfTrainingServiceEntity.Value = q.Value;
            _TablesRelatedAssessmentOfTrainingServiceEntity.TablesRelatedAssessmentOfTrainingServiceId = q.TablesRelatedAssessmentOfTrainingServiceId;
            return _TablesRelatedAssessmentOfTrainingServiceEntity;
        }

        public IQueryable<TablesRelatedAssessmentOfTrainingServiceEntity> GetAll()
        {
            var query = _TablesRelatedAssessmentOfTrainingServiceDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new TablesRelatedAssessmentOfTrainingServiceEntity()
                 {
                     AssessmentOfTrainingServiceId = q.AssessmentOfTrainingServiceId,
                     AssessmentOfTrainingServiceInformationId = q.AssessmentOfTrainingServiceInformationId,
                     Value = q.Value,
                     TablesRelatedAssessmentOfTrainingServiceId = q.TablesRelatedAssessmentOfTrainingServiceId

                 });
            return _query;
        }

        public IQueryable<TablesRelatedAssessmentOfTrainingServiceEntity> GetAll(int ID)
        {
            return _TablesRelatedAssessmentOfTrainingServiceDAC.GetAll(ID);
        }
    }
}
