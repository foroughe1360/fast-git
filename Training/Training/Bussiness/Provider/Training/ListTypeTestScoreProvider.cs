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
    public class ListTypeTestScoreProvider : IListTypeTestScoreProvider
    {
        ListTypeTestScoreDAC _ListTypeTestScoreDAC;
        public ListTypeTestScoreProvider()
        {
            _ListTypeTestScoreDAC = new ListTypeTestScoreDAC();
        }
        public int Add(ListTypeTestScoreEntity Current)
        {
            General _General = new General();
            Current.ExamDates = _General.ShamsiToMiladi(Current.ExamDatesStr);
            ListTypeTestScore _ListTypeTestScore = new ListTypeTestScore(Current.DesignTrainingCourseId, Current.VarietyOfTestId, Current.ExamDates, Current.PurposeTest);
            return _ListTypeTestScoreDAC.Add(_ListTypeTestScore);
        }

        public bool Delete(int ID)
        {
            return _ListTypeTestScoreDAC.Delete(ID);
        }

        public bool Edit(ListTypeTestScoreEntity Current)
        {
            General _General = new General();
            ListTypeTestScore _ListTypeTestScore = new ListTypeTestScore();
            _ListTypeTestScore.ListTypeTestScoreId = Current.ListTypeTestScoreId;
            _ListTypeTestScore.TimeLastModified = DateTime.Now;
            _ListTypeTestScore.DesignTrainingCourseId = Current.DesignTrainingCourseId;
            _ListTypeTestScore.VarietyOfTestId = Current.VarietyOfTestId;
            _ListTypeTestScore.ExamDates = _General.ShamsiToMiladi(Current.ExamDatesStr);
            _ListTypeTestScore.PurposeTest = Current.PurposeTest;
            return _ListTypeTestScoreDAC.Edit(_ListTypeTestScore);
        }

        public ListTypeTestScoreEntity Get(int ID)
        {
            ListTypeTestScoreEntity _ListTypeTestScoreEntity = new ListTypeTestScoreEntity();
            var q = _ListTypeTestScoreDAC.Get(ID);
            _ListTypeTestScoreEntity.ListTypeTestScoreId = q.ListTypeTestScoreId;
            _ListTypeTestScoreEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
            _ListTypeTestScoreEntity.VarietyOfTestId = q.VarietyOfTestId;
            _ListTypeTestScoreEntity.ExamDates = q.ExamDates;
            _ListTypeTestScoreEntity.PurposeTest = q.PurposeTest;
            return _ListTypeTestScoreEntity;
        }

        public IQueryable<ListTypeTestScoreEntity> GetAll()
        {
            return (IQueryable<ListTypeTestScoreEntity>)_ListTypeTestScoreDAC.GetAll();
        }

        public IQueryable<ListTypeTestScoreEntity> GetAll(int ID)
        {
            return _ListTypeTestScoreDAC.GetAllListTypeTestScore(ID);
        }
    }
}
