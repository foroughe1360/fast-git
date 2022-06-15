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
    public class NoteAbsenceProvider : INoteAbsenceProvider
    {
        private NoteAbsenceDAC _NoteAbsenceDAC;
        public NoteAbsenceProvider()
        {
            _NoteAbsenceDAC = new NoteAbsenceDAC();
        }
        public int Add(NoteAbsenceEntity Current)
        {
            NoteAbsence _NoteAbsence = new NoteAbsence(Current.AttendanceId,Current.WrittenNoticeId);
            return _NoteAbsenceDAC.Add(_NoteAbsence);
        }

        public bool Delete(int ID)
        {
            return _NoteAbsenceDAC.Delete(ID);
        }

        public bool Edit(NoteAbsenceEntity Current)
        {
            NoteAbsence _NoteAbsence = new NoteAbsence();
            _NoteAbsence.NoteAbsenceId = Current.NoteAbsenceId;
            _NoteAbsence.TimeLastModified = DateTime.Now;
            _NoteAbsence.WrittenNoticeId = Current.WrittenNoticeId;

            return _NoteAbsenceDAC.Edit(_NoteAbsence);
        }

        public NoteAbsenceEntity Get(int ID)
        {
            NoteAbsenceEntity _NoteAbsenceEntity = new NoteAbsenceEntity();
            var q = _NoteAbsenceDAC.Get(ID);
            _NoteAbsenceEntity.NoteAbsenceId = q.NoteAbsenceId;
            _NoteAbsenceEntity.AttendanceId = _NoteAbsenceEntity.AttendanceId;
            _NoteAbsenceEntity.WrittenNoticeId = q.WrittenNoticeId;

            return _NoteAbsenceEntity;

            //return (NoteAbsenceEntity)_NoteAbsenceDAC.Get(ID);
        }

        public NoteAbsenceReport GetNoteAbsencePrint(int ID)
        {
            return _NoteAbsenceDAC.GetNoteAbsencePrint(ID);
        }

        public IQueryable<NoteAbsenceEntity> GetAll()
        {
          return (IQueryable<NoteAbsenceEntity>)_NoteAbsenceDAC.GetAll();
        }

        public IQueryable<NoteAbsenceEntity> GetAll(int ID)
        {
            return _NoteAbsenceDAC.GetAllNoteAbsence(ID);
        }

        public IQueryable<NoteAbsenceReport> GetAllNoteAbsencePrint(int ID)
        {
            return _NoteAbsenceDAC.GetAllNoteAbsencePrint(ID);
        }


    }
}
