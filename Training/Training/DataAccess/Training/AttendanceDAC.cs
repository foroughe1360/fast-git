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
    public class AttendanceDAC : IAttendanceRepository
    {
        public int Add(Attendance Current)
        {
            TrainingContext db = new TrainingContext();
            db.Attendances.Add(Current);
            db.SaveChanges();
            return Current.AttendanceId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            try
            {
                TrainingContext db = new TrainingContext();
                var attendance = new Attendance() { AttendanceId = ID, Hidden = true };
                db.Attendances.Attach(attendance);
                db.Entry(attendance).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Attendance Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Attendances.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TypeAttendanceId).IsModified = true;
                db.Entry(Current).Property(x => x.HourDelayFrom).IsModified = true;
                db.Entry(Current).Property(x => x.HourDelayTo).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Attendance Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Attendances.SingleOrDefault(x => x.AttendanceId == ID);
        }

        public IQueryable<Attendance> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Attendances select item;
        }

        public IQueryable<AttendanceEntity> GetAll(int attendancedateid,int designtrainingcourseid)
        {
            TrainingContext db = new TrainingContext();

            var queryDesigntrainingCoursesCourseRegistration =
                (from employemes in db.Employemes
                 join CourseRegistrations in db.CourseRegistrations.Where(a => a.DesignTrainingCourseId==designtrainingcourseid &&  a.Hidden == false) on employemes.EmployemeId equals CourseRegistrations.EmployemeId
                 select new
                 {
                     EmployemeId = employemes.EmployemeId,
                     EmployemeName = employemes.FirstName + " " + employemes.LastName,
                     CourseRegistrationId = CourseRegistrations.CourseRegistrationId,
                     EmployemeStateID = CourseRegistrations.EmployemeStateID
                 });

            var queryDesigntrainingCoursesAttendances =
                (from CourseRegistrations in db.CourseRegistrations.Where(a => a.Hidden == false)
                 join attendances in db.Attendances.Where(a => a.AttendanceDateId==attendancedateid) on CourseRegistrations.CourseRegistrationId equals attendances.CourseRegistrationId
                 join tableinterfacevalues in db.TableInterfaceValues on attendances.TypeAttendanceId equals tableinterfacevalues.TableInterfaceValueId
                 select new
                 {
                     AttendanceId = attendances.AttendanceId,
                     HourDelayFrom = attendances.HourDelayFrom,
                     HourDelayTo = attendances.HourDelayTo,
                     CourseRegistrationId = attendances.CourseRegistrationId,
                     AttendanceDateId = attendances.AttendanceDateId,
                     EmployemeId= CourseRegistrations.EmployemeId,
                     TypeAttendanceId=attendances.TypeAttendanceId,
                     TypeAttendanceName = tableinterfacevalues.TableValue,
                     Hidden = attendances.Hidden
                 });


            var query =
                (from q1 in queryDesigntrainingCoursesCourseRegistration
                 join q2 in queryDesigntrainingCoursesAttendances.Where(a => a.Hidden==false) on q1.EmployemeId equals q2.EmployemeId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new AttendanceEntity
                 {
                     AttendanceId = (temp.AttendanceId == null ? 0 : temp.AttendanceId),
                     AttendanceDateId = (temp.AttendanceDateId == null ? 0 : temp.AttendanceDateId),
                     CourseRegistrationId = q1.CourseRegistrationId,
                     //CourseRegistrationId = (temp.CourseRegistrationId == null ? 0 : temp.CourseRegistrationId),
                     EmployemesnName = q1.EmployemeName,
                     TypeAttendanceId = (temp.TypeAttendanceId == null ? 0 : temp.TypeAttendanceId),
                     HourDelayFrom = (temp.HourDelayFrom == null ? "" : temp.HourDelayFrom),
                     HourDelayTo = (temp.HourDelayTo == null ? "" : temp.HourDelayTo),
                     TypeAttendanceName = temp.TypeAttendanceName,
                     AttendanceAbsenceexist = ((q1.EmployemeStateID == 183 && temp.AttendanceId== null) ? true : false),
                     StateSave = (temp.AttendanceId == null ? false : true)
                 });

            return query;
        }

        public Attendance GetAttendance(int courseregistrationid, int attendanceid)
        {
            TrainingContext db = new TrainingContext();
            return db.Attendances.SingleOrDefault(x => x.CourseRegistrationId == courseregistrationid && x.AttendanceId == attendanceid && x.Hidden == false);
        }

        public IQueryable<AttendanceEntity> GetAllAttendance(int ID)
        {
            TrainingContext db = new TrainingContext();

            var listtemp =
                (
                    // غیبت غیر موجه  = 186
                    // 186 = UnjustifiedAbsences
                    from attendances in db.Attendances.Where(a => a.TypeAttendanceId == (int)AttendanceEntity.Attendance.UnjustifiedAbsences)
                    join attendancedates in db.AttendanceDates.Where(a => a.DesignTrainingCourseId == ID) on attendances.AttendanceDateId equals attendancedates.AttendanceDateId
                    join TableInterfaceValuesTypeAttendance in db.TableInterfaceValues on attendances.TypeAttendanceId equals TableInterfaceValuesTypeAttendance.TableInterfaceValueId
                    join courseregistrations in db.CourseRegistrations on attendances.CourseRegistrationId equals courseregistrations.CourseRegistrationId
                    join employemes in db.Employemes on courseregistrations.EmployemeId equals employemes.EmployemeId
                    join noteabsences in db.NoteAbsences.Where(a => a.Hidden==false) on attendances.AttendanceId equals noteabsences.AttendanceId
                    into Temp
                    from temp in Temp.DefaultIfEmpty()
                    select new AttendanceEntity
                    {
                        AttendanceId = (temp.AttendanceId == null ? attendances.AttendanceId : 0),
                        EmployemesnName = employemes.FirstName+" "+employemes.LastName,
                        TypeAttendanceId = attendances.TypeAttendanceId,
                        HourDelayFrom = attendances.HourDelayFrom,
                        HourDelayTo = attendances.HourDelayTo,
                        TypeAttendanceName = TableInterfaceValuesTypeAttendance.TableValue,
                        AttendanceAbsenceDate = attendancedates.AttendanceAbsenceDate
                    });
            var list =
                (
                    from listt in listtemp.Where(a => a.AttendanceId != 0)
                    select new AttendanceEntity
                    {
                        AttendanceId = listt.AttendanceId,
                        EmployemesnName = listt.EmployemesnName,
                        TypeAttendanceId = listt.TypeAttendanceId,
                        HourDelayFrom = listt.HourDelayFrom,
                        HourDelayTo = listt.HourDelayTo,
                        TypeAttendanceName = listt.TypeAttendanceName,
                        AttendanceAbsenceDate=listt.AttendanceAbsenceDate
                    });
            return list;
        }

        public bool CheckAttendance(int courseregistrationid)
        {
            TrainingContext db = new TrainingContext();
            int count =  db.Attendances.Count(a => a.CourseRegistrationId == courseregistrationid && a.Hidden == false);
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
