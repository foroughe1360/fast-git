using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class ListQualificationOfStaffEntity : ListQualificationOfStaff
    {
        public ListQualificationOfStaffEntity() { }
        public ListQualificationOfStaffEntity(int employemesid, int collectionid, DateTime trainingmanagerapprovaldate, int trainingmanagerapproval,
            DateTime competencytestingdatetime, int competencytesting, DateTime competencyoperatethemachinedatetime, int competencyoperatethemachine,
            int competencytestingtype, int competencyoperatethemachinetype, bool compilingreports, bool analysisandinterpretationofresults,
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
