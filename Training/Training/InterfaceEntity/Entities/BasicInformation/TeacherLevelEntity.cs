using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TeacherLevelEntity: TeacherLevel
    {
        public string TeacherName { get; set; }
        public string TrainingCourseName { get; set; }
        public double Total { get; set; }

        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }
        public TeacherLevelEntity()
        {

        }

        public TeacherLevelEntity(int teacherleveldateid, int teacherid, string trainingcourse,
            double effectivenessofpreviousperiod, double rhetorical, double educationid,
            double experience, double courseplan, double historyofcooperation, double degree):
               base(teacherleveldateid, teacherid, trainingcourse, effectivenessofpreviousperiod, rhetorical, educationid, experience, courseplan, historyofcooperation, degree)
        { }
    }
}
