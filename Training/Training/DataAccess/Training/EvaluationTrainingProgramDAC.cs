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
    public class EvaluationTrainingProgramDAC : IEvaluationTrainingProgramRepository
    {
        public int Add(EvaluationTrainingProgram Current)
        {
            TrainingContext db = new TrainingContext();
            db.EvaluationTrainingPrograms.Add(Current);
            db.SaveChanges();
            return Current.EvaluationTrainingProgramId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            try
            {
                TrainingContext db = new TrainingContext();
                var evaluationTrainingProgram = new EvaluationTrainingProgram() { EvaluationTrainingProgramId = ID, Hidden = true };
                db.Entry(evaluationTrainingProgram).Property(x => x.Hidden).IsModified = true;
                db.EvaluationTrainingPrograms.Attach(evaluationTrainingProgram);
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(EvaluationTrainingProgram Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.EvaluationTrainingPrograms.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.ContentQuestionsId).IsModified = true;
                db.Entry(Current).Property(x => x.CourseRegistrationId).IsModified = true;
                db.Entry(Current).Property(x => x.DirectorEducationQuestionId).IsModified = true;
                db.Entry(Current).Property(x => x.EvaluationTrainingProgramId).IsModified = true;
                
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public EvaluationTrainingProgram Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.EvaluationTrainingPrograms.SingleOrDefault(x => x.EvaluationTrainingProgramId == ID);
        }

        public IQueryable<EvaluationTrainingProgram> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.EvaluationTrainingPrograms select item;
        }


        public IQueryable<EvaluationTrainingProgramEntity> GetAllEvaluationTrainingProgram(int ID)
        {
            TrainingContext db = new TrainingContext();
            var orderKeys1 = new int[] { 27, 28 };
            var orderKeys2 = new int[] { 27, 28 };

            var _query = (from t1 in db.TableInterfaceValues.Where(t => orderKeys1.Contains(t.TableInterfaceId))
                          join q1 in db.EvaluationTrainingPrograms.Where(a => a.Hidden == false && a.CourseRegistrationId == ID) on t1.TableInterfaceValueId equals q1.ContentQuestionsId
                          into Temp
                          from temp in Temp.DefaultIfEmpty()
                          select new
                          {
                              EvaluationTrainingProgramId = (temp.EvaluationTrainingProgramId == null ? 0 : temp.EvaluationTrainingProgramId),
                              CourseRegistrationId = (temp.CourseRegistrationId == null ? 0 : temp.CourseRegistrationId),
                              EvaluationTrainingProgramsName = t1.TableValue,
                              DirectorEducationQuestionId = (temp.DirectorEducationQuestionId == null ? 0 : temp.DirectorEducationQuestionId),
                              QuestionsID = t1.TableInterfaceId
                          })
                           .Union
                         (from t2 in db.TableInterfaceValues.Where(t => orderKeys2.Contains(t.TableInterfaceId))
                          join q2 in db.EvaluationTrainingPrograms.Where(a => a.Hidden == false && a.CourseRegistrationId == ID) on t2.TableInterfaceValueId equals q2.ScoreEducationIdForContentQuestionsId
                          into Temp
                          from temp in Temp.DefaultIfEmpty()

                          select new
                          {
                              EvaluationTrainingProgramId = (temp.EvaluationTrainingProgramId == null ? 0 : temp.EvaluationTrainingProgramId),
                              CourseRegistrationId = (temp.CourseRegistrationId == null ? 0 : temp.CourseRegistrationId),
                              EvaluationTrainingProgramsName = t2.TableValue,
                              DirectorEducationQuestionId = (temp.DirectorEducationQuestionId == null ? 0 : temp.DirectorEducationQuestionId),
                              QuestionsID = t2.TableInterfaceId
                          })
                          .Select(c => new EvaluationTrainingProgramEntity
                          {
                              EvaluationTrainingProgramId = c.EvaluationTrainingProgramId,
                              CourseRegistrationId = c.CourseRegistrationId,
                              DirectorEducationQuestionId = c.DirectorEducationQuestionId,
                              EvaluationTrainingProgramsName = c.EvaluationTrainingProgramsName,
                              QuestionsID = c.QuestionsID

                          }).OrderBy(d => d.QuestionsID);

            return _query;
        }



    }
}

