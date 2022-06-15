using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;

namespace Bussiness
{
    public class AttendanceDateProvider : IAttendanceDateProvider
    {
        private AttendanceDateDAC _AttendanceDateDAC;
        private ListTypeTestScoreDAC _ListTypeTestScoreDAC;

        public AttendanceDateProvider()
        {
            _AttendanceDateDAC = new AttendanceDateDAC();
            _ListTypeTestScoreDAC = new ListTypeTestScoreDAC();
        }

        public int Add(AttendanceDateEntity Current)
        {
            General _General = new General();
            Current.AttendanceAbsenceDate = _General.ShamsiToMiladi(Current.AttendanceAbsenceDateStr);
            AttendanceDate _AttendanceDate = new AttendanceDate(Current.DesignTrainingCourseId,Current.AttendanceAbsenceDate);
            return _AttendanceDateDAC.Add(_AttendanceDate);
        }

        public bool Delete(int ID)
        {
            return _AttendanceDateDAC.Delete(ID);
        }

        public bool Edit(AttendanceDateEntity Current)
        {
            General _General = new General();
            AttendanceDate _AttendanceDate = new AttendanceDate();
            _AttendanceDate.AttendanceDateId = Current.AttendanceDateId;
            _AttendanceDate.TimeLastModified = DateTime.Now;
            _AttendanceDate.DesignTrainingCourseId = Current.DesignTrainingCourseId;
            _AttendanceDate.AttendanceAbsenceDate = _General.ShamsiToMiladi(Current.AttendanceAbsenceDateStr);
            return _AttendanceDateDAC.Edit(_AttendanceDate);
        }

        public AttendanceDateEntity Get(int ID)
        {
            AttendanceDateEntity _AttendanceDateEntity = new AttendanceDateEntity();
            var q = _AttendanceDateDAC.Get(ID);
            _AttendanceDateEntity.AttendanceDateId = q.AttendanceDateId;
            _AttendanceDateEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
            _AttendanceDateEntity.AttendanceAbsenceDate = q.AttendanceAbsenceDate;
            return _AttendanceDateEntity;
        }

        public IQueryable<AttendanceDateEntity> GetAll()
        {
            return (IQueryable<AttendanceDateEntity>)_AttendanceDateDAC.GetAll();
        }

        public IQueryable<AttendanceDateEntity> GetAll(int ID)
        {
            var query = _AttendanceDateDAC.GetAll(ID);
            return
                (from q in query
                 select new AttendanceDateEntity
                 {
                     AttendanceDateId=q.AttendanceDateId,
                     DesignTrainingCourseId=q.DesignTrainingCourseId,
                     AttendanceAbsenceDate=q.AttendanceAbsenceDate
                 });
        }

        public IQueryable<AttendanceDateReport> GetAttendanceDate(int designtrainingcourseid)
        {
           return _AttendanceDateDAC.GetAttendanceDate(designtrainingcourseid);

           // var listAttendanceDateReport = _AttendanceDateDAC.GetAttendanceDate(designtrainingcourseid).ToList();
           // var listTypeTestScoreEntity = _ListTypeTestScoreDAC.GetAllListTypeTestScoreVarietyOfTestName(designtrainingcourseid).ToList();
           //return null;
        }

        public AttendanceDateEntity getCourseDate(int attendancedateid)
        {
            General _General = new General();
            var q =_AttendanceDateDAC.getCourseDate(attendancedateid);
            if (q != null)
                q.AttendanceAbsenceDateStr = _General.MiladiToShamsi(q.AttendanceAbsenceDate);
            return q;
        }
    }
}
