using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class EmployeeTrainingPassed
    {
        public int EmployeeTrainingPassedId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int Employemeid { get; set; }
        public int TrainingCourseId { get; set; }
        public int TableTypeOfTrainingId { get; set; }
        public int TrainingVenueId { get; set; }
        public Double Duration { get; set; }
        public DateTime DateCourse { get; set; }
        public bool CertificateState { get; set; }
        public bool Hidden { get; set; }

        public EmployeeTrainingPassed()
        {
            
        } 

        public EmployeeTrainingPassed(int employemeid,int trainingcourseid,int tabletypeoftrainingid,
            int trainingvenueid, Double duration,DateTime datecourse,bool certificatestate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Employemeid = employemeid;
            TrainingCourseId = trainingcourseid;
            TableTypeOfTrainingId = tabletypeoftrainingid;
            TrainingVenueId = trainingvenueid;
            Duration = duration;
            DateCourse = datecourse;
            CertificateState = certificatestate;
            Hidden = false;
        }
    }
}
