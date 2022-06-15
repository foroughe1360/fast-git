using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;
using DomainModel.Models;
using InterfaceEntity.Search.Trianing;

namespace Bussiness
{
    public class PlacementTabJobTrainingProvider : IPlacementTabJobTrainingProvider
    {
        private PlacementTabJobTrainingDAC _PlacementTabJobTrainingDAC;

        public PlacementTabJobTrainingProvider()
        {
            _PlacementTabJobTrainingDAC = new PlacementTabJobTrainingDAC();
        }

        public int Add(PlacementTabJobTrainingEntity Current)
        {
            General _General = new General();
            PlacementTabJobTraining _PlacementTabJobTraining = new PlacementTabJobTraining
                (Current.PlacementTabJobTrainingDateId, Current.EmployemeId,Current.SectionId, Current.PostGroupId, 
                Current.DateStartPostGroupName,Current.PreviousJobs,Current.CorporateResponsibility);
            if (Current.PreviousJobs == null)
                _PlacementTabJobTraining.PreviousJobs = "";
            if (Current.DateStartPostGroupNameStr != null)
                 _PlacementTabJobTraining.DateStartPostGroupName = _General.ShamsiToMiladi(Current.DateStartPostGroupNameStr);
            return _PlacementTabJobTrainingDAC.Add(_PlacementTabJobTraining);
        }

        public bool Delete(int ID)
        {
            return _PlacementTabJobTrainingDAC.Delete(ID);
        }

        public bool Edit(PlacementTabJobTrainingEntity Current)
        {
            General _General = new General();
            PlacementTabJobTraining _PlacementTabJobTraining = new PlacementTabJobTraining();
            _PlacementTabJobTraining.PlacementTabJobTrainingId = Current.PlacementTabJobTrainingId;
            _PlacementTabJobTraining.TimeLastModified = DateTime.Now;
            _PlacementTabJobTraining.PlacementTabJobTrainingDateId = Current.PlacementTabJobTrainingDateId;
            _PlacementTabJobTraining.EmployemeId = Current.EmployemeId;
            _PlacementTabJobTraining.PostGroupId = Current.PostGroupId;
            _PlacementTabJobTraining.SectionId = Current.SectionId;
            _PlacementTabJobTraining.DateStartPostGroupName = _General.ShamsiToMiladi(Current.DateStartPostGroupNameStr);
            _PlacementTabJobTraining.PreviousJobs = Current.PreviousJobs;
            _PlacementTabJobTraining.CorporateResponsibility = Current.CorporateResponsibility;
            return _PlacementTabJobTrainingDAC.Edit(_PlacementTabJobTraining);
        }

        public PlacementTabJobTrainingEntity Get(int ID)
        {
           return _PlacementTabJobTrainingDAC.GetPlacementTabJobTraining(ID);
        }
        
        public IQueryable<PlacementTabJobTrainingEntity> GetAll()
        {
            return (IQueryable < PlacementTabJobTrainingEntity > )_PlacementTabJobTrainingDAC.GetAll();
        }

        public IQueryable<PlacementTabJobTrainingEntity> GetAll(int ID)
        {
            return _PlacementTabJobTrainingDAC.GetAllPlacementTabJobTraining(ID);
        }

        public IQueryable<PlacementTabJobTrainingEntity> GetAllPlacementTabJobTraining(int placementtabjobtrainingdateid)
        {
           return _PlacementTabJobTrainingDAC.GetAllPlacementTabJobTraining(placementtabjobtrainingdateid);
        }

        public IQueryable<PlacementTabJobTrainingEntity> GetAllPlacementTabJobTraining(int sourceid, int destinationid)
        {
            return _PlacementTabJobTrainingDAC.GetAllPlacementTabJobTraining(sourceid, destinationid);
        }

        public bool CopyDataPlacementTabJob(int ID)
        {
            return _PlacementTabJobTrainingDAC.CopyDataPlacementTabJob(ID);
        }

        public IQueryable<PlacementTabJobTrainingEntity> GetAll(PlacementTabJobTrainingSearch placementtabjobtrainingsearch, int ID)
        {
            return _PlacementTabJobTrainingDAC.GetAll(placementtabjobtrainingsearch, ID);
        }
    }
}
