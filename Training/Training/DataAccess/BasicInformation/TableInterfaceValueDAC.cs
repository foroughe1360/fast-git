using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;

namespace DataAccess
{
    public class TableInterfaceValueDAC : ITableInterfaceValueRepository
    {
        public int Add(TableInterfaceValue Current)
        {
            TrainingContext db = new TrainingContext();
            db.TableInterfaceValues.Add(Current);
            db.SaveChanges();
            return Current.TableInterfaceValueId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var tableinterfacevalue = new TableInterfaceValue() { TableInterfaceValueId = ID, Hidden = true };
                db.TableInterfaceValues.Attach(tableinterfacevalue);
                db.Entry(tableinterfacevalue).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TableInterfaceValue Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TableInterfaceValues.Attach(Current);
                db.Entry(Current).Property(x => x.TableInterfaceId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TableValue).IsModified = true;
                db.Entry(Current).Property(x => x.TableInterfaceValueCode).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TableInterfaceValue Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TableInterfaceValues.SingleOrDefault(x => x.TableInterfaceValueId == ID);
        }

        public IQueryable<TableInterfaceValue> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TableInterfaceValues select item;
        }

        public IQueryable<TableInterfaceValueEntity> GetAllTableInterfaceValue(int ID)
        {
            TrainingContext db = new TrainingContext();
            return (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.Hidden == false && a.TableInterfaceId == ID)
                    join tableinterfaces in db.TableInterfaces on tableinterfacevalues.TableInterfaceId equals tableinterfaces.TableInterfaceId
                    select new TableInterfaceValueEntity
                    {
                        TableInterfaceId = tableinterfacevalues.TableInterfaceId,
                        TableInterfaceValueId = tableinterfacevalues.TableInterfaceValueId,
                        TableValue = tableinterfacevalues.TableValue,
                        TableName = tableinterfaces.TableName,
                        TableNameFarsi = tableinterfaces.TableNameFarsi,
                        TableInterfaceValueCode = tableinterfacevalues.TableInterfaceValueCode
                    });
        }

        public IQueryable<TableInterfaceValueEntity> GetTableInterfaceValueDPD(int tableinterfacevalueid)
        {
            TrainingContext db = new TrainingContext();
            return (from tableinterfacevalues in db.TableInterfaceValues.Where(a => a.Hidden == false && a.TableInterfaceId==tableinterfacevalueid)
                    join tableinterfaces in db.TableInterfaces on tableinterfacevalues.TableInterfaceId equals tableinterfaces.TableInterfaceId
                    select new TableInterfaceValueEntity
                    {
                        TableInterfaceId = tableinterfacevalues.TableInterfaceId,
                        TableInterfaceValueId = tableinterfacevalues.TableInterfaceValueId,
                        TableValue = tableinterfacevalues.TableValue,
                        TableName = tableinterfaces.TableName,
                        TableInterfaceValueCode = tableinterfacevalues.TableInterfaceValueCode
                    });
        }
    }
}
