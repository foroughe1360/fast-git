using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListQualificationOfStaff
    {
        public int ListQualificationOfStaffId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int EmployemesId { get; set; }
        public int CollectionId { get; set; }
        public DateTime TrainingManagerApprovalDate { get; set; }
        public int TrainingManagerApproval { get; set; }
        public DateTime CompetencyTestingDatetime { get; set; }
        public int CompetencyTesting { get; set; }
        public DateTime CompetencyOperateTheMachineDatetime { get; set; }
        public int CompetencyOperateTheMachine { get; set; }
        public int CompetencyTestingType { get; set; }
        public int CompetencyOperateTheMachineType { get; set; }
        public bool CompilingReports { get; set; }
        public bool AnalysisAndInterpretationOfResults { get; set; }
        public bool InitialVerificationReport { get; set; }
        public bool TheFinalVerificationReport { get; set; }
        public bool Hidden { get; set; }

        public ListQualificationOfStaff()
        {
            
        }

        public ListQualificationOfStaff(int employemesid, int collectionid,DateTime trainingmanagerapprovaldate, int trainingmanagerapproval,
            DateTime competencytestingdatetime, int competencytesting, DateTime competencyoperatethemachinedatetime, int competencyoperatethemachine,
            int competencytestingtype, int competencyoperatethemachinetype,bool compilingreports, bool analysisandinterpretationofresults,
            bool initialverificationreport, bool thefinalverificationreport)
        {
            EmployemesId = employemesid;
            CollectionId = collectionid;
            TrainingManagerApprovalDate = trainingmanagerapprovaldate;
            TrainingManagerApproval = trainingmanagerapproval;
            CompetencyTestingDatetime = competencytestingdatetime;
            CompetencyTesting = competencytesting;
            CompetencyOperateTheMachineDatetime = competencyoperatethemachinedatetime;
            CompetencyOperateTheMachine = competencyoperatethemachine;
            CompetencyTestingType = competencytestingtype;
            CompetencyOperateTheMachineType = competencyoperatethemachinetype;
            CompilingReports = compilingreports;
            AnalysisAndInterpretationOfResults = analysisandinterpretationofresults;
            InitialVerificationReport = initialverificationreport;
            TheFinalVerificationReport = thefinalverificationreport;
        }
    }
}
