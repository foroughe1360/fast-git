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
    public class CourseObjectivesEffectivenessTrainingDAC : ICourseObjectivesEffectivenessTrainingRepository
    {
        public int Add(CourseObjectivesEffectivenessTraining Current)
        {
            TrainingContext db = new TrainingContext();
            db.CourseObjectivesEffectivenessTrainings.Add(Current);
            db.SaveChanges();
            return Current.CourseObjectivesEffectivenessTrainingId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            try
            {
                TrainingContext db = new TrainingContext();
                var courseObjectivesEffectivenessTraining = new CourseObjectivesEffectivenessTraining() { CourseObjectivesEffectivenessTrainingId = ID, Hidden = true };
                db.Entry(courseObjectivesEffectivenessTraining).Property(x => x.Hidden).IsModified = true;
                db.CourseObjectivesEffectivenessTrainings.Attach(courseObjectivesEffectivenessTraining);
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(CourseObjectivesEffectivenessTraining Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.CourseObjectivesEffectivenessTrainings.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public CourseObjectivesEffectivenessTraining Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.CourseObjectivesEffectivenessTrainings.SingleOrDefault(x => x.CourseObjectivesEffectivenessTrainingId == ID);
        }

        public IQueryable<CourseObjectivesEffectivenessTraining> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.CourseObjectivesEffectivenessTrainings select item;
        }

        public IQueryable<CourseObjectivesEffectivenessTrainingEntity> GetAllCourseObjectivesEffectivenessTraining(int ID)
        {
            //TrainingContext db = new TrainingContext();
            //var _query = (from courseobjectiveseffectivenesstrainings in db.CourseObjectivesEffectivenessTrainings.Where(a => a.Hidden == false && a.EffectivenessTrainingId == ID)
            //              join effectivenesstraining in db.EffectivenessTrainings on courseobjectiveseffectivenesstrainings.EffectivenessTrainingId equals effectivenesstraining.EffectivenessTrainingId
            //              join tableinterfacevalues in db.TableInterfaceValues on courseobjectiveseffectivenesstrainings.CourseObjectiveId equals tableinterfacevalues.TableInterfaceValueId

            //              select new CourseObjectivesEffectivenessTrainingEntity
            //              {
            //                  EffectivenessTrainingId = courseobjectiveseffectivenesstrainings.EffectivenessTrainingId,
            //                  AmountAccessPurposeId = courseobjectiveseffectivenesstrainings.AmountAccessPurposeId,
            //                  CourseObjectiveId = courseobjectiveseffectivenesstrainings.CourseObjectiveId,
            //                  CourseObjectiveName = tableinterfacevalues.TableValue
            //              });
            //return _query;

            TrainingContext db = new TrainingContext();
            var orderKeys1 = new int[] { 30 };

            var _query = (from t1 in db.TableInterfaceValues.Where(t => orderKeys1.Contains(t.TableInterfaceId))
                          join q1 in db.CourseObjectivesEffectivenessTrainings.Where(a => a.Hidden == false && a.EffectivenessTrainingId == ID) on t1.TableInterfaceValueId equals q1.CourseObjectiveId
                          into Temp
                          from temp in Temp.DefaultIfEmpty()
                          select new
                          {
                              CourseObjectivesEffectivenessTrainingId = (temp.CourseObjectivesEffectivenessTrainingId == null ? 0 : temp.CourseObjectivesEffectivenessTrainingId),
                              EffectivenessTrainingId = (temp.EffectivenessTrainingId == null ? 0 : temp.EffectivenessTrainingId),
                              AmountAccessPurposeId = (temp.AmountAccessPurposeId == null ? 0 : temp.AmountAccessPurposeId),
                              CourseObjectiveName = t1.TableValue,
                              CourseObjectiveId = t1.TableInterfaceId
                          })
                        .Select(c => new CourseObjectivesEffectivenessTrainingEntity
                        {
                            CourseObjectivesEffectivenessTrainingId = c.CourseObjectivesEffectivenessTrainingId,
                            EffectivenessTrainingId = c.EffectivenessTrainingId,
                            AmountAccessPurposeId = c.AmountAccessPurposeId,
                            CourseObjectiveId = c.CourseObjectiveId,
                            CourseObjectiveName = c.CourseObjectiveName


                        }).OrderBy(d => d.CourseObjectiveId);

            return _query;
        }
    }
}
