using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
   public class SetDateForReport
    {
        public int SetDateForReportId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ReportNameId { get; set; }
        public int EmployemeId { get; set; }
        public int PublicCode { get; set; }
        public DateTime DateOfProducer { get; set; }
        public DateTime DateOfApprover { get; set; }
        public DateTime DateOfRegistrar { get; set; }

        public bool Hidden { get; set; }
        public SetDateForReport()
        {
        }

        public SetDateForReport(int setdateforreportid,int reportnameid , int employemeId, int publiccode,
             DateTime dateofproducer, DateTime dateofapprover,DateTime dateofregistrar)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            SetDateForReportId = setdateforreportid;
            ReportNameId = reportnameid;
            EmployemeId = employemeId;
            PublicCode = publiccode;
            DateOfProducer = dateofproducer;
            DateOfApprover = dateofapprover;
            DateOfRegistrar = dateofregistrar;
            Hidden = false;
        }
    }
}
