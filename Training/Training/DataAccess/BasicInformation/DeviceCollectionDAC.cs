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
    public class DeviceCollectionDAC : IDeviceCollectionRepository
    {
        public int Add(DeviceCollection Current)
        {
            TrainingContext db = new TrainingContext();
            db.DeviceCollections.Add(Current);
            db.SaveChanges();
            return Current.DeviceCollectionId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var devicecollection = new DeviceCollection() { DeviceCollectionId = ID, Hidden = true };
                db.DeviceCollections.Attach(devicecollection);
                db.Entry(devicecollection).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(DeviceCollection Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DeviceCollections.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.CollectionsId).IsModified = true;
                db.Entry(Current).Property(x => x.JobDeviceCollection).IsModified = true;
                db.Entry(Current).Property(x => x.State).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public DeviceCollection Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DeviceCollections.SingleOrDefault(x => x.DeviceCollectionId == ID);
        }

        public IQueryable<DeviceCollection> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DeviceCollections select item;
        }

        public IQueryable<DeviceCollectionEntity> GetAllDeviceCollection()
        {
            TrainingContext db = new TrainingContext();
            return
                (from devicecollections in db.DeviceCollections.Where(a => a.Hidden==false)
                 join tableinterfacevalues in db.TableInterfaceValues on devicecollections.CollectionsId equals tableinterfacevalues.TableInterfaceValueId
                 select new DeviceCollectionEntity
                 {
                     CollectionsId = devicecollections.CollectionsId,
                     DeviceCollectionId = devicecollections.DeviceCollectionId,
                     JobDeviceCollection = devicecollections.JobDeviceCollection,
                     State = devicecollections.State,
                     collectionName = tableinterfacevalues.TableValue
                 });
        }
    }
}
