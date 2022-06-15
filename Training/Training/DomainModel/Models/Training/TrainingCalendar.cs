using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TrainingCalendar
    {
        public int TrainingCalendarId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TrainingCalendarDateId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public string Participantlevel { get; set; }
        public string Description { get; set; }
        public DateTime TrainingCalendarDate { get; set; }
        public string TrainingCalendarDay { get; set; }

        public int TableTypeTrainingCalendarDateId { get; set; }
        public bool Hidden { get; set; }

        public TrainingCalendar()
        {

        }

        public TrainingCalendar(int trainingcalendardateid,string coursename, int teacherid, string participantlevel, string description, 
            DateTime trainingcalendardate,string trainingcalendarday,int tabletypetrainingcalendardateid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TrainingCalendarDateId = trainingcalendardateid;
            CourseName = coursename;
            TeacherId = teacherid;
            Participantlevel = participantlevel;
            Description = description;
            TrainingCalendarDate = trainingcalendardate;
            TrainingCalendarDay = trainingcalendarday;
            TableTypeTrainingCalendarDateId = tabletypetrainingcalendardateid;
            Hidden = false;
        }
    }
}
