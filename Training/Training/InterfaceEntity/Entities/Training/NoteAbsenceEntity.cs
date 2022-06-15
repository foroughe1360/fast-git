using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public  class NoteAbsenceEntity : NoteAbsence
    {
        public string EmployemesName { get; set; }
        public int EmployemeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string  HourDelayFrom { get; set; }
        public string HourDelayTo { get; set; }
        public int CourseregistrationId { get; set; }
        public int designtrainingcourseId { get; set; }
        public string CourseName { get; set; }
        public string WrittenNoticeName { get; set; }
        public int TrainingCourseId { get; set; }
        public bool ChkNoteAbsence { get; set; }

        public NoteAbsenceEntity() { }

        public NoteAbsenceEntity(int attendanceid, int writtennoticeid) : base(attendanceid, writtennoticeid)
        {
        }

        public enum NoteAbsence : int
        {
            ForInformation=150,// جهت اطلاع
            Records = 151 // درج در پرونده

        }
    }
}
