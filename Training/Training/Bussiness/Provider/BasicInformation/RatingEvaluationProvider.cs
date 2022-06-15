using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;

namespace Bussiness
{
    public class RatingEvaluationProvider : IRatingEvaluationProvider
    {
        private RatingEvaluationDAC _RatingEvaluationDAC;

        public RatingEvaluationProvider()
        {
            _RatingEvaluationDAC = new RatingEvaluationDAC();
        }

        public int Add(RatingEvaluationEntity Current)
        {
            General _General = new General();
            Current.RatingEvaluationDate = _General.ShamsiToMiladi(Current.RatingEvaluationDateStr);
            RatingEvaluation _RatingEvaluation = new 
                RatingEvaluation(Current.RatingEvaluationCoursesID,Current.Number,Current.RatingEvaluationDate);
            return _RatingEvaluationDAC.Add(_RatingEvaluation);
        }

        public bool Delete(int ID)
        {
            return _RatingEvaluationDAC.Delete(ID);
        }

        public bool Edit(RatingEvaluationEntity Current)
        {
            General _General = new General();
            RatingEvaluation _RatingEvaluation = new RatingEvaluation();
            _RatingEvaluation.RatingEvaluationId = Current.RatingEvaluationId;
            _RatingEvaluation.TimeLastModified = DateTime.Now;
            _RatingEvaluation.RatingEvaluationCoursesID = Current.RatingEvaluationCoursesID;
            _RatingEvaluation.Number = Current.Number;
            _RatingEvaluation.RatingEvaluationDate = _General.ShamsiToMiladi(Current.RatingEvaluationDateStr);
            return _RatingEvaluationDAC.Edit(_RatingEvaluation);
        }

        public RatingEvaluationEntity Get(int ID)
        {
            RatingEvaluationEntity _RatingEvaluationEntity = new RatingEvaluationEntity();
            var q = _RatingEvaluationDAC.Get(ID);
            _RatingEvaluationEntity.RatingEvaluationId = q.RatingEvaluationId;
            _RatingEvaluationEntity.RatingEvaluationCoursesID = q.RatingEvaluationCoursesID;
            _RatingEvaluationEntity.Number = q.Number;
            _RatingEvaluationEntity.RatingEvaluationDate = q.RatingEvaluationDate;
            return _RatingEvaluationEntity;
        }

        public IQueryable<RatingEvaluationEntity> GetAll()
        {
            return _RatingEvaluationDAC.GetAllRatingEvaluation();
        }
    }
}
