using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Report.Training.DesignTrainingCourse;

namespace DataAccess
{
    public class DesignTrainingCourseDAC : IDesignTrainingCourseRepository
    {
        public int Add(DesignTrainingCourse Current)
        {
            TrainingContext db = new TrainingContext();
            db.DesignTrainingCourses.Add(Current);
            db.SaveChanges();
            return Current.DesignTrainingCourseId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var designTrainingCourse = new DesignTrainingCourse() { DesignTrainingCourseId = ID, Hidden = true };
                db.DesignTrainingCourses.Attach(designTrainingCourse);
                db.Entry(designTrainingCourse).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(DesignTrainingCourse Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DesignTrainingCourses.Attach(Current);

                db.Entry(Current).Property(x => x.DesignTrainingCourseId).IsModified = true;
                db.Entry(Current).Property(x => x.CostCourses).IsModified = true;
                db.Entry(Current).Property(x => x.CourseContent).IsModified = true;
                db.Entry(Current).Property(x => x.CourseObjectives).IsModified = true;
                db.Entry(Current).Property(x => x.Duration).IsModified = true;
                db.Entry(Current).Property(x => x.NumberOfParticipants).IsModified = true;
                db.Entry(Current).Property(x => x.OtherNotes).IsModified = true;
                db.Entry(Current).Property(x => x.TeacherId).IsModified = true;
                db.Entry(Current).Property(x => x.TookHold).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingVenueId).IsModified = true;
                db.Entry(Current).Property(x => x.ExamDates).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingCourseId).IsModified = true;
                db.Entry(Current).Property(x => x.TypesOfTrainingId).IsModified = true;
                db.Entry(Current).Property(x => x.MaximumScore).IsModified = true;
                db.Entry(Current).Property(x => x.HoursHolding).IsModified = true;
                db.Entry(Current).Property(x => x.MinutesHolding).IsModified = true;
                db.Entry(Current).Property(x => x.ListLearningAssistToolComment).IsModified = true;
                db.Entry(Current).Property(x => x.EffectivenessOfCourse).IsModified = true;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Success = false;
            }
            return Success;
        }

        public DesignTrainingCourse Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DesignTrainingCourses.SingleOrDefault(x => x.DesignTrainingCourseId == ID);
        }

        public IQueryable<DesignTrainingCourse> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DesignTrainingCourses select item;
        }

        public IQueryable<DesignTrainingCourseEntity> GetAllDesignTrainingCourse(int designtrainingcoursedateid)
        {
            TrainingContext db = new TrainingContext();

            var _query =
                (from designtrainingcourse in db.DesignTrainingCourses.Where(a => a.Hidden == false && a.DesignTrainingCourseDateId == designtrainingcoursedateid)
                 join trainingcourses in db.TrainingCourses on designtrainingcourse.TrainingCourseId equals trainingcourses.TrainingCourseId
                 join teachers in db.Teachers on designtrainingcourse.TeacherId equals teachers.TeacherId
                 join tableinterfacevalues in db.TableInterfaceValues on designtrainingcourse.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId
                 join tableinterfacevaluestypesoftraining in db.TableInterfaceValues on designtrainingcourse.TypesOfTrainingId equals tableinterfacevaluestypesoftraining.TableInterfaceValueId
                 select new DesignTrainingCourseEntity()
                 {
                     CostCourses = designtrainingcourse.CostCourses,
                     CourseContent = designtrainingcourse.CourseContent,
                     CourseObjectives = designtrainingcourse.CourseObjectives,
                     DesignTrainingCourseId = designtrainingcourse.DesignTrainingCourseId,
                     Duration = designtrainingcourse.Duration,
                     NumberOfParticipants = designtrainingcourse.NumberOfParticipants,
                     OtherNotes = designtrainingcourse.OtherNotes,
                     TeacherId = designtrainingcourse.TeacherId,
                     TeacherName = teachers.Name + " " + teachers.Family,
                     TookHold = designtrainingcourse.TookHold,
                     TrainingCourseId = designtrainingcourse.TrainingCourseId,
                     CourseName = trainingcourses.CourseName,
                     TrainingVenueId = designtrainingcourse.TrainingVenueId,
                     TrainingVenueName = tableinterfacevalues.TableValue,
                     ExamDates = designtrainingcourse.ExamDates,
                     TypesOfTrainingId = designtrainingcourse.TypesOfTrainingId,
                     MaximumScore= designtrainingcourse.MaximumScore,
                     typesoftrainingName= tableinterfacevaluestypesoftraining.TableValue,
                     HoursHolding = designtrainingcourse.HoursHolding,
                     MinutesHolding = designtrainingcourse.MinutesHolding,
                     ListLearningAssistToolComment = designtrainingcourse.ListLearningAssistToolComment,
                     EffectivenessOfCourse = designtrainingcourse.EffectivenessOfCourse
                 });
            return _query;
        }

        #region DesignTrainingCourseReport

        public IQueryable<DesignTrainingCourseEntity> GetDesignTrainingCourseListDPD( int trainingcourseid)
        {
            TrainingContext db = new TrainingContext();

            var designtrainingcourselist = (from designtrainingcourses in db.DesignTrainingCourses.Where(a => a.Hidden == false && a.TrainingCourseId == trainingcourseid)
                                            join designtrainingcourse in db.DesignTrainingCourses on designtrainingcourses.DesignTrainingCourseDateId equals designtrainingcourse.DesignTrainingCourseDateId
                                            select new DesignTrainingCourseEntity
                                            {
                                                DesignTrainingCourseId = designtrainingcourses.DesignTrainingCourseId,
                                                TrainingCourseId = designtrainingcourses.TrainingCourseId,
                                                TookHold = (designtrainingcourses.TookHold == null ? new DateTime(1753, 1, 1, 12, 0, 0) : designtrainingcourses.TookHold),
                                                TookHoldStr = (designtrainingcourses.TookHold == null ? " " : designtrainingcourses.TookHold.ToString()),

                                            });

            List<DesignTrainingCourseEntity> result = designtrainingcourselist.GroupBy(g => new { g.TrainingCourseId })
                           .Select(g => g.FirstOrDefault())
                           .ToList();
            return result.AsQueryable();
            //return designtrainingcourselist;
        }

        public DesignTrainingCourseReport GetDesignTrainingCourse(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                    from designtrainingcourses in db.DesignTrainingCourses.Where(a => a.DesignTrainingCourseId == ID)
                    join trainingcourses in db.TrainingCourses on designtrainingcourses.TrainingCourseId equals trainingcourses.TrainingCourseId
                    join teachers in db.Teachers on designtrainingcourses.TeacherId equals teachers.TeacherId
                    join tableinterfacevaluesTrainingVenue in db.TableInterfaceValues on designtrainingcourses.TrainingVenueId equals tableinterfacevaluesTrainingVenue.TableInterfaceValueId
                    select new DesignTrainingCourseReport
                    {
                        TrainingCourse = trainingcourses.CourseName,
                        Teacher = teachers.Name + " "+ teachers.Family,
                        TookHold = designtrainingcourses.TookHold,
                        TrainingVenue = tableinterfacevaluesTrainingVenue.TableValue,
                        Duration = designtrainingcourses.Duration,
                        NumberOfParticipants = designtrainingcourses.NumberOfParticipants,
                        CostCourses = designtrainingcourses.CostCourses,
                        CourseObjectives = designtrainingcourses.CourseObjectives,
                        CourseContent = designtrainingcourses.CourseContent,
                        ListLearningAssistToolComment = designtrainingcourses.ListLearningAssistToolComment,
                        HoursHolding = designtrainingcourses.HoursHolding,
                        OtherNotes = designtrainingcourses.OtherNotes
                       

                    }
                ).FirstOrDefault();
        }
        //public IQueryable<DesignTrainingCourseEntity> ListEmployemeTrainingCourse(int designtrainingcoursedateid)
        //{
        //    TrainingContext db = new TrainingContext();

        //    var query = db.Database.SqlQuery<DesignTrainingCourseEntity>(
        //    "EmployemeTrainingCourse @DesignTrainingCourseDateId",
        //    new System.Data.SqlClient.SqlParameter("DesignTrainingCourseDateId", designtrainingcoursedateid)
        //    ).ToList();
        //    return query;

        //}
        #endregion
    }
}
