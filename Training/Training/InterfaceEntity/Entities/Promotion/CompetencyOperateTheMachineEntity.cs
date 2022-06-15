using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class CompetencyOperateTheMachineEntity : CompetencyOperateTheMachine
    {
        public CompetencyOperateTheMachineEntity()
        {
        }
        public CompetencyOperateTheMachineEntity(int listqualificationofstaffid, int laboratorydevicesid)
        {
            ListQualificationOfStaffId = listqualificationofstaffid;
            LaboratoryDevicesId = laboratorydevicesid;
        }
        
    }
}
