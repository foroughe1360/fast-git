using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class EmployemeJobEntity: EmployemeJob
    {
        public string EmployemeName { get; set; }
        public string PostGroupName { get; set; }
        public int UnitSCenterId { get; set; }
        public string UnitSCenterName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string DateStartPostGroupNameStr { get; set; }
        public string PreviousJobs { get; set; }
        public EmployemeJobEntity()
        {

        }
        public EmployemeJobEntity(int employemeid, int postgroupid, int sectionid,DateTime datestartpostgroupname,bool activepostgroupname)
            :base(employemeid,postgroupid,sectionid, datestartpostgroupname, activepostgroupname)
        {
        }
    }
}
