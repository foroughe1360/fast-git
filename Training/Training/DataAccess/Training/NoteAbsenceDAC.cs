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
    public class NoteAbsenceDAC : INoteAbsenceRepository
    {
        public int Add(NoteAbsence Current)
        {
            TrainingContext db = new TrainingContext();
            db.NoteAbsences.Add(Current);
            db.SaveChanges();
            return Current.NoteAbsenceId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var noteAbsence = new NoteAbsence() { NoteAbsenceId = ID, Hidden = true };
                db.NoteAbsences.Attach(noteAbsence);
                db.Entry(noteAbsence).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(NoteAbsence Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.NoteAbsences.Attach(Current);
                db.Entry(Current).Property(x => x.NoteAbsenceId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.AttendanceId).IsModified = true;
                db.Entry(Current).Property(x => x.WrittenNoticeId).IsModified = true;
                
                //db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public NoteAbsence Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.NoteAbsences.SingleOrDefault(x => x.NoteAbsenceId == ID);
        }

        public NoteAbsenceReport GetNoteAbsencePrint(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                from noteabsences in db.NoteAbsences.Where(a => a.NoteAbsenceId == ID)
                join attendances in db.Attendances on noteabsences.AttendanceId equals attendances.AttendanceId
                join attendancedates in db.AttendanceDates on attendances.AttendanceDateId equals attendancedates.AttendanceDateId
                join courseregistrations in db.CourseRegistrations on attendances.CourseRegistrationId equals courseregistrations.CourseRegistrationId
                join employemes in db.Employemes on courseregistrations.EmployemeId equals employemes.EmployemeId
                join designtrainingcourses in db.DesignTrainingCourses on courseregistrations.DesignTrainingCourseId equals designtrainingcourses.DesignTrainingCourseId
                join trainingcourses in db.TrainingCourses on designtrainingcourses.TrainingCourseId equals trainingcourses.TrainingCourseId
                select new NoteAbsenceReport
                {
                    EmployemesName=employemes.FirstName+" "+employemes.LastName,
                    CourseName = trainingcourses.CourseName,
                    WrittenNoticeJE = (noteabsences.WrittenNoticeId == (int)NoteAbsenceEntity.NoteAbsence.ForInformation? true :false),
                    WrittenNoticeDP = (noteabsences.WrittenNoticeId == (int)NoteAbsenceEntity.NoteAbsence.Records ? true : false),
                    AttendanceDate = attendancedates.AttendanceAbsenceDate,
                    HourDelayFrom = attendances.HourDelayFrom,
                    HourDelayTo = attendances.HourDelayTo
                }).FirstOrDefault();
        }

        public IQueryable<NoteAbsence> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.NoteAbsences select item;
        }

        public IQueryable<NoteAbsenceEntity> GetAllNoteAbsence(int ID)
        {
            TrainingContext db = new TrainingContext();
            //return from item in db.NoteAbsences select item;
            var _query =
                (from noteabsence in db.NoteAbsences.Where(a => a.Hidden == false)
                 join attendance in db.Attendances on noteabsence.AttendanceId equals attendance.AttendanceId
                 join attendancedates in db.AttendanceDates on attendance.AttendanceDateId equals attendancedates.AttendanceDateId
                 join courseregistration in db.CourseRegistrations.Where(a => a.CourseRegistrationId == ID) on attendance.CourseRegistrationId equals courseregistration.CourseRegistrationId
                 join employemes in db.Employemes on courseregistration.EmployemeId equals employemes.EmployemeId
                 join designtrainingcourse in db.DesignTrainingCourses on courseregistration.DesignTrainingCourseId equals designtrainingcourse.DesignTrainingCourseId
                 join trainingcourse in db.TrainingCourses on designtrainingcourse.TrainingCourseId equals trainingcourse.TrainingCourseId
                 join tableinterfacevaluesWrittenNotice in db.TableInterfaceValues on noteabsence.WrittenNoticeId equals tableinterfacevaluesWrittenNotice.TableInterfaceValueId
                 select new NoteAbsenceEntity
                 {
                     AttendanceId = noteabsence.AttendanceId,
                     AttendanceDate = attendancedates.AttendanceAbsenceDate,
                     HourDelayFrom = attendance.HourDelayFrom,
                     HourDelayTo = attendance.HourDelayTo,

                     EmployemeId = courseregistration.EmployemeId,
                     EmployemesName = employemes.FirstName + " " + employemes.LastName,

                     CourseregistrationId = courseregistration.CourseRegistrationId,
                     designtrainingcourseId = courseregistration.DesignTrainingCourseId,
                     CourseName = trainingcourse.CourseName,
                     NoteAbsenceId = noteabsence.NoteAbsenceId,
                     WrittenNoticeId = noteabsence.WrittenNoticeId,
                     WrittenNoticeName = tableinterfacevaluesWrittenNotice.TableValue,
                     TrainingCourseId = trainingcourse.TrainingCourseId
                 });
            return _query;
        }

        public IQueryable<NoteAbsenceReport> GetAllNoteAbsencePrint(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                from noteabsence in db.NoteAbsences.Where(a => a.Hidden == false)
                join attendance in db.Attendances on noteabsence.AttendanceId equals attendance.AttendanceId
                join attendancedates in db.AttendanceDates on attendance.AttendanceDateId equals attendancedates.AttendanceDateId
                join courseregistration in db.CourseRegistrations.Where(a => a.CourseRegistrationId == ID) on attendance.CourseRegistrationId equals courseregistration.CourseRegistrationId
                select new NoteAbsenceReport
                {
                    AttendanceDate = attendancedates.AttendanceAbsenceDate
                });
        }
    }
}
