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
    public class TableInterfaceDAC : ITableInterfaceRepository
    {
        public int Add(TableInterface Current)
        {
            TrainingContext db = new TrainingContext();
            db.TableInterfaces.Add(Current);
            db.SaveChanges();
            return Current.TableInterfaceId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var tableinterface = new TableInterface() { TableInterfaceId = ID, Hidden = true };
                db.TableInterfaces.Attach(tableinterface);
                db.Entry(tableinterface).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TableInterface Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TableInterfaces.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TableName).IsModified = true;
                db.Entry(Current).Property(x => x.TableNameFarsi).IsModified = true;
                db.SaveChanges();
            }
            catch(Exception e)
            {
                e.Message.ToString();
                Success = false;
            }
            return Success;
        }

        public TableInterface Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TableInterfaces.SingleOrDefault(x => x.TableInterfaceId == ID);
        }

        public IQueryable<TableInterface> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TableInterfaces select item;
        }
    }
}
