using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;

namespace DataAccess
{
    public class TableTypeOfTrainingDAC : ITableTypeOfTrainingRepository
    {
        public int Add(TableTypeOfTraining Current)
        {
            TrainingContext db = new TrainingContext();
            db.TableTypeOfTrainings.Add(Current);
            db.SaveChanges();
            return Current.TableTypeOfTrainingId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var tabletypeoftraining = new TableTypeOfTraining() { TableTypeOfTrainingId = ID, Hidden = true };
                db.TableTypeOfTrainings.Attach(tabletypeoftraining);
                db.Entry(tabletypeoftraining).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TableTypeOfTraining Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TableTypeOfTrainings.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.C).IsModified = true;
                db.Entry(Current).Property(x => x.Ojt).IsModified = true;
                db.Entry(Current).Property(x => x.Sd).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TableTypeOfTraining Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TableTypeOfTrainings.SingleOrDefault(x => x.TableTypeOfTrainingId == ID);
        }

        public IQueryable<TableTypeOfTraining> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TableTypeOfTrainings select item;
        }
    }
}
