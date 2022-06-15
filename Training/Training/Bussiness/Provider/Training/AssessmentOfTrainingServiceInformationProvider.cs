using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using DataAccess;
using InterfaceEntity;

namespace Bussiness
{
    public class AssessmentOfTrainingServiceInformationProvider : IAssessmentOfTrainingServiceInformationProvider
    {
        private AssessmentOfTrainingServiceInformationDAC _AssessmentOfTrainingServiceInformationDAC;

        public AssessmentOfTrainingServiceInformationProvider()
        {
            _AssessmentOfTrainingServiceInformationDAC = new AssessmentOfTrainingServiceInformationDAC();
        }

        public int Add(AssessmentOfTrainingServiceInformationEntity Current)
        {
            AssessmentOfTrainingServiceInformation _AssessmentOfTrainingServiceInformation = new
                AssessmentOfTrainingServiceInformation(Current.Name);

            return _AssessmentOfTrainingServiceInformationDAC.Add(_AssessmentOfTrainingServiceInformation);
        }

        public bool Delete(int ID)
        {
            return _AssessmentOfTrainingServiceInformationDAC.Delete(ID);
        }

        public bool Edit(AssessmentOfTrainingServiceInformationEntity Current)
        {
            AssessmentOfTrainingServiceInformation _AssessmentOfTrainingServiceInformation = new AssessmentOfTrainingServiceInformation();
            _AssessmentOfTrainingServiceInformation.AssessmentOfTrainingServiceInformationId = Current.AssessmentOfTrainingServiceInformationId;
            _AssessmentOfTrainingServiceInformation.TimeLastModified = DateTime.Now;
            _AssessmentOfTrainingServiceInformation.Name = Current.Name;
            return _AssessmentOfTrainingServiceInformationDAC.Edit(_AssessmentOfTrainingServiceInformation);
        }

        public AssessmentOfTrainingServiceInformationEntity Get(int ID)
        {
            AssessmentOfTrainingServiceInformationEntity _AssessmentOfTrainingServiceInformationEntity = new AssessmentOfTrainingServiceInformationEntity();
            var q = _AssessmentOfTrainingServiceInformationDAC.Get(ID);
            _AssessmentOfTrainingServiceInformationEntity.AssessmentOfTrainingServiceInformationId = q.AssessmentOfTrainingServiceInformationId;
            _AssessmentOfTrainingServiceInformationEntity.Name = q.Name;
            return _AssessmentOfTrainingServiceInformationEntity;

            //return (AssessmentOfTrainingServiceInformationEntity)_AssessmentOfTrainingServiceInformationDAC.Get(ID);
        }

        public IQueryable<AssessmentOfTrainingServiceInformationEntity> GetAll()
        {
            var query = _AssessmentOfTrainingServiceInformationDAC.GetAll();
            var _query = (from q in query.Where(a => a.Hidden == false)
                          select new AssessmentOfTrainingServiceInformationEntity()
                          {
                              AssessmentOfTrainingServiceInformationId = q.AssessmentOfTrainingServiceInformationId,
                              Name = q.Name
                          });
            return _query;
            //return (IQueryable<AssessmentOfTrainingServiceInformationEntity>)_AssessmentOfTrainingServiceInformationDAC.GetAll();
        }
    }
}
