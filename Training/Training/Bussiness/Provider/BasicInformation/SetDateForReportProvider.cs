using Bussiness.InfraStructre.BasicInformation;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class SetDateForReportProvider : ISetDateForReportProvider
    {
        private SetDateForReportDAC _SetDateForReportDAC;
        public SetDateForReportProvider()
        {
            _SetDateForReportDAC = new SetDateForReportDAC();
        }
        public int Add(SetDateForReportEntity Current)
        {
            General _General = new General();
            Current.DateOfApprover = _General.ShamsiToMiladi(Current.DateOfApproverStr);
            Current.DateOfProducer = _General.ShamsiToMiladi(Current.DateOfProducerStr);
            Current.DateOfRegistrar = _General.ShamsiToMiladi(Current.DateOfRegistrarStr);

            SetDateForReport _SetDateForReport = new SetDateForReport
                (Current.SetDateForReportId,Current.ReportNameId,Current.EmployemeId,Current.PublicCode,Current.DateOfProducer,Current.DateOfApprover,Current.DateOfRegistrar);
            return _SetDateForReportDAC.Add(_SetDateForReport);
        }

        public bool Delete(int ID)
        {
            return _SetDateForReportDAC.Delete(ID);
        }

        public bool Edit(SetDateForReportEntity Current)
        {
            General _General = new General();
            SetDateForReport _SetDateForReport = new SetDateForReport();
            _SetDateForReport.SetDateForReportId = Current.SetDateForReportId;
            _SetDateForReport.TimeLastModified = DateTime.Now;
           
            _SetDateForReport.DateOfApprover = _General.ShamsiToMiladi(Current.DateOfApproverStr);  
            _SetDateForReport.DateOfProducer = _General.ShamsiToMiladi(Current.DateOfProducerStr);
            _SetDateForReport.DateOfRegistrar = _General.ShamsiToMiladi(Current.DateOfRegistrarStr);
            _SetDateForReport.EmployemeId = Current.EmployemeId;
            _SetDateForReport.PublicCode = Current.PublicCode;
            _SetDateForReport.ReportNameId = Current.ReportNameId;
            return _SetDateForReportDAC.Edit(_SetDateForReport);
        }

        public SetDateForReportEntity Get(int ID)
        {
            SetDateForReportEntity _SetDateForReportEntity = new SetDateForReportEntity();
            var q = _SetDateForReportDAC.Get(ID);
            _SetDateForReportEntity.SetDateForReportId = q.SetDateForReportId;
            _SetDateForReportEntity.DateOfProducer = q.DateOfProducer;
            _SetDateForReportEntity.DateOfApprover = q.DateOfApprover;
            _SetDateForReportEntity.DateOfRegistrar = q.DateOfRegistrar;
            _SetDateForReportEntity.EmployemeId = q.EmployemeId;
            _SetDateForReportEntity.PublicCode = q.PublicCode;
            _SetDateForReportEntity.ReportNameId = q.ReportNameId;
            return _SetDateForReportEntity;
            // return (AssessorEntity)_AssessorDAC.Get(ID);
        }

        public IQueryable<SetDateForReportEntity> GetAll()
        {
            return (IQueryable<SetDateForReportEntity>)_SetDateForReportDAC.GetAll();
        }
        public IQueryable<SetDateForReportEntity> GetAll(int ID , int ReportNameId)
        {
            return _SetDateForReportDAC.GetAll(ID , ReportNameId);
        }

        public IQueryable<SetDateForReportEntity> GetAllSetDateForReport(int ID,int ReportNameId)
        {
            return _SetDateForReportDAC.GetAllSetDateForReport(ID, ReportNameId);
        }
    }
}
