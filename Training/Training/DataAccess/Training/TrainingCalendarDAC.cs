using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;
using System.Globalization;
using InterfaceEntity.Search.Trianing;

namespace DataAccess.Training
{
    public class TrainingCalendarDAC : ITrainingCalendarRepository
    {
        public int Add(TrainingCalendar Current)
        {
            TrainingContext db = new TrainingContext();
            db.TrainingCalendars.Add(Current);
            db.SaveChanges();
            return Current.TrainingCalendarId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var trainingcalendar = new TrainingCalendar() { TrainingCalendarId = ID, Hidden = true };
                db.TrainingCalendars.Attach(trainingcalendar);
                db.Entry(trainingcalendar).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(TrainingCalendar Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TrainingCalendars.Attach(Current);

                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.CourseName).IsModified = true;
                db.Entry(Current).Property(x => x.TeacherId).IsModified = true;
                db.Entry(Current).Property(x => x.Participantlevel).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingCalendarDate).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingCalendarDay).IsModified = true;
                db.Entry(Current).Property(x => x.TableTypeTrainingCalendarDateId).IsModified = true;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Success = false;
            }
            return Success;
        }
        public TrainingCalendar Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TrainingCalendars.SingleOrDefault(x => x.TrainingCalendarId == ID);
        }
        public IQueryable<TrainingCalendar> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TrainingCalendars select item;
        }
        public IQueryable<TrainingCalendarEntity> GetAll(TrainingCalendarSearch TrainingCalendarSearch)
        {
            TrainingContext db = new TrainingContext();
            PersianCalendar pc = new PersianCalendar();
            var _query =

                (from trainingcalendars in db.TrainingCalendars.Where(a => a.Hidden == false && a.TrainingCalendarDateId == TrainingCalendarSearch.TrainingCalendarDateId)
                 join teachers in db.Teachers on trainingcalendars.TeacherId equals teachers.TeacherId

                 join tableinterfacevalues in db.TableInterfaceValues on trainingcalendars.TableTypeTrainingCalendarDateId equals tableinterfacevalues.TableInterfaceValueId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 orderby trainingcalendars.TrainingCalendarDate
                 select new TrainingCalendarEntity
                 {
                     TrainingCalendarDateId = TrainingCalendarSearch.TrainingCalendarDateId,
                     TrainingCalendarId = trainingcalendars.TrainingCalendarId,
                     CourseName = trainingcalendars.CourseName,
                     TeacherId = trainingcalendars.TeacherId,
                     TeacherName = teachers.Name + " " + teachers.Family,
                     Participantlevel = trainingcalendars.Participantlevel,
                     Description = trainingcalendars.Description + "-" + temp.TableValue,
                     TrainingCalendarDate = trainingcalendars.TrainingCalendarDate,
                     TrainingCalendarDay = trainingcalendars.TrainingCalendarDay,
                     TableTypeTrainingCalendarDateId = (temp.TableInterfaceValueId == 0 ? 0 : trainingcalendars.TableTypeTrainingCalendarDateId),
                     NameOfTrainingCalendarDate = temp.TableValue,
                 });
            //return _query;
            if (TrainingCalendarSearch.CourseName.Trim() != "")
                _query = _query.Where(p => p.CourseName.Contains(TrainingCalendarSearch.CourseName));

            if (TrainingCalendarSearch.TableTypeTrainingCalendarDateId != 0)
                _query = _query.Where(p => p.TableTypeTrainingCalendarDateId == TrainingCalendarSearch.TableTypeTrainingCalendarDateId);

            return _query;
        }

        

        public IQueryable<TrainingCalendarEntity> GetAllTrainingCalendar(int ID)
        {
            TrainingContext db = new TrainingContext();
            PersianCalendar pc = new PersianCalendar();
            var _query =

                (from trainingcalendars in db.TrainingCalendars.Where(a => a.Hidden == false && a.TrainingCalendarDateId == ID)
                 join teachers in db.Teachers on trainingcalendars.TeacherId equals teachers.TeacherId

                 join tableinterfacevalues in db.TableInterfaceValues on trainingcalendars.TableTypeTrainingCalendarDateId equals tableinterfacevalues.TableInterfaceValueId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 orderby trainingcalendars.TrainingCalendarDate
                 select new TrainingCalendarEntity
                 {
                     TrainingCalendarId = trainingcalendars.TrainingCalendarId,
                     CourseName = trainingcalendars.CourseName,
                     TeacherId = trainingcalendars.TeacherId,
                     TeacherName = teachers.Name + " " + teachers.Family,
                     Participantlevel = trainingcalendars.Participantlevel,
                     Description = trainingcalendars.Description +"-"+ temp.TableValue , 
                     TrainingCalendarDate = trainingcalendars.TrainingCalendarDate,
                     TrainingCalendarDay = trainingcalendars.TrainingCalendarDay,
                     TableTypeTrainingCalendarDateId = (temp.TableInterfaceValueId == 0 ? 0 : trainingcalendars.TableTypeTrainingCalendarDateId),
                     NameOfTrainingCalendarDate = temp.TableValue,
                     TrainingCalendarDateId = ID,
                 });
            return _query;
        }
        
    }
}
