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
    public class TypeOfEvaluationProvider : ITypeOfEvaluationProvider
    {
        private TypeOfEvaluationDAC _TypeOfEvaluationDAC;
        public TypeOfEvaluationProvider()
        {
            _TypeOfEvaluationDAC = new TypeOfEvaluationDAC();
        }
        public int Add(TypeOfEvaluationEntity Current)
        {
            TypeOfEvaluation _TypeOfEvaluation = new TypeOfEvaluation(Current.Title,Current.MaxScore);
            return _TypeOfEvaluationDAC.Add(_TypeOfEvaluation);
        }
        public bool Delete(int ID)
        {
            return _TypeOfEvaluationDAC.Delete(ID);
        }
        public bool Edit(TypeOfEvaluationEntity Current)
        {
            TypeOfEvaluation _TypeOfEvaluation = new TypeOfEvaluation();
            _TypeOfEvaluation.TypeOfEvaluationId = Current.TypeOfEvaluationId;
            _TypeOfEvaluation.TimeLastModified= DateTime.Now;
            _TypeOfEvaluation.Title = Current.Title;
            _TypeOfEvaluation.MaxScore = Current.MaxScore;
            return _TypeOfEvaluationDAC.Edit(_TypeOfEvaluation);
        }
        public TypeOfEvaluationEntity Get(int ID)
        {
            TypeOfEvaluationEntity _TypeOfEvaluationEntity = new TypeOfEvaluationEntity();
            var q = _TypeOfEvaluationDAC.Get(ID);
            _TypeOfEvaluationEntity.MaxScore = q.MaxScore;
            _TypeOfEvaluationEntity.Title = q.Title;
            _TypeOfEvaluationEntity.TypeOfEvaluationId = q.TypeOfEvaluationId;
            return _TypeOfEvaluationEntity;
        }
        public IQueryable<TypeOfEvaluationEntity> GetAll()
        {
            var query = _TypeOfEvaluationDAC.GetAll();
            var _query = (from q in query.Where(a => a.Hidden == false)
                          select new TypeOfEvaluationEntity {
                              MaxScore = q.MaxScore,
                              Title = q.Title,
                              TypeOfEvaluationId = q.TypeOfEvaluationId
                          });
            return _query;
        }
    }
}
