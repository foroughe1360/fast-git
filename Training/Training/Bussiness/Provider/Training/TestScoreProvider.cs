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
    public class TestScoreProvider : ITestScoreProvider
    {
        private TestScoreDAC _TestScoreDAC;
        public TestScoreProvider()
        {
            _TestScoreDAC = new TestScoreDAC();
        }
        public int Add(TestScoreEntity Current)
        {
            return _TestScoreDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _TestScoreDAC.Delete(ID);
        }

        public bool Edit(TestScoreEntity Current)
        {
            return _TestScoreDAC.Edit(Current);
        }

        public TestScoreEntity Get(int ID)
        {
            TestScoreEntity _TestScoreEntity = new TestScoreEntity();
            var q = _TestScoreDAC.Get(ID);
            _TestScoreEntity.CourseRegistrationId = q.CourseRegistrationId;
            _TestScoreEntity.TestScoreId = q.TestScoreId;
            return _TestScoreEntity;
        }

        public TestScoreEntity Get(int courseregistrationid, int testscoreid)
        {
            TestScoreEntity _TestScoreEntity = new TestScoreEntity();
            var q = _TestScoreDAC.Get(courseregistrationid, testscoreid);
            if (q != null)
            {
                _TestScoreEntity.TestScoreId = q.TestScoreId;
                _TestScoreEntity.ListTypeTestScoresId = q.ListTypeTestScoresId;
                _TestScoreEntity.Score = q.Score;
                _TestScoreEntity.CourseRegistrationId = q.CourseRegistrationId;
            }
            else
            {
                _TestScoreEntity = null;
            }
            return _TestScoreEntity;
        }

        public IQueryable<TestScoreEntity> GetAll()
        {
            return _TestScoreDAC.GetTestScores();
        }

        public IQueryable<TestScoreEntity> GetAll(int listtypetestscoreid, int designtrainingcourseid)
        {
            return _TestScoreDAC.GetTestScores(listtypetestscoreid, designtrainingcourseid);
        }

        public bool Addlist(List<TestScoreEntity> Current)
        {
            foreach (var item in Current)
            {
                if (Get(item.CourseRegistrationId, item.TestScoreId) == null)
                {
                    TestScore _TestScore = new TestScore(item.ListTypeTestScoresId, item.CourseRegistrationId, item.Score);
                    _TestScoreDAC.Add(_TestScore);
                }
                else if (Get(item.TestScoreId) != null)
                {
                    TestScore _TestScore = new TestScore();
                    _TestScore.TestScoreId = item.TestScoreId;
                    _TestScore.TimeLastModified = DateTime.Now;
                    _TestScore.ListTypeTestScoresId = item.ListTypeTestScoresId;
                    _TestScore.CourseRegistrationId = item.CourseRegistrationId;
                    _TestScore.Score = item.Score;
                    _TestScoreDAC.Edit(_TestScore); 
                }
            }
            return true;
        }
    }
}
