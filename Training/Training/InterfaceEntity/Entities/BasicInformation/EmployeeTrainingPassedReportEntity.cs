using InterfaceEntity.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class EmployeeTrainingPassedReportEntity : EmployeeTrainingPassedReport
    {
        public string TrainingCourseName { get; set; }
        public bool SD { get; set; }
        public bool OJT { get; set; }
        public bool C { get; set; }
        public string TrainingvenueName { get; set; }
        public Double Duration { get; set; }
        public DateTime DateCourseDateTime { get; set; }
        public string Datecourse { get; set; }
        public bool CertificateStateYse { get; set; }
        public bool CertificateStateNo { get; set; }


        public EmployeeTrainingPassedReportEntity()
        {

        }

        public EmployeeTrainingPassedReportEntity(string trainingcoursename, bool sd, bool ojt, bool c,
            string trainingvenueName, Double duration, DateTime datecoursedatetime, string datecourse, bool certificatestateyse, bool certificatestateno) :
            base(trainingcoursename, sd, ojt, c,
             trainingvenueName, duration, datecoursedatetime, datecourse, certificatestateyse, certificatestateno)
        {
        }
    }
}

