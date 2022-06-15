using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;

namespace Bussiness
{
    public class FinancialCommitmentProvider : IFinancialCommitmentProvider
    {
        private FinancialCommitmentDAC _FinancialCommitmentDAC;

        public FinancialCommitmentProvider()
        {
            _FinancialCommitmentDAC = new FinancialCommitmentDAC();
        }

        public int Add(FinancialCommitmentEntity Current)
        {
            General _General = new Bussiness.General();
            Current.FromDate = _General.ShamsiToMiladi(Current.FromDateStr);
            Current.ToDate = _General.ShamsiToMiladi(Current.ToDateStr);
            FinancialCommitment _FinancialCommitment = new FinancialCommitment
                (Current.EmployemeId, Current.TrainingCourseId, Current.TrainingVenueId, Current.AmountPierced, Current.TimeEmployment,
                Current.FromDate,Current.ToDate,Current.FinancialYear);
            return _FinancialCommitmentDAC.Add(_FinancialCommitment);
        }

        public bool Delete(int ID)
        {
            return _FinancialCommitmentDAC.Delete(ID);
        }

        public bool Edit(FinancialCommitmentEntity Current)
        {
            General _General = new Bussiness.General();
            FinancialCommitment _FinancialCommitment = new FinancialCommitment();
            _FinancialCommitment.FinancialCommitmentId = Current.FinancialCommitmentId;
            _FinancialCommitment.TimeLastModified = DateTime.Now;
            _FinancialCommitment.EmployemeId = Current.EmployemeId;
            _FinancialCommitment.TrainingCourseId = Current.TrainingCourseId;
            _FinancialCommitment.TrainingVenueId = Current.TrainingVenueId;
            _FinancialCommitment.AmountPierced = Current.AmountPierced;
            _FinancialCommitment.TimeEmployment = Current.TimeEmployment;
            _FinancialCommitment.FromDate = _General.ShamsiToMiladi(Current.FromDateStr);
            _FinancialCommitment.ToDate = _General.ShamsiToMiladi(Current.ToDateStr);
            _FinancialCommitment.FinancialYear = Current.FinancialYear;

            
            return _FinancialCommitmentDAC.Edit(_FinancialCommitment);
        }

        public FinancialCommitmentEntity Get(int ID)
        {
            FinancialCommitmentEntity _FinancialCommitmentEntity = new FinancialCommitmentEntity();
            var q = _FinancialCommitmentDAC.Get(ID);
            _FinancialCommitmentEntity.AmountPierced = q.AmountPierced;
            _FinancialCommitmentEntity.EmployemeId = q.EmployemeId;
            _FinancialCommitmentEntity.FinancialCommitmentId = q.FinancialCommitmentId;
            _FinancialCommitmentEntity.TimeEmployment = q.TimeEmployment;
            _FinancialCommitmentEntity.TrainingCourseId = q.TrainingCourseId;
            _FinancialCommitmentEntity.TrainingVenueId = q.TrainingVenueId;
            _FinancialCommitmentEntity.FromDate = q.FromDate;
            _FinancialCommitmentEntity.ToDate = q.ToDate;
            _FinancialCommitmentEntity.FinancialYear = q.FinancialYear;

            return _FinancialCommitmentEntity;
        }

        public FinancialCommitmentEntity GetFinancialCommitment(int ID)
        {
            FinancialCommitmentEntity _FinancialCommitmentEntity = new FinancialCommitmentEntity();
            return _FinancialCommitmentDAC.GetFinancialCommitment(ID);
        }

        public IQueryable<FinancialCommitmentEntity> GetAll()
        {
            return _FinancialCommitmentDAC.GetAllFinancialCommitment();
        }

        //public IQueryable<FinancialCommitmentEntity> GetAll(int ID)
        //{
        //    //return _FinancialCommitmentDAC.GetAllFinancialCommitment(ID);
          
        //}
        public IQueryable<FinancialCommitmentEntity> GetAll(FinancialCommitmentSearch financialcommitmentsearch)
        {
            return _FinancialCommitmentDAC.GetAll(financialcommitmentsearch);
        }

    }

}
