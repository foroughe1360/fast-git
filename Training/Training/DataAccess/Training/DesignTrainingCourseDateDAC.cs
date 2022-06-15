using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess.Training
{
    public class DesignTrainingCourseDateDAC : IDesignTrainingCourseDateRepository
    {
        public int Add(DesignTrainingCourseDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.DesignTrainingCourseDates.Add(Current);
            db.SaveChanges();
            return Current.DesignTrainingCourseDateId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var designtrainingcoursedate = new DesignTrainingCourseDate() { DesignTrainingCourseDateId = ID, Hidden = true };
                db.DesignTrainingCourseDates.Attach(designtrainingcoursedate);
                db.Entry(designtrainingcoursedate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(DesignTrainingCourseDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DesignTrainingCourseDates.Attach(Current);

                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.DTCDate).IsModified = true;
                db.Entry(Current).Property(x => x.FinancialYear).IsModified = true;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Success = false;
            }
            return Success;
        }
        public DesignTrainingCourseDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DesignTrainingCourseDates.SingleOrDefault(x => x.DesignTrainingCourseDateId == ID);
        }
        public IQueryable<DesignTrainingCourseDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DesignTrainingCourseDates select item;
        }
        public IQueryable<DesignTrainingCourseDateEntity> GetAllDesignTrainingCourseDate()
        {
            TrainingContext db = new TrainingContext();
            return
                (from designtrainingcoursedates in db.DesignTrainingCourseDates.Where(a => a.Hidden == false)
                 select new DesignTrainingCourseDateEntity
                 {
                     DesignTrainingCourseDateId = designtrainingcoursedates.DesignTrainingCourseDateId,
                     Description = designtrainingcoursedates.Description,
                     DTCDate = designtrainingcoursedates.DTCDate,
                     FinancialYear = designtrainingcoursedates.FinancialYear

                 });
        }

    
    }
}
