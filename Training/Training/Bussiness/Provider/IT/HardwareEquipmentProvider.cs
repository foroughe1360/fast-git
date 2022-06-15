using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.IT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class HardwareEquipmentProvider : IHardwareEquipmentProvider
    {
        private HardwareEquipmentDAC _HardwareEquipmentDAC;
        private General _General;
        public HardwareEquipmentProvider()
        {
            _HardwareEquipmentDAC = new HardwareEquipmentDAC();
        }

        public int Add(HardwareEquipmentEntity Current)
        {
            General _General = new General();
            HardwareEquipment _HardwareEquipment = new HardwareEquipment(Current.EquipmentNameId, Current.EquipmentModel, Current.PropertyNumber, Current.State);
            return _HardwareEquipmentDAC.Add(_HardwareEquipment);
        }

        public bool Delete(int ID)
        {
            return _HardwareEquipmentDAC.Delete(ID);
        }

        public bool Edit(HardwareEquipmentEntity Current)
        {
            General _General = new General();
            HardwareEquipment _HardwareEquipment = new HardwareEquipment();
            _HardwareEquipment.HardwareEquipmentId = Current.HardwareEquipmentId;
            _HardwareEquipment.TimeLastModified = DateTime.Now;
            _HardwareEquipment.EquipmentNameId = Current.EquipmentNameId;
            _HardwareEquipment.EquipmentModel = Current.EquipmentModel;
            _HardwareEquipment.PropertyNumber = Current.PropertyNumber;
            _HardwareEquipment.State = Current.State;
            return _HardwareEquipmentDAC.Edit(_HardwareEquipment);
        }

        public HardwareEquipmentEntity Get(int ID)
        {
            HardwareEquipmentEntity _HardwareEquipmentEntity = new HardwareEquipmentEntity();
            var q = _HardwareEquipmentDAC.Get(ID);
            _HardwareEquipmentEntity.HardwareEquipmentId = q.HardwareEquipmentId;
            _HardwareEquipmentEntity.EquipmentNameId = q.EquipmentNameId;
            _HardwareEquipmentEntity.EquipmentModel = q.EquipmentModel;
            _HardwareEquipmentEntity.PropertyNumber = q.PropertyNumber;
            _HardwareEquipmentEntity.State = q.State; 
            return _HardwareEquipmentEntity;
        }
        public IQueryable<HardwareEquipmentEntity> GetAll()
        {
            var query = _HardwareEquipmentDAC.GetAllHardwareEquipment();

            var _query = from q in query
                         select new HardwareEquipmentEntity()
                         {
                             HardwareEquipmentId = q.HardwareEquipmentId,
                             EquipmentNameId = q.EquipmentNameId,
                             EquipmentName = q.EquipmentName,
                             EquipmentModel = q.EquipmentModel,
                             PropertyNumber = q.PropertyNumber,
                             State = q.State,
                         };
            return _query;
        }

        public IQueryable<HardwareEquipmentEntity> GetAll(HardwareEquipmentSearch hardwareequipmentsearch)
        {
            return _HardwareEquipmentDAC.GetAllHardwareEquipmentModel(hardwareequipmentsearch);
        }

        public IQueryable<HardwareEquipmentEntity> GetAllEquipmentModel(int hardwareequipmentid)
        {
            var query = _HardwareEquipmentDAC.GetAllEquipmentModel(hardwareequipmentid);
            return query;
        }

    }

}

