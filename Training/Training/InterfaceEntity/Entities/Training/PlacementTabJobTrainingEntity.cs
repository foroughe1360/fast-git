using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class PlacementTabJobTrainingEntity : PlacementTabJobTraining
    {
        public string EmployemeName { get; set; }
        public string UnitDepartmentSection{ get; set; }
        public string CurrentPostGroupName { get; set; }
        public string LatestFieldOfStudyName { get; set; }
        public DateTime DateOfEmployement { get; set; }
        public int UnitSCenterId { get; set; }
        public string UnitSCenterName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string DateStartPostGroupNameStr { get; set; }

        public DateTime DateOfProducer { get; set; }
        public DateTime DateOfApprover { get; set; }

        public string DateOfProducerstr { get; set; }
        public string DateOfApproverstr { get; set; }
        public double? SumNumberOfHours { get; set; }

        public PlacementTabJobTrainingEntity() { }
        public PlacementTabJobTrainingEntity(int placementtabjobtrainingdateid, int employemeId, int sectionid, 
             int postgroupid, DateTime datestartpostgroupname,string previousjobs ,int corporateresponsibility) 
            :base(placementtabjobtrainingdateid,employemeId,sectionid, postgroupid, datestartpostgroupname, previousjobs,
                 corporateresponsibility  )
        {
        }
    }
}
