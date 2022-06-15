using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class CompetencyOperateTheMachine
    {
        public int CompetencyOperateTheMachineId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ListQualificationOfStaffId { get; set; }
        public int LaboratoryDevicesId { get; set; }
        public bool Hidden { get; set; }

        public CompetencyOperateTheMachine()
        {
            
        }

        public CompetencyOperateTheMachine(int listqualificationofstaffid,int laboratorydevicesid)
        {
            ListQualificationOfStaffId = listqualificationofstaffid;
            LaboratoryDevicesId = laboratorydevicesid;
        }
    }
}
