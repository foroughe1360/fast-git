using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class EmployemeOJTReport
    {
        public string EmployemeName { get; set; }
        public string UnitDepartmentSection { get; set; }
        public string CurrentPostGroupName { get; set; }
        public string LatestFieldOfStudyName { get; set; }
        public DateTime DateOfEmployement { get; set; }
        public string DateOfEmployementStr { get; set; }
        public DateTime DateStartPostGroupName { get; set; }
        public string DateStartPostGroupNameStr { get; set; }
        public string Previousjobs { get; set; }
        public string supervisor { get; set; }
        public string CorporateResponsibility { get; set; }


        public int SupervisorsEmployemeId { get; set; }
        public int EmployemeId { get; set; }
        public Byte[] Signature { get; set; }

        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }
        
    }
}
