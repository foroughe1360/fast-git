using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;
using System.Data.SqlClient;

namespace DataAccess
{
    public class AttendanceDateDAC : IAttendanceDateRepository
    {
        public int Add(AttendanceDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.AttendanceDates.Add(Current);
            db.SaveChanges();
            return Current.AttendanceDateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var attendancedate = new AttendanceDate() { AttendanceDateId = ID, Hidden = true };
                db.AttendanceDates.Attach(attendancedate);
                db.Entry(attendancedate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(AttendanceDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.AttendanceDates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.DesignTrainingCourseId).IsModified = true;
                db.Entry(Current).Property(x => x.AttendanceAbsenceDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public AttendanceDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.AttendanceDates.SingleOrDefault(x => x.AttendanceDateId == ID);
        }

        public IQueryable<AttendanceDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.AttendanceDates select item;
        }

        public IQueryable<AttendanceDate> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            return from item in db.AttendanceDates.Where(a => a.Hidden== false && a.DesignTrainingCourseId==ID) select item;
        }

        public IQueryable<AttendanceDateReport> GetAttendanceDate(int designtrainingcourseid)
        {
            TrainingContext db = new TrainingContext();
            //ListTypeTestScoreDAC listtypetestscoredac = new ListTypeTestScoreDAC();
            //var GetAllListTypeTestScore = listtypetestscoredac.GetAllListTypeTestScoreVarietyOfTestName(designtrainingcourseid);

            string sqlQuery;
            //SqlParameter[] sqlParams;
            //sqlParams = new SqlParameter[]
            //{
            //new SqlParameter { ParameterName = "@DesignTrainingCourseId",  Value =designtrainingcourseid , Direction = System.Data.ParameterDirection.Input},
            //};

            sqlQuery = "GetTestScore_Select @DesignTrainingCourseId";
            var designtrainingcourseidParameter = new SqlParameter("@DesignTrainingCourseId", designtrainingcourseid);
            var AttendanceDateReportList = db.Database.SqlQuery<AttendanceDateReport>(sqlQuery, designtrainingcourseidParameter).ToList();//.SingleOrDefault();

            return AttendanceDateReportList.AsQueryable();
        }

        public AttendanceDateEntity getCourseDate(int attendancedateid)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                from attendancedates in db.AttendanceDates.Where(a => a.AttendanceDateId == attendancedateid)
                join designtrainingcourses in db.DesignTrainingCourses on attendancedates.DesignTrainingCourseId equals designtrainingcourses.DesignTrainingCourseId
                join trainingcourses in db.TrainingCourses on designtrainingcourses.TrainingCourseId equals trainingcourses.TrainingCourseId
                select new AttendanceDateEntity
                {
                    CourceName = trainingcourses.CourseName,
                    AttendanceAbsenceDate = attendancedates.AttendanceAbsenceDate
                }).FirstOrDefault();

        }
    }
}
