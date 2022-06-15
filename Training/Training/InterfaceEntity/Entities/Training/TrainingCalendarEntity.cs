using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TrainingCalendarEntity: TrainingCalendar
    {
        public string TeacherName { get; set; }
        public string Day { get; set; }
        public string TrainingCalendarDatestr { get; set; }


        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }

        public string NameOfTrainingCalendarDate { get; set; }
        public TrainingCalendarEntity()
        {

        }

        public TrainingCalendarEntity(int trainingcalendardateid, string coursename, int teacherid, string participantlevel, 
            string description, DateTime trainingcalendardate,string trainingcalendarday ,int tabletypetrainingcalendardateid)
            :base(trainingcalendardateid,coursename, teacherid,participantlevel,description,trainingcalendardate, trainingcalendarday, tabletypetrainingcalendardateid)
        {

        }
    }
}
