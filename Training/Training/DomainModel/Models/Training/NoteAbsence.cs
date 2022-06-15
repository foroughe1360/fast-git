using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class NoteAbsence
    {
        public int NoteAbsenceId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int AttendanceId { get; set; }
        public int WrittenNoticeId { get; set; }
        public bool Hidden { get; set; }

        public NoteAbsence()
        {
            
        }

        public NoteAbsence(int attendanceid,int writtennoticeid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;

            AttendanceId = attendanceid;
            WrittenNoticeId = writtennoticeid;
        }
    }
}
