using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report
{
    public partial class EmployeeTrainingPassedReport
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

        public EmployeeTrainingPassedReport()
        {
             
        }

        public EmployeeTrainingPassedReport(string trainingcoursename, bool sd, bool ojt, bool c,
                string trainingvenueName, Double duration, DateTime datecoursedatetime, string datecourse, bool certificatestateyse, bool certificatestateno)
        {
            TrainingCourseName = trainingcoursename;
            SD = SD;
            OJT = ojt;
            C = c;
            TrainingvenueName = trainingvenueName;
            Duration = duration;
            DateCourseDateTime = datecoursedatetime;
            Datecourse = datecourse;
            CertificateStateYse = certificatestateyse;
            CertificateStateNo = certificatestateno;
        }
    }
}
