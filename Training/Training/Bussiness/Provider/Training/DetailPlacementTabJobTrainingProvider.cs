using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Report;

namespace Bussiness
{
    public class DetailPlacementTabJobTrainingProvider : IDetailPlacementTabJobTrainingProvider
    {
        private DetailPlacementTabJobTrainingDAC _DetailPlacementTabJobTrainingDAC;

        public DetailPlacementTabJobTrainingProvider()
        {
            _DetailPlacementTabJobTrainingDAC = new DetailPlacementTabJobTrainingDAC();
        }


        public int Add(DetailPlacementTabJobTrainingEntity Current)
        {
            DetailPlacementTabJobTraining _DetailPlacementTabJobTraining = new DetailPlacementTabJobTraining(Current.PlacementTabJobTrainingId, Current.Title, Current.FinalComment, Current.NumberOfHours, Current.OJTLevelId);
            return _DetailPlacementTabJobTrainingDAC.Add(_DetailPlacementTabJobTraining);
        }

        public bool Delete(int ID)
        {
            return _DetailPlacementTabJobTrainingDAC.Delete(ID);
        }

        public bool Edit(DetailPlacementTabJobTrainingEntity Current)
        {
            DetailPlacementTabJobTraining _DetailPlacementTabJobTraining = new DetailPlacementTabJobTraining();
            _DetailPlacementTabJobTraining.DetailPlacementTabJobTrainingId = Current.DetailPlacementTabJobTrainingId;
            _DetailPlacementTabJobTraining.TimeLastModified = DateTime.Now;
            _DetailPlacementTabJobTraining.PlacementTabJobTrainingId = Current.PlacementTabJobTrainingId;
            _DetailPlacementTabJobTraining.Title = Current.Title;
            _DetailPlacementTabJobTraining.FinalComment = Current.FinalComment;
            _DetailPlacementTabJobTraining.NumberOfHours = Current.NumberOfHours;
            _DetailPlacementTabJobTraining.OJTLevelId = Current.OJTLevelId;

            return _DetailPlacementTabJobTrainingDAC.Edit(_DetailPlacementTabJobTraining);
        }

        public DetailPlacementTabJobTrainingEntity Get(int ID)
        {
            DetailPlacementTabJobTrainingEntity _DetailPlacementTabJobTrainingEntity = new DetailPlacementTabJobTrainingEntity();
            var q = _DetailPlacementTabJobTrainingDAC.Get(ID);

            _DetailPlacementTabJobTrainingEntity.DetailPlacementTabJobTrainingId = q.DetailPlacementTabJobTrainingId;
            _DetailPlacementTabJobTrainingEntity.PlacementTabJobTrainingId = q.PlacementTabJobTrainingId;
            _DetailPlacementTabJobTrainingEntity.Title = q.Title;
            _DetailPlacementTabJobTrainingEntity.FinalComment = q.FinalComment;
            _DetailPlacementTabJobTrainingEntity.NumberOfHours = q.NumberOfHours;
            _DetailPlacementTabJobTrainingEntity.OJTLevelId = q.OJTLevelId;

            return _DetailPlacementTabJobTrainingEntity;
            //return (NoteAbsenceEntity)_NoteAbsenceDAC.Get(ID);
        }

        public IQueryable<DetailPlacementTabJobTrainingEntity> GetAll()
        {
            return (IQueryable<DetailPlacementTabJobTrainingEntity>)_DetailPlacementTabJobTrainingDAC.GetAll();
        }

        //IQueryable:
        public IQueryable<DetailPlacementTabJobTrainingEntity> GetAll(int ID)
        {
            //return (IQueryable<DetailPlacementTabJobTrainingEntity>)_DetailPlacementTabJobTrainingDAC.GetAll();
            return _DetailPlacementTabJobTrainingDAC.GetAllDetailPlacementTabJobTraining(ID);
        }

        public IQueryable<PlacementTabJobTrainingReport> GetAllDetailPlacementTabJobTrainingReport(int ID)
        {
            return _DetailPlacementTabJobTrainingDAC.GetAllDetailPlacementTabJobTrainingReport(ID);
        }

        public IQueryable<DetailPlacementTabJobTrainingEntity> GetAllDetailPlacementTabJobTraining(int sourceid, int destinationid)
        {
            return _DetailPlacementTabJobTrainingDAC.GetAllDetailPlacementTabJobTraining(sourceid, destinationid);
        }

        public IQueryable<EmployeeTrainingPassedReport> GetDetailPlacementTabJobTrainingemployeme(int employemeid)
        {
            return _DetailPlacementTabJobTrainingDAC.GetDetailPlacementTabJobTrainingemployeme(employemeid);
        }

    }
}
