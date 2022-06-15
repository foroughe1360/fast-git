using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class ListTypeTestScoreDAC : IListTypeTestScoreRepository
    {
        public int Add(ListTypeTestScore Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListTypeTestScores.Add(Current);
            db.SaveChanges();
            return Current.ListTypeTestScoreId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listtypetestscore = new ListTypeTestScore() { ListTypeTestScoreId = ID, Hidden = true };
                db.ListTypeTestScores.Attach(listtypetestscore);
                db.Entry(listtypetestscore).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListTypeTestScore Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListTypeTestScores.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.VarietyOfTestId).IsModified = true;
                db.Entry(Current).Property(x => x.ExamDates).IsModified = true;
                db.Entry(Current).Property(x => x.PurposeTest).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListTypeTestScore Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListTypeTestScores.SingleOrDefault(x => x.ListTypeTestScoreId == ID);
        }

        public IQueryable<ListTypeTestScore> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListTypeTestScores select item;
        }

        public IQueryable<ListTypeTestScoreEntity> GetAllListTypeTestScore(int ID)
        {
            TrainingContext db = new TrainingContext();
            var GetAllListTypeTestScoreList =

                (from listtypetestscores in db.ListTypeTestScores.Where(a => a.Hidden == false && a.DesignTrainingCourseId == ID)
                 join tableinterfacevalues in db.TableInterfaceValues on listtypetestscores.VarietyOfTestId equals tableinterfacevalues.TableInterfaceValueId
                 join designtrainingcourses in db.DesignTrainingCourses on listtypetestscores.DesignTrainingCourseId equals designtrainingcourses.DesignTrainingCourseId
                 join trainingcourses in db.TrainingCourses on designtrainingcourses.TrainingCourseId equals trainingcourses.TrainingCourseId
                 select new ListTypeTestScoreEntity
                 {
                     ListTypeTestScoreId = listtypetestscores.ListTypeTestScoreId,
                     DesignTrainingCourseId = listtypetestscores.DesignTrainingCourseId,
                     DesignTrainingCourseName = trainingcourses.CourseName,
                     VarietyOfTestId = listtypetestscores.VarietyOfTestId,
                     VarietyOfTestName = tableinterfacevalues.TableValue,
                     ExamDates = listtypetestscores.ExamDates,
                     PurposeTest = listtypetestscores.PurposeTest
                 });
            return GetAllListTypeTestScoreList;
        }

        public IQueryable<ListTypeTestScoreEntity> GetAllListTypeTestScoreVarietyOfTestName(int ID)
        {
            TrainingContext db = new TrainingContext();
            var GetAllListTypeTestScoreVarietyOfTestName =

                (from listtypetestscores in db.ListTypeTestScores.Where(a => a.Hidden == false && a.DesignTrainingCourseId == ID)
                 join tableinterfacevalues in db.TableInterfaceValues on listtypetestscores.VarietyOfTestId equals tableinterfacevalues.TableInterfaceValueId
                 join designtrainingcourses in db.DesignTrainingCourses on listtypetestscores.DesignTrainingCourseId equals designtrainingcourses.DesignTrainingCourseId
                 join trainingcourses in db.TrainingCourses on designtrainingcourses.TrainingCourseId equals trainingcourses.TrainingCourseId
                 join testscores in db.TestScores on listtypetestscores.ListTypeTestScoreId equals testscores.ListTypeTestScoresId
                 join courseregistrations in db.CourseRegistrations.Where(a => a.EmployemeStateID != (int)AttendanceEntity.EmployemeState.Deleted) on testscores.CourseRegistrationId equals courseregistrations.CourseRegistrationId
                 join employemes in db.Employemes on courseregistrations.EmployemeId equals employemes.EmployemeId
                 select new ListTypeTestScoreEntity
                 {
                     ListTypeTestScoreId = listtypetestscores.ListTypeTestScoreId,
                     CourseRegistrationId = testscores.CourseRegistrationId,
                     EmployemeId = employemes.EmployemeId,
                     DesignTrainingCourseId = listtypetestscores.DesignTrainingCourseId,
                     DesignTrainingCourseName = trainingcourses.CourseName,
                     VarietyOfTestId = listtypetestscores.VarietyOfTestId,
                     VarietyOfTestName = tableinterfacevalues.TableValue,
                     ExamDates = listtypetestscores.ExamDates,
                     PurposeTest = listtypetestscores.PurposeTest,
                     TestScoresNumber = testscores.Score,
                 });
            return GetAllListTypeTestScoreVarietyOfTestName;
        }

    }
}
