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
    public class EffectivenessTrainingDAC : IEffectivenessTrainingRepository
    {
        public int Add(EffectivenessTraining Current)
        {
            TrainingContext db = new TrainingContext();
            db.EffectivenessTrainings.Add(Current);
            db.SaveChanges();
            return Current.EffectivenessTrainingId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            try
            {
                TrainingContext db = new TrainingContext();
                var effectivenessTraining = new EffectivenessTraining () { EffectivenessTrainingId = ID, Hidden = true };
                db.Entry(effectivenessTraining).Property(x => x.Hidden).IsModified = true;
                db.EffectivenessTrainings.Attach(effectivenessTraining);
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(EffectivenessTraining Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.EffectivenessTrainings .Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public EffectivenessTraining Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.EffectivenessTrainings .SingleOrDefault(x => x.EffectivenessTrainingId == ID);
        }

        public IQueryable<EffectivenessTraining> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.EffectivenessTrainings  select item;
        }

        public IQueryable<EffectivenessTrainingEntity> GetAllEffectivenessTraining(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from effectivenesstrainings in db.EffectivenessTrainings.Where(a => a.Hidden == false && a.CourseRegistrationId == ID)
                 join courseregistrations in db.CourseRegistrations on effectivenesstrainings.CourseRegistrationId equals courseregistrations.CourseRegistrationId
                 join employemes in db.Employemes on courseregistrations.EmployemeId equals employemes.EmployemeId
                 join employemejobs in db.EmployemeJobs on employemes.EmployemeId equals employemejobs.EmployemeId
                 join postgroups in db.PostGroups.Where(a => a.PostGroupId == 3) on employemejobs.PostGroupId equals postgroups.PostGroupId
                 join tableInterfacevalues in db.TableInterfaceValues on postgroups.PostGroupId equals tableInterfacevalues.TableInterfaceValueId
                 // join supervisors in db.Supervisor

                 select new EffectivenessTrainingEntity()
                 {
                     EffectivenessTrainingId = effectivenesstrainings.EffectivenessTrainingId,
                     Correctiveaction = effectivenesstrainings.Correctiveaction,
                     CorrectiveactionDescription = effectivenesstrainings.CorrectiveactionDescription,
                     CourseRegistrationId = effectivenesstrainings.CourseRegistrationId,
                     EmployemeJobId = employemejobs.EmployemeJobId,
                     PostGroupId = employemejobs.PostGroupId,
                     PostGroupName = tableInterfacevalues.TableValue,
                     EffectivenessTrainingDate = effectivenesstrainings.EffectivenessTrainingDate,
                     // SupervisorId = effectivenesstrainings.SupervisorId,
                     SupervisorName = ""

                 });
            return _query;
        }


    }
}
