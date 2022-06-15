using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class EmployeeTrainingPassedEntity: EmployeeTrainingPassed
    {
        public string TrainingCourseName { get; set; }
        public bool SD { get; set; }
        public bool OJT { get; set; }
        public bool C { get; set; } 
        public string TrainingvenueName { get; set; }
        public string DateCourseStr { get; set; }
        public EmployeeTrainingPassedEntity()
        {

        }

        public EmployeeTrainingPassedEntity(int employemeid, int trainingcourseid, int tabletypeoftrainingid,
            int trainingvenueid, Double duration, DateTime datecourse, bool certificatestate):
            base(employemeid, trainingcourseid, tabletypeoftrainingid, trainingvenueid, duration, datecourse, certificatestate)
        {
        }
    }
}
