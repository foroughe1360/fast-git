using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public class HistoryQualificationOfStaffEntity: HistoryQualificationOfStaff
    {
        public HistoryQualificationOfStaffEntity() { }
        public HistoryQualificationOfStaffEntity(int listQualificationOfStaffId , int signatureresponsibilityid, int stagenameid, string description, int workflowstate)
        {
            listQualificationOfStaffId = ListQualificationOfStaffId;
            SignatureResponsibilityId = signatureresponsibilityid;
            StageNameId = stagenameid;
            Description = description;
            WorkFlowState = workflowstate;
        }
    }
}
