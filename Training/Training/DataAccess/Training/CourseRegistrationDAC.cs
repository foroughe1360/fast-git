using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class CourseRegistrationDAC : ICourseRegistrationRepository
    {
        public int Add(CourseRegistration Current)
        {
            TrainingContext db = new TrainingContext();
            db.CourseRegistrations.Add(Current);
            db.SaveChanges();
            return Current.CourseRegistrationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var courseRegistrations = new CourseRegistration() { CourseRegistrationId = ID, Hidden = true };
                db.CourseRegistrations.Attach(courseRegistrations);
                db.Entry(courseRegistrations).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(CourseRegistration Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.CourseRegistrations.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.DesignTrainingCourseId).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeStateID).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public CourseRegistration Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.CourseRegistrations.SingleOrDefault(x => x.CourseRegistrationId == ID);
        }

        public IQueryable<CourseRegistration> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.CourseRegistrations select item;
        }

        public IQueryable<CourseRegistrationEntity> GetAllCourseRegistration(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _qurey =
                (from courseregistration in db.CourseRegistrations.Where(a => a.Hidden == false && a.DesignTrainingCourseId==ID)
                 join employemes in db.Employemes on courseregistration.EmployemeId equals employemes.EmployemeId
                 join tableinterfacevalues in db.TableInterfaceValues on courseregistration.EmployemeStateID equals tableinterfacevalues.TableInterfaceValueId
                 select new CourseRegistrationEntity
                 {
                     CourseRegistrationId = courseregistration.CourseRegistrationId,
                     DesignTrainingCourseId = courseregistration.DesignTrainingCourseId,
                     EmployemeId = courseregistration.EmployemeId,
                     EmployemesName = employemes.FirstName + " " + employemes.LastName,
                     EmployemeStateName= tableinterfacevalues.TableValue,
                     EmployemeStateID=courseregistration.EmployemeStateID
                 });
            return _qurey;

        }
    }
}
