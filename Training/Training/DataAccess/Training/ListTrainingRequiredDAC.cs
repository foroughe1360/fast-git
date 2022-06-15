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
    public class ListTrainingRequiredDAC : IListTrainingRequiredRepository
    {
        public int Add(ListTrainingRequired Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListTrainingRequireds.Add(Current);
            db.SaveChanges();
            return Current.ListTrainingRequiredId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listTrainingRequired = new ListTrainingRequired() { ListTrainingRequiredId = ID, Hidden = true };
                db.ListTrainingRequireds.Attach(listTrainingRequired);
                db.Entry(listTrainingRequired).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(ListTrainingRequired Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListTrainingRequireds.Attach(Current);

                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.InventoryjobsId).IsModified = true;
                db.Entry(Current).Property(x => x.ListTrainingRequiredId).IsModified = true;
                db.Entry(Current).Property(x => x.TableTypeOfTrainingFaceId).IsModified = true;

                db.Entry(Current).Property(x => x.TitleTraining).IsModified = true;
                db.Entry(Current).Property(x => x.SDTime).IsModified = true;
                db.Entry(Current).Property(x => x.OJTTime).IsModified = true;
                db.Entry(Current).Property(x => x.CTime).IsModified = true;
                //db.Entry(Current).Property(x => x.TrainingRequiredId).IsModified = true;

                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
        public ListTrainingRequired Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListTrainingRequireds.SingleOrDefault(x => x.ListTrainingRequiredId == ID);
        }
        public IQueryable<ListTrainingRequired> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListTrainingRequireds select item;
        }
        public IQueryable<ListTrainingRequiredEntity> GetAll(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                 (
                 from listtrainingrequired in db.ListTrainingRequireds.Where(a => a.Hidden == false && a.InventoryjobsId==ID)
                 join inventoryjobs in db.Inventoryjobs on listtrainingrequired.InventoryjobsId equals inventoryjobs.InventoryjobId
                 join tabletypeoftrainingsface in db.TableTypeOfTrainings on listtrainingrequired.TableTypeOfTrainingFaceId equals tabletypeoftrainingsface.TableTypeOfTrainingId
                 select new ListTrainingRequiredEntity
                 {
                     Description = listtrainingrequired.Description,
                     InventoryjobsId = listtrainingrequired.InventoryjobsId,
                     ListTrainingRequiredId = listtrainingrequired.ListTrainingRequiredId,
                     TableTypeOfTrainingFaceId = listtrainingrequired.TableTypeOfTrainingFaceId,
                     SD = tabletypeoftrainingsface.Sd,
                     OJT = tabletypeoftrainingsface.Ojt,
                     C = tabletypeoftrainingsface.C,
                     TitleTraining =listtrainingrequired.TitleTraining,
                     SDTime = listtrainingrequired.SDTime,
                     OJTTime = listtrainingrequired.OJTTime,
                     CTime = listtrainingrequired.CTime
                 }
                 );
            return _query;
        }

    }
}
