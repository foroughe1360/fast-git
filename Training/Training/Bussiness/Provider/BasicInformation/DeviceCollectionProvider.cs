using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class DeviceCollectionProvider : IDeviceCollectionProvider
    {
        private DeviceCollectionDAC _DeviceCollectionDAC;
        public DeviceCollectionProvider()
        {
            _DeviceCollectionDAC = new DeviceCollectionDAC();
        }
        public int Add(DeviceCollectionEntity Current)
        {
            DeviceCollection _DeviceCollection = new DeviceCollection(Current.CollectionsId, Current.JobDeviceCollection, 
                                                                      Current.State);
            return _DeviceCollectionDAC.Add(_DeviceCollection);
        }

        public bool Delete(int ID)
        {
            return _DeviceCollectionDAC.Delete(ID);
        }

        public bool Edit(DeviceCollectionEntity Current)
        {
            DeviceCollection _DeviceCollection = new DeviceCollection();
            _DeviceCollection.DeviceCollectionId = Current.DeviceCollectionId;
            _DeviceCollection.TimeLastModified= DateTime.Now;
            _DeviceCollection.CollectionsId = Current.CollectionsId;
            _DeviceCollection.JobDeviceCollection = Current.JobDeviceCollection;
            _DeviceCollection.State = Current.State;
            return _DeviceCollectionDAC.Edit(_DeviceCollection);
        }

        public DeviceCollectionEntity Get(int ID)
        {
            DeviceCollectionEntity _DeviceCollectionEntity = new DeviceCollectionEntity();
            var q = _DeviceCollectionDAC.Get(ID);
            _DeviceCollectionEntity.CollectionsId = q.CollectionsId;
            _DeviceCollectionEntity.DeviceCollectionId = q.DeviceCollectionId;
            _DeviceCollectionEntity.JobDeviceCollection = q.JobDeviceCollection;
            _DeviceCollectionEntity.State = q.State;
            return _DeviceCollectionEntity;

           // return (DeviceCollectionEntity)_DeviceCollectionDAC.Get(ID);
        }

        public IQueryable<DeviceCollectionEntity> GetAll()
        {
            return _DeviceCollectionDAC.GetAllDeviceCollection();
        }
    }
}
