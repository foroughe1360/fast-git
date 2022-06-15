using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class EmployeeTrainingPassedProvider : IEmployeeTrainingPassedProvider
    {
        private EmployeeTrainingPassedDAC _EmployeeTrainingPassedDAC;
        public EmployeeTrainingPassedProvider()
        {
            _EmployeeTrainingPassedDAC = new EmployeeTrainingPassedDAC();
        }
        public int Add(EmployeeTrainingPassedEntity Current)
        {
            General _General = new General();
            Current.DateCourse = _General.ShamsiToMiladi(Current.DateCourseStr);

            EmployeeTrainingPassed _EmployeeTrainingPassed = new EmployeeTrainingPassed(Current.Employemeid, Current.TrainingCourseId,
                Current.TableTypeOfTrainingId, Current.TrainingVenueId, Current.Duration, Current.DateCourse, Current.CertificateState);
            return _EmployeeTrainingPassedDAC.Add(_EmployeeTrainingPassed);
        }
        public bool Delete(int ID)
        {
            return _EmployeeTrainingPassedDAC.Delete(ID);
        }
        public bool Edit(EmployeeTrainingPassedEntity Current)
        {
            General _General = new General();
            EmployeeTrainingPassed _EmployeeTrainingPassed = new EmployeeTrainingPassed();
            _EmployeeTrainingPassed.EmployeeTrainingPassedId = Current.EmployeeTrainingPassedId;
            _EmployeeTrainingPassed.TimeLastModified = DateTime.Now;
            _EmployeeTrainingPassed.Employemeid = Current.Employemeid;
            _EmployeeTrainingPassed.TrainingCourseId = Current.TrainingCourseId;
            _EmployeeTrainingPassed.TableTypeOfTrainingId = Current.TableTypeOfTrainingId;
            _EmployeeTrainingPassed.TrainingVenueId = Current.TrainingVenueId;
            _EmployeeTrainingPassed.Duration = Current.Duration;
            _EmployeeTrainingPassed.DateCourse = _General.ShamsiToMiladi(Current.DateCourseStr);
            _EmployeeTrainingPassed.CertificateState = Current.CertificateState;
            return _EmployeeTrainingPassedDAC.Edit(_EmployeeTrainingPassed);
        }
        public EmployeeTrainingPassedEntity Get(int ID)
        {
            EmployeeTrainingPassedEntity _EmployeeTrainingPassedEntity = new EmployeeTrainingPassedEntity();
            var q = _EmployeeTrainingPassedDAC.Get(ID);

            _EmployeeTrainingPassedEntity.CertificateState = q.CertificateState;
            _EmployeeTrainingPassedEntity.DateCourse = q.DateCourse;
            _EmployeeTrainingPassedEntity.Duration = q.Duration;
            _EmployeeTrainingPassedEntity.EmployeeTrainingPassedId = q.EmployeeTrainingPassedId;
            _EmployeeTrainingPassedEntity.Employemeid = q.Employemeid;
            _EmployeeTrainingPassedEntity.TableTypeOfTrainingId = q.TableTypeOfTrainingId;
            _EmployeeTrainingPassedEntity.TrainingCourseId = q.TrainingCourseId;
            _EmployeeTrainingPassedEntity.TrainingVenueId = q.TrainingVenueId;
            return _EmployeeTrainingPassedEntity;

            // return (EmployeeTrainingPassedEntity)_EmployeeTrainingPassedDAC.Get(ID);
        }
        public IQueryable<EmployeeTrainingPassedEntity> GetAll()
        {
            return (IQueryable<EmployeeTrainingPassedEntity>)_EmployeeTrainingPassedDAC.GetAll();
        }
        public IQueryable<EmployeeTrainingPassedEntity> GetAll(int ID)
        {
            return _EmployeeTrainingPassedDAC.GetAll(ID);
        }
        public Double SumDuration(int employemeid)
        {
            return _EmployeeTrainingPassedDAC.SumDuration(employemeid);
        }
        public IQueryable<EmployeeTrainingPassedEntity> GetDetailPlacementTabJobTrainingemployeme(int employemeid)
        {
            return _EmployeeTrainingPassedDAC.GetDetailPlacementTabJobTrainingemployeme(employemeid);
        }

        public IQueryable<EmployeeTrainingPassedEntity> GetListEmployeeTrainingPassedSearch(EmployeeTrainingPassedReportSearch employeetrainingpassedreportsearch)
        {
            return _EmployeeTrainingPassedDAC.GetListEmployeeTrainingPassedSearch(employeetrainingpassedreportsearch);
        }
        public IQueryable<EmployeeTrainingPassedEntity> GetAllEmployeeTrainingPassed(int ID)
        {
            return _EmployeeTrainingPassedDAC.GetAllEmployeeTrainingPassed();
        }
        
    }
}
