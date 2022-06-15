using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Report;
using InterfaceEntity.Search.BasicInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class EmployemeProvider : IEmployemeProvider
    {
        //test
        private EmployemeDAC _EmployemeDAC;
        private General _General;
        public EmployemeProvider()
        {
            _EmployemeDAC = new EmployemeDAC();
        }
        public int Add(EmployemeEntity Current)
        {
            General _General = new General();
            Current.BirthDate = _General.ShamsiToMiladi(Current.BirthDateStr);
            Current.DateOfEmployement = _General.ShamsiToMiladi(Current.DateOfEmployementStr);
            Employeme _Employeme = new Employeme(Current.FirstName, Current.LastName, Current.FatherName, Current.PlaceOfBirth,
                Current.BirthDate, Current.FieldOfStudy, Current.IDNumber, Current.DateOfEmployement, Current.PersonnelCode, Current.State,Current.NationalCode);
            return _EmployemeDAC.Add(_Employeme);
        }
        public bool Delete(int ID)
        {
            return _EmployemeDAC.Delete(ID);
        }
        public bool Edit(EmployemeEntity Current)
        {
            General _General = new General();
            Employeme _Employeme = new Employeme();
            _Employeme.EmployemeId = Current.EmployemeId;
            _Employeme.TimeLastModified = DateTime.Now;
            _Employeme.FirstName = Current.FirstName;
            _Employeme.LastName = Current.LastName;
            _Employeme.FatherName = Current.FatherName;
            _Employeme.PlaceOfBirth = Current.PlaceOfBirth;
            _Employeme.BirthDate = _General.ShamsiToMiladi(Current.BirthDateStr);
            _Employeme.FieldOfStudy = Current.FieldOfStudy;
            _Employeme.IDNumber = Current.IDNumber;
            _Employeme.DateOfEmployement = _General.ShamsiToMiladi(Current.DateOfEmployementStr);
            _Employeme.PersonnelCode = Current.PersonnelCode;
            _Employeme.NationalCode = Current.NationalCode;
            _Employeme.State = Current.State;
            return _EmployemeDAC.Edit(_Employeme);
        }
        public EmployemeEntity Get(int ID)
        {
            EmployemeEntity _EmployemeEntity = new EmployemeEntity();
            var q = _EmployemeDAC.Get(ID);
            _EmployemeEntity.BirthDate = q.BirthDate;
            _EmployemeEntity.DateOfEmployement = q.DateOfEmployement;
            _EmployemeEntity.EmployemeId = q.EmployemeId;
            _EmployemeEntity.FatherName = q.FatherName;
            _EmployemeEntity.FieldOfStudy = q.FieldOfStudy;
            _EmployemeEntity.FirstName = q.FirstName;
            _EmployemeEntity.IDNumber = q.IDNumber;
            _EmployemeEntity.LastName = q.LastName;
            _EmployemeEntity.PlaceOfBirth = q.PlaceOfBirth;
            _EmployemeEntity.PersonnelCode = q.PersonnelCode;
            _EmployemeEntity.State = q.State;
            _EmployemeEntity.NationalCode = q.NationalCode;
            return _EmployemeEntity;
        }
        public IQueryable<EmployemeEntity> GetAll()
        {
            _General = new General();
            var query = _EmployemeDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new EmployemeEntity()
                 {
                     BirthDate = q.BirthDate,
                     DateOfEmployement = q.DateOfEmployement,
                     EmployemeId = q.EmployemeId,
                     FatherName = q.FatherName,
                     FieldOfStudy = q.FieldOfStudy,
                     FirstName = q.FirstName,
                     IDNumber = q.IDNumber,
                     LastName = q.LastName,
                     PlaceOfBirth = q.PlaceOfBirth,
                     PersonnelCode = q.PersonnelCode,
                     State = q.State,
                     EmployemeName = q.FirstName + " " + q.LastName,
                     NationalCode=q.NationalCode,
                     
                 });
            return _query;
        }
        public IQueryable<EmployemeEntity> GetAll(EmployemeSearch employemesearch)
        {
            _General = new General();
            return _EmployemeDAC.GetAll(employemesearch);
        }
        public IQueryable<EmployemeEntity> GetAll(int ID)
        {
            return _EmployemeDAC.GetAllEmployeme(ID);
        }

        #region All Method For Report
        public EmployemeReport GetEmployemeReport(int ID)
        {
            General _General = new General();
            //EmployemeReport _EmployemeReport = new EmployemeReport();
            var _EmployemeReport = _EmployemeDAC.GetEmployemeReport(ID);
            if (_EmployemeReport.BirthDateDatetime != null)
                _EmployemeReport.BirthDate = _General.MiladiToShamsi(_EmployemeReport.BirthDateDatetime);
            if (_EmployemeReport.DateOfEmployementDateTime != null)
                _EmployemeReport.DateOfEmployement = _General.MiladiToShamsi(_EmployemeReport.DateOfEmployementDateTime);

            //نمایش تاریخ تایید و تهیه و تصویب
            SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
            int ReportNameId = (int)ReportName.ReportNames.Employemes;
            var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);
            if (_SetDateForReport.Count() != 0)
            {
                _EmployemeReport.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                _EmployemeReport.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                _EmployemeReport.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
            }
            //---

            return _EmployemeReport;
        }
        public IQueryable<EmployeeTrainingPassedReport> GetEmployeeTrainingPassedReport(int ID)
        {
            return _EmployemeDAC.GetEmployeeTrainingPassedReport(ID);
        }
        public EmployemeOJTReport GetPlacementTabJobTraining(int ID)
        {
            return _EmployemeDAC.GetPlacementTabJobTraining(ID);
        }

        public EmployemeOJTReport GetPlacementTabJobTrainings(int ID)
        {
            return _EmployemeDAC.GetPlacementTabJobTrainings(ID);
        }
        public IQueryable<EmployemeOJTReport> GetAllPreviousjobs(int ID)
        {
            return _EmployemeDAC.GetAllPreviousjobs(ID);
        }
        public IQueryable<EmployemeForReport> GetAllForReport()
        {
            return _EmployemeDAC.GetAllForReport();
        }

        #endregion
    }
}
