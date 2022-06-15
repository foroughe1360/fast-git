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
    public class ListLearningAssistToolDAC : IListLearningAssistToolRepository
    {
        public int Add(ListLearningAssistTool Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListLearningAssistTools.Add(Current);
            db.SaveChanges();
            return Current.ListLearningAssistToolId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listLearningAssistTools = new ListLearningAssistTool() { ListLearningAssistToolId = ID, Hidden = true };
                db.ListLearningAssistTools.Attach(listLearningAssistTools);
                db.Entry(listLearningAssistTools).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListLearningAssistTool Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListLearningAssistTools.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListLearningAssistTool Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListLearningAssistTools.SingleOrDefault(x => x.ListLearningAssistToolId == ID && x.Hidden==false);
        }

        public IQueryable<ListLearningAssistTool> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListLearningAssistTools select item;
        }

        public IQueryable<ListLearningAssistToolEntity> GetAllListLearningAssistTool(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.TableInterfaceId == 6)
                 join listlearningassisttools in db.ListLearningAssistTools.Where(a => a.Hidden == false && a.DesignTrainingCourseId == ID) on tableinterfacevalues.TableInterfaceValueId equals listlearningassisttools.LearningAssistToolId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new ListLearningAssistToolEntity
                 {
                    ListLearningAssistToolId=(temp.ListLearningAssistToolId == null?0: temp.ListLearningAssistToolId),
                    LearningAssistToolId = tableinterfacevalues.TableInterfaceValueId,
                    LearningAssistToolName = tableinterfacevalues.TableValue,
                    LearningAssistToolState=(temp == null ? false:true)
                });
            return _query;
        }

        public ListLearningAssistTool GetLearningAssistTool(int designtrainingcourseid, int learningassisttoolid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListLearningAssistTools.SingleOrDefault(x => x.DesignTrainingCourseId == designtrainingcourseid && x.LearningAssistToolId == learningassisttoolid && x.Hidden == false);
        }

        public ListLearningAssistTool GetDeleteLearningAssistTool(int designtrainingcourseid,int learningassisttoolid)
        {
            TrainingContext db = new TrainingContext();
            return db.ListLearningAssistTools.SingleOrDefault(x => x.DesignTrainingCourseId == designtrainingcourseid && x.LearningAssistToolId==learningassisttoolid && x.Hidden == true);
        }

        #region ListStyleCourseReport
        public IQueryable<ListLearningAssistToolEntity> GetListLearningAssistTool(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                    from listlearningassisttools in db.ListLearningAssistTools.Where(a => a.Hidden == false && a.DesignTrainingCourseId == ID)
                    select new ListLearningAssistToolEntity
                    {
                        LearningAssistToolId = listlearningassisttools.LearningAssistToolId
                    }
                );
        }

        #endregion
    }
}
