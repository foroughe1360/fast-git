using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class PlacementTabJobTraining
    {
        public int PlacementTabJobTrainingId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int PlacementTabJobTrainingDateId { get; set; }
        public int EmployemeId { get; set; }
        public int SectionId { get; set; }
        public int PostGroupId { get; set; }
        public DateTime DateStartPostGroupName { get; set; }
        public string PreviousJobs { get; set; }
        public int CorporateResponsibility { get; set; }
        public bool Hidden { get; set; }

        public PlacementTabJobTraining()
        {
        }

        public PlacementTabJobTraining(int placementtabjobtrainingdateid,int employemeId , int sectionid, 
            int postgroupid,DateTime datestartpostgroupname,string previousjobs,int corporateresponsibility)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            PlacementTabJobTrainingDateId = placementtabjobtrainingdateid;
            EmployemeId = employemeId;
            SectionId = sectionid;
            PostGroupId = postgroupid;
            DateStartPostGroupName = datestartpostgroupname;
            PreviousJobs = previousjobs;
            CorporateResponsibility = corporateresponsibility;
            Hidden = false;
        }
    }
}