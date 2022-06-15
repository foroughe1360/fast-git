using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class PostReportEmployeme
    {
        public string UnitDepartmentSection { get; set; }
        public string Post { get; set; }
        public string EmployemeName { get; set; }

        public int EmployemeId { get; set; }

        public DateTime DateNeed { get; set; }
        public string DateNeedStr { get; set; } 
        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }
    }
}
