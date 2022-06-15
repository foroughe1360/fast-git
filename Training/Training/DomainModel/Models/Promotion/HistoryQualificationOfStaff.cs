using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class HistoryQualificationOfStaff
    {
        public int HistoryQualificationOfStaffId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ListQualificationOfStaffId { get; set; }
        public int SignatureResponsibilityId { get; set; }
        public int StageNameId { get; set; }
        public string Description { get; set; }
        public int WorkFlowState { get; set; }
        public bool Hidden { get; set; }

        public HistoryQualificationOfStaff()
        {
            
        }

        public HistoryQualificationOfStaff(int listQualificationOfStaffId, int signatureresponsibilityid,int stagenameid,string description, int workflowstate)
        {
            ListQualificationOfStaffId = listQualificationOfStaffId;
            SignatureResponsibilityId = signatureresponsibilityid;
            StageNameId = stagenameid;
            Description = description;
            WorkFlowState = workflowstate;
        }
    }
}
