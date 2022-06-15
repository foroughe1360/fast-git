using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess.Training;
using DomainModel.Models;
using InterfaceEntity.Search.Trianing;

namespace Bussiness
{
    public class TrainingCalendarProvider : ITrainingCalendarProvider
    {
        private TrainingCalendarDAC _TrainingCalendarDAC;
        public TrainingCalendarProvider()
        {
            _TrainingCalendarDAC = new TrainingCalendarDAC();
        }

        public int Add(TrainingCalendarEntity Current)
        {
            General _General = new General();
            Current.TrainingCalendarDate = _General.ShamsiToMiladi(Current.TrainingCalendarDatestr);
            TrainingCalendar _TrainingCalendar = new TrainingCalendar(Current.TrainingCalendarDateId,Current.CourseName, 
                Current.TeacherId, Current.Participantlevel, Current.Description, Current.TrainingCalendarDate,Current.TrainingCalendarDay,Current.TableTypeTrainingCalendarDateId);
            return _TrainingCalendarDAC.Add(_TrainingCalendar);
        }

        public bool Delete(int ID)
        {
            return _TrainingCalendarDAC.Delete(ID);
        }

        public bool Edit(TrainingCalendarEntity Current)
        {
            General _General = new General();
            TrainingCalendar _TrainingCalendar = new TrainingCalendar();
            _TrainingCalendar.TrainingCalendarId = Current.TrainingCalendarId;
            _TrainingCalendar.TimeLastModified = DateTime.Now;
            _TrainingCalendar.TrainingCalendarDateId = Current.TrainingCalendarDateId;
            _TrainingCalendar.CourseName = Current.CourseName;
            _TrainingCalendar.TeacherId = Current.TeacherId;
            _TrainingCalendar.Participantlevel = Current.Participantlevel;
            _TrainingCalendar.Description = Current.Description;
            _TrainingCalendar.TrainingCalendarDate = _General.ShamsiToMiladi(Current.TrainingCalendarDatestr);
            _TrainingCalendar.TrainingCalendarDay = Current.TrainingCalendarDay;
            _TrainingCalendar.TableTypeTrainingCalendarDateId = Current.TableTypeTrainingCalendarDateId;
            return _TrainingCalendarDAC.Edit(_TrainingCalendar);
        }

        public TrainingCalendarEntity Get(int ID)
        {
            TrainingCalendarEntity _TrainingCalendarEntity = new TrainingCalendarEntity();
            var q = _TrainingCalendarDAC.Get(ID);
            _TrainingCalendarEntity.TrainingCalendarId = q.TrainingCalendarId;
            _TrainingCalendarEntity.TrainingCalendarDateId = q.TrainingCalendarDateId;
            _TrainingCalendarEntity.CourseName = q.CourseName;
            _TrainingCalendarEntity.TeacherId = q.TeacherId;
            _TrainingCalendarEntity.Participantlevel = q.Participantlevel;
            _TrainingCalendarEntity.Description = q.Description;
            _TrainingCalendarEntity.TrainingCalendarDate = q.TrainingCalendarDate;
            _TrainingCalendarEntity.TrainingCalendarDay = q.TrainingCalendarDay;
            _TrainingCalendarEntity.TableTypeTrainingCalendarDateId = q.TableTypeTrainingCalendarDateId;
            return _TrainingCalendarEntity;
        }

        public IQueryable<TrainingCalendarEntity> GetAll()
        {
            return (IQueryable < TrainingCalendarEntity > )_TrainingCalendarDAC.GetAll();
        }

        public IQueryable<TrainingCalendarEntity> GetAll(int ID)
        {
            return _TrainingCalendarDAC.GetAllTrainingCalendar(ID);
        }
        public IQueryable<TrainingCalendarEntity> GetAll(TrainingCalendarSearch trainingcalendarsearch)
        {
            return _TrainingCalendarDAC.GetAll(trainingcalendarsearch);
        }

    }
}
