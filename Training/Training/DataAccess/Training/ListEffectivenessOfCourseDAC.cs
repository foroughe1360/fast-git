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
    public class ListEffectivenessOfCourseDAC : IListEffectivenessOfCourseRepository
    {
        public int Add(ListEffectivenessOfCourse Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListEffectivenessOfCourses.Add(Current);
            db.SaveChanges();
            return Current.ListEffectivenessOfCourseId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listEffectivenessOfCourse = new ListEffectivenessOfCourse() { ListEffectivenessOfCourseId = ID, Hidden = true };
                db.ListEffectivenessOfCourses.Attach(listEffectivenessOfCourse);
                db.Entry(listEffectivenessOfCourse).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();

            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListEffectivenessOfCourse Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListEffectivenessOfCourses.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListEffectivenessOfCourse Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListEffectivenessOfCourses.SingleOrDefault(x => x.ListEffectivenessOfCourseId == ID);
        }

        public IQueryable<ListEffectivenessOfCourse> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListEffectivenessOfCourses select item;
        }

        public IQueryable<ListEffectivenessOfCourseEntity> GetAllListEffectivenessOfCourse(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.Hidden == false && a.TableInterfaceId == 12)
                 join listeffectivenessofcourses in db.ListEffectivenessOfCourses.Where(a => a.Hidden==false && a.DesignTrainingCourseId==ID) on tableinterfacevalues.TableInterfaceValueId equals listeffectivenessofcourses.EffectivenessOfCoursesId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListEffectivenessOfCourseEntity
                 {
                     ListEffectivenessOfCourseId=(temp.ListEffectivenessOfCourseId == null?0:temp.ListEffectivenessOfCourseId),
                     EffectivenessOfCoursesId=tableinterfacevalues.TableInterfaceValueId,
                     EffectivenessOfCoursesName =tableinterfacevalues.TableValue, 
                     EffectivenessOfCoursesState = (temp == null ? false : true)
                 });
            return _query;
        }

        public ListEffectivenessOfCourse GetEffectivenessOfCourse(int designtrainingcourseid, int effectivenessofcourseid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListEffectivenessOfCourses.SingleOrDefault(x => x.DesignTrainingCourseId == designtrainingcourseid && x.EffectivenessOfCoursesId == effectivenessofcourseid && x.Hidden == false);
        }

        public ListEffectivenessOfCourse GetDeleteEffectivenessOfCourse(int designtrainingcourseid, int effectivenessofcourseid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListEffectivenessOfCourses.SingleOrDefault(x => x.DesignTrainingCourseId == designtrainingcourseid && x.EffectivenessOfCoursesId == effectivenessofcourseid && x.Hidden == true);
        }

        #region ListEffectivenessOfCourseReport
        public IQueryable<ListEffectivenessOfCourseEntity> getListEffectivenessOfCourse(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                    from listeffectivenessofcourses in db.ListEffectivenessOfCourses.Where(a => a.Hidden == false && a.DesignTrainingCourseId == ID)
                    select new ListEffectivenessOfCourseEntity
                    {
                        EffectivenessOfCoursesId = listeffectivenessofcourses.EffectivenessOfCoursesId
                    }
                );
        }

        #endregion
    }
}
