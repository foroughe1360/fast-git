using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class TablesRelatedAssessmentOfTrainingServiceDAC : ITablesRelatedAssessmentOfTrainingServiceRepository
    {
        public int Add(TablesRelatedAssessmentOfTrainingService Current)
        {
            TrainingContext db = new TrainingContext();
            db.TablesRelatedAssessmentOfTrainingServices.Add(Current);
            db.SaveChanges();
            return Current.TablesRelatedAssessmentOfTrainingServiceId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var tablesRelatedAssessmentOfTrainingService = new TablesRelatedAssessmentOfTrainingService() { TablesRelatedAssessmentOfTrainingServiceId = ID, Hidden = true };
                db.TablesRelatedAssessmentOfTrainingServices.Attach(tablesRelatedAssessmentOfTrainingService);
                db.Entry(tablesRelatedAssessmentOfTrainingService).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TablesRelatedAssessmentOfTrainingService Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TablesRelatedAssessmentOfTrainingServices.Attach(Current);
                db.Entry(Current).Property(x => x.AssessmentOfTrainingServiceInformationId).IsModified = true;
                db.Entry(Current).Property(x => x.AssessmentOfTrainingServiceId).IsModified = true;
                db.Entry(Current).Property(x => x.Value).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TablesRelatedAssessmentOfTrainingService Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TablesRelatedAssessmentOfTrainingServices.SingleOrDefault(x => x.TablesRelatedAssessmentOfTrainingServiceId == ID);
        }

        public IQueryable<TablesRelatedAssessmentOfTrainingService> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return
                (
                    from tablesrelatedassessmentoftrainingservices in db.TablesRelatedAssessmentOfTrainingServices.Where(a => a.Hidden == false)
                    join assessmentoftrainingserviceinformations in db.AssessmentOfTrainingServiceInformations on tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceId equals assessmentoftrainingserviceinformations.AssessmentOfTrainingServiceInformationId
                    join assessmentoftrainingservices in db.AssessmentOfTrainingServices on tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceId equals assessmentoftrainingservices.AssessmentOfTrainingServiceId
                    select new TablesRelatedAssessmentOfTrainingServiceEntity
                    {
                        TablesRelatedAssessmentOfTrainingServiceId = tablesrelatedassessmentoftrainingservices.TablesRelatedAssessmentOfTrainingServiceId,
                        AssessmentOfTrainingServiceInformationId = tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceInformationId,
                        AssessmentOfTrainingServiceId = tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceId,
                        AOTSI = assessmentoftrainingserviceinformations.Name,
                        Value = tablesrelatedassessmentoftrainingservices.Value

                    });
        }

        public IQueryable<TablesRelatedAssessmentOfTrainingServiceEntity> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                    from tablesrelatedassessmentoftrainingservices in db.TablesRelatedAssessmentOfTrainingServices.Where(a => a.Hidden == false && a.AssessmentOfTrainingServiceId == ID)
                    join assessmentoftrainingserviceinformations in db.AssessmentOfTrainingServiceInformations on tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceInformationId equals assessmentoftrainingserviceinformations.AssessmentOfTrainingServiceInformationId
                    join assessmentoftrainingservices in db.AssessmentOfTrainingServices on tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceId equals assessmentoftrainingservices.AssessmentOfTrainingServiceId
                    select new TablesRelatedAssessmentOfTrainingServiceEntity
                    {
                        TablesRelatedAssessmentOfTrainingServiceId = tablesrelatedassessmentoftrainingservices.TablesRelatedAssessmentOfTrainingServiceId,
                        AssessmentOfTrainingServiceInformationId = tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceInformationId,
                        AssessmentOfTrainingServiceId = tablesrelatedassessmentoftrainingservices.AssessmentOfTrainingServiceId,
                        AOTSI = assessmentoftrainingserviceinformations.Name,
                        Value = tablesrelatedassessmentoftrainingservices.Value
                    });
        }
    }
}
