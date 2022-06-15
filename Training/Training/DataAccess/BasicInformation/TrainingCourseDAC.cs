using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;

namespace DataAccess
{
    public class TrainingCourseDAC : ITrainingCourseRepository
    {
        public int Add(TrainingCourse Current)
        {
            TrainingContext db = new TrainingContext();
            db.TrainingCourses.Add(Current);
            db.SaveChanges();
            return Current.TrainingCourseId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var trainingcourse = new TrainingCourse() { TrainingCourseId = ID, Hidden = true };
                db.TrainingCourses.Attach(trainingcourse);
                db.Entry(trainingcourse).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TrainingCourse Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TrainingCourses.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.CourseName).IsModified = true;
                db.Entry(Current).Property(x => x.CourseTypeId).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TrainingCourse Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TrainingCourses.SingleOrDefault(x => x.TrainingCourseId == ID);
        }

        public IQueryable<TrainingCourse> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TrainingCourses select item;
        }

        public IQueryable<TrainingCourseEntity> GetAllTrainingCourse()
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from trainingcourses in db.TrainingCourses.Where(a => a.Hidden == false)
                 join tableinterfacevalues in db.TableInterfaceValues on trainingcourses.CourseTypeId equals tableinterfacevalues.TableInterfaceValueId
                 select new TrainingCourseEntity
                 {
                     TrainingCourseId = trainingcourses.TrainingCourseId,
                     CourseName = trainingcourses.CourseName,
                     CourseTypeId=trainingcourses.CourseTypeId,
                     CourseTypeName= tableinterfacevalues.TableValue
                 });
            return _query;
        }
    }
}
