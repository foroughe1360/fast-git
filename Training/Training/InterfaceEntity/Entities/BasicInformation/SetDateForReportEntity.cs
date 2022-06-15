using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class SetDateForReportEntity : SetDateForReport
    {

        public string ReportNameTitle { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfApproverStr { get; set; }

        public string DateOfRegistrarStr { get; set; }

        public SetDateForReportEntity()
        {

        }

        public SetDateForReportEntity(int setdateforreportid, int reportnameid, int employemeId, int publiccode,
             DateTime dateofproducer, DateTime dateofapprover,DateTime dateofregistrar) : base(setdateforreportid, reportnameid, employemeId, publiccode,
              dateofproducer, dateofapprover, dateofregistrar)
        {

        }
    }
}
