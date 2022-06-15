using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;

namespace Bussiness
{
    public class AttendanceProvider : IAttendanceprovider
    {
        private AttendanceDAC _AttendanceDAC;
        public AttendanceProvider()
        {
            _AttendanceDAC = new AttendanceDAC();
        }
        public int Add(AttendanceEntity Current)
        {
            Attendance _Attendance = new Attendance(Current.AttendanceDateId,Current.CourseRegistrationId,Current.TypeAttendanceId,Current.HourDelayFrom,Current.HourDelayTo);
            return _AttendanceDAC.Add(_Attendance);
        }

        public bool Delete(int ID)
        {
            return _AttendanceDAC.Delete(ID);
        }

        public bool Edit(AttendanceEntity Current)
        {
            Attendance _Attendance = new Attendance();
            _Attendance.AttendanceId = Current.AttendanceId;
            _Attendance.TimeLastModified = DateTime.Now;
            _Attendance.AttendanceDateId = Current.AttendanceDateId;
            _Attendance.CourseRegistrationId = Current.CourseRegistrationId;
            _Attendance.TypeAttendanceId = Current.TypeAttendanceId;
            _Attendance.HourDelayFrom = Current.HourDelayFrom;
            _Attendance.HourDelayTo = Current.HourDelayTo;

            return _AttendanceDAC.Edit(_Attendance);
        }

        public AttendanceEntity Get(int ID)
        {
            AttendanceEntity _AttendanceEntity = new AttendanceEntity();
             var q = _AttendanceDAC.Get(ID);
            if (q != null)
            {
                _AttendanceEntity.AttendanceId = q.AttendanceId;
                _AttendanceEntity.AttendanceDateId = q.AttendanceDateId;
                _AttendanceEntity.TypeAttendanceId = q.TypeAttendanceId;
                _AttendanceEntity.CourseRegistrationId = q.CourseRegistrationId;
                _AttendanceEntity.HourDelayFrom = q.HourDelayFrom;
                _AttendanceEntity.HourDelayTo = q.HourDelayTo;
            }
            else
            {
                _AttendanceEntity = null;
            }
            return _AttendanceEntity;
        }

        public AttendanceEntity GetAttendance(int courseregistrationid, int attendanceid)
        {
            AttendanceEntity _AttendanceEntity = new AttendanceEntity();
            var q = _AttendanceDAC.GetAttendance(courseregistrationid, attendanceid);
            if (q != null)
            {
                _AttendanceEntity.AttendanceId = q.AttendanceId;
                _AttendanceEntity.AttendanceDateId = q.AttendanceDateId;
                _AttendanceEntity.TypeAttendanceId = q.TypeAttendanceId;
                _AttendanceEntity.CourseRegistrationId = q.CourseRegistrationId;
                _AttendanceEntity.HourDelayFrom = q.HourDelayFrom;
                _AttendanceEntity.HourDelayTo = q.HourDelayTo;
            }
            else
            {
                _AttendanceEntity = null;
            }
            return _AttendanceEntity;
        }

        public bool CheckAttendance(int courseregistrationid)
        {
            return _AttendanceDAC.CheckAttendance(courseregistrationid);
        }

        public IQueryable<AttendanceEntity> GetAll()
        {
            return (IQueryable<AttendanceEntity>)_AttendanceDAC.GetAll();
        }

        public IQueryable<AttendanceEntity> GetAll(int attendancedateid, int designtrainingcourseid)
        {
            return _AttendanceDAC.GetAll(attendancedateid, designtrainingcourseid);
        }

        public bool Addlist(List<AttendanceEntity> Current)
        {
            foreach (var item in Current)
            {
                if (GetAttendance(item.CourseRegistrationId, item.AttendanceId) == null)
                {
                    Attendance _Attendance = new Attendance(item.AttendanceDateId, item.CourseRegistrationId, item.TypeAttendanceId, item.HourDelayFrom, item.HourDelayTo);
                    if (item.HourDelayFrom == null)
                        _Attendance.HourDelayFrom = "";
                    else
                        _Attendance.HourDelayFrom = item.HourDelayFrom;

                    if (item.HourDelayTo == null)
                        _Attendance.HourDelayTo = "";
                    else
                        _Attendance.HourDelayTo = item.HourDelayTo;

                    _AttendanceDAC.Add(_Attendance);
                }
                else if (Get(item.AttendanceId) != null)
                {
                    Attendance _Attendance = new Attendance();
                    _Attendance.AttendanceId = item.AttendanceId;
                    _Attendance.TimeLastModified = DateTime.Now;
                    _Attendance.AttendanceDateId = item.AttendanceDateId;
                    _Attendance.CourseRegistrationId = item.CourseRegistrationId;
                    _Attendance.TypeAttendanceId = item.TypeAttendanceId;
                    if (item.HourDelayFrom == null)
                        _Attendance.HourDelayFrom = "";
                    else
                        _Attendance.HourDelayFrom = item.HourDelayFrom;

                    if (item.HourDelayTo == null)
                        _Attendance.HourDelayTo = "";
                    else
                        _Attendance.HourDelayTo = item.HourDelayTo;
                    _AttendanceDAC.Edit(_Attendance);
                }
            }
            return true;
        }

        public IQueryable<AttendanceEntity> GetAllAttendance(int ID)
        {
            return _AttendanceDAC.GetAllAttendance(ID);
        }
    }
}
