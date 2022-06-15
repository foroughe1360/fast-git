using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class ListQualificationOfStaffProvider : IListQualificationOfStaffProvider
    {
        private ListQualificationOfStaffDAC _ListQualificationOfStaffDAC;
        public ListQualificationOfStaffProvider()
        {
            _ListQualificationOfStaffDAC = new ListQualificationOfStaffDAC();
        }
        public int Add(ListQualificationOfStaffEntity Current)
        {
            return _ListQualificationOfStaffDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _ListQualificationOfStaffDAC.Delete(ID);
        }

        public bool Edit(ListQualificationOfStaffEntity Current)
        {
            return _ListQualificationOfStaffDAC.Edit(Current);
        }

        public ListQualificationOfStaffEntity Get(int ID)
        {
            ListQualificationOfStaffEntity _ListQualificationOfStaffEntity = new ListQualificationOfStaffEntity();
            var q = _ListQualificationOfStaffDAC.Get(ID);
            _ListQualificationOfStaffEntity.AnalysisAndInterpretationOfResults = q.AnalysisAndInterpretationOfResults;
            _ListQualificationOfStaffEntity.CollectionId = q.CollectionId;
            _ListQualificationOfStaffEntity.CompetencyOperateTheMachine = q.CompetencyOperateTheMachine;
            _ListQualificationOfStaffEntity.CompetencyOperateTheMachineDatetime = q.CompetencyOperateTheMachineDatetime;
            _ListQualificationOfStaffEntity.CompetencyOperateTheMachineType = q.CompetencyOperateTheMachineType;
            _ListQualificationOfStaffEntity.CompetencyTesting = q.CompetencyTesting;
            _ListQualificationOfStaffEntity.CompetencyTestingDatetime = q.CompetencyTestingDatetime;
            _ListQualificationOfStaffEntity.CompetencyTestingType = q.CompetencyTestingType;
            _ListQualificationOfStaffEntity.CompilingReports = q.CompilingReports;
            _ListQualificationOfStaffEntity.EmployemesId = q.EmployemesId;
            _ListQualificationOfStaffEntity.InitialVerificationReport = q.InitialVerificationReport;
            _ListQualificationOfStaffEntity.ListQualificationOfStaffId = q.ListQualificationOfStaffId;
            _ListQualificationOfStaffEntity.TheFinalVerificationReport = q.TheFinalVerificationReport;
            _ListQualificationOfStaffEntity.TrainingManagerApproval = q.TrainingManagerApproval;
            _ListQualificationOfStaffEntity.TrainingManagerApprovalDate = q.TrainingManagerApprovalDate;
            return _ListQualificationOfStaffEntity;
            
            //return (ListQualificationOfStaffEntity)_ListQualificationOfStaffDAC.Get(ID);
        }

        public IQueryable<ListQualificationOfStaffEntity> GetAll()
        {
            var query = _ListQualificationOfStaffDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new ListQualificationOfStaffEntity()
                 {
                     AnalysisAndInterpretationOfResults = q.AnalysisAndInterpretationOfResults,
                     CollectionId = q.CollectionId,
                     CompetencyOperateTheMachine = q.CompetencyOperateTheMachine,
                     CompetencyOperateTheMachineDatetime = q.CompetencyOperateTheMachineDatetime,
                     CompetencyOperateTheMachineType = q.CompetencyOperateTheMachineType,
                     CompetencyTesting = q.CompetencyTesting,
                     CompetencyTestingDatetime = q.CompetencyTestingDatetime,
                     CompetencyTestingType = q.CompetencyTestingType,
                     CompilingReports = q.CompilingReports,
                     EmployemesId = q.EmployemesId,
                     InitialVerificationReport = q.InitialVerificationReport,
                     ListQualificationOfStaffId = q.ListQualificationOfStaffId,
                     TheFinalVerificationReport = q.TheFinalVerificationReport,
                     TrainingManagerApproval = q.TrainingManagerApproval,
                     TrainingManagerApprovalDate = q.TrainingManagerApprovalDate

                 });
            return _query;

            // return (IQueryable<ListQualificationOfStaffEntity>)_ListQualificationOfStaffDAC.GetAll();
        }
    }
}
