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
    public class ListStyleCourseDAC : IListStyleCourseRepositorycs
    {
        public object EntityState { get; private set; }

        public int Add(ListStyleCourse Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListStyleCourses.Add(Current);
            db.SaveChanges();
            return Current.ListStyleCourseId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listStyleCourse = new ListStyleCourse() { ListStyleCourseId = ID, Hidden = true };
                db.ListStyleCourses.Attach(listStyleCourse);
                db.Entry(listStyleCourse).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListStyleCourse Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListStyleCourses.Attach(Current);
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

        public ListStyleCourse Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListStyleCourses.SingleOrDefault(x => x.ListStyleCourseId == ID);
        }

        public IQueryable<ListStyleCourse> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListStyleCourses select item;
        }

        public IQueryable<ListStyleCourseEntity> GetAllListStyleCourse(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.TableInterfaceId == 7)
                 join liststylecourse in db.ListStyleCourses.Where(a => a.Hidden == false && a.DesignTrainingCourseId == ID) on tableinterfacevalues.TableInterfaceValueId equals liststylecourse.StyleCoursesId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListStyleCourseEntity
                 {
                     ListStyleCourseId = (temp.ListStyleCourseId == null ? 0 : temp.ListStyleCourseId),
                     StyleCoursesId = tableinterfacevalues.TableInterfaceValueId,
                     ListStyleCourseName = tableinterfacevalues.TableValue,
                     StyleCourseState = (temp == null ? false : true)
                 });
            return _query;
        }

        public ListStyleCourse GetLearningAssistTool(int designtrainingcourseid, int stylecoursesid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListStyleCourses.SingleOrDefault(x => x.DesignTrainingCourseId == designtrainingcourseid && x.StyleCoursesId == stylecoursesid && x.Hidden == false);
        }

        public ListStyleCourse GetDeleteLearningAssistTool(int designtrainingcourseid, int stylecoursesid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListStyleCourses.SingleOrDefault(x => x.DesignTrainingCourseId == designtrainingcourseid && x.StyleCoursesId == stylecoursesid && x.Hidden == true);
        }


        #region ListStyleCourseReport
            public IQueryable<ListStyleCourseEntity> getListStyleCoursesReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                    from liststylecourses in db.ListStyleCourses.Where(a => a.Hidden == false && a.DesignTrainingCourseId == ID)
                    select new ListStyleCourseEntity
                    {
                        StyleCoursesId = liststylecourses.StyleCoursesId
                    });
        }
        
        #endregion
    }

}
