using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;

namespace DataAccess
{
    public class TestScoreDAC : ITestScoreRepository
    {
        public int Add(TestScore Current)
        {
            TrainingContext db = new TrainingContext();
            db.TestScores.Add(Current);
            db.SaveChanges();
            return Current.TestScoreId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var testScore = new TestScore() { TestScoreId = ID, Hidden = true };
                db.TestScores.Attach(testScore);
                db.Entry(testScore).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TestScore Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TestScores.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Score).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TestScore Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TestScores.SingleOrDefault(x => x.TestScoreId == ID);
        }

        public TestScore Get(int courseregistrationid, int testscoreid)
        {
            TrainingContext db = new TrainingContext();
            return db.TestScores.SingleOrDefault(x => x.CourseRegistrationId == courseregistrationid && x.TestScoreId==testscoreid);
        }

        public IQueryable<TestScore> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TestScores select item;
        }

        public IQueryable<TestScoreEntity> GetTestScores()
        {
            TrainingContext db = new TrainingContext();
            var _qurey =
                (from testscores in db.TestScores.Where(a => a.Hidden == false)
                 join courseregistration in db.CourseRegistrations.Where(a => a.Hidden == false) on testscores.CourseRegistrationId equals courseregistration.CourseRegistrationId
                 join employeme in db.Employemes on courseregistration.EmployemeId equals employeme.EmployemeId
                 //join tableinterfacevalues in db.TableInterfaceValues on testscores.VarietyOfTestId equals tableinterfacevalues.TableInterfaceValueId
                 select new TestScoreEntity
                 {
                     CourseRegistrationId = testscores.CourseRegistrationId,
                     EmployemeName = employeme.FirstName + "" + employeme.LastName,
                     TestScoreId = testscores.TestScoreId
                     //VarietyOfTestId = testscores.VarietyOfTestId,
                     //VarietyOfTestName = tableinterfacevalues.TableValue
                 }
                 );
            return _qurey;
        }
        
        public IQueryable<TestScoreEntity> GetTestScores(int listtypetestscoreid, int designtrainingcourseid)
        {
            TrainingContext db = new TrainingContext();

            var queryDesigntrainingCoursesCourseRegistration =
                (from employemes in db.Employemes
                 join CourseRegistrations in db.CourseRegistrations.Where(a => a.DesignTrainingCourseId == designtrainingcourseid && a.Hidden == false) on employemes.EmployemeId equals CourseRegistrations.EmployemeId
                 select new
                 {
                     EmployemeId = employemes.EmployemeId,
                     EmployemeName = employemes.FirstName + " " + employemes.LastName,
                     CourseRegistrationId = CourseRegistrations.CourseRegistrationId
                 });

            var queryDesigntrainingCoursesTestScores =
                (from courseregistrations in db.CourseRegistrations.Where(a => a.Hidden == false)
                 join testscores in db.TestScores.Where(a => a.ListTypeTestScoresId == listtypetestscoreid && a.Hidden == false) on courseregistrations.CourseRegistrationId equals testscores.CourseRegistrationId
                 select new
                 {
                     TestScoresId= testscores.TestScoreId,
                     ListTypeTestScoresId = testscores.ListTypeTestScoresId,
                     Score = testscores.Score,
                     CourseRegistrationId = testscores.CourseRegistrationId,
                     EmployemeId= courseregistrations.EmployemeId
                 });


            var query =
                (from q1 in queryDesigntrainingCoursesCourseRegistration
                 join q2 in queryDesigntrainingCoursesTestScores on q1.EmployemeId equals q2.EmployemeId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new TestScoreEntity
                 {
                     TestScoreId = (temp.TestScoresId == null?0: temp.TestScoresId),
                     ListTypeTestScoresId = (temp.ListTypeTestScoresId == null?0: temp.ListTypeTestScoresId),
                     Score = (temp.Score == null?0: temp.Score),
                     CourseRegistrationId = q1.CourseRegistrationId,
                     EmployemeName = q1.EmployemeName
                 });

            return query;
        }
    }
}
