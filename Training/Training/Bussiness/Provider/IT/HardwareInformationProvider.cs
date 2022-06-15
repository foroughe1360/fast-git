using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Entities;
using InterfaceEntity.Search.IT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Provider
{
    public class HardwareInformationProvider : IHardwareInformationProvider
    {
        private HardwareInformationDAC _HardwareInformationDAC;
        private General _General;
        public HardwareInformationProvider()
        {
            _HardwareInformationDAC = new HardwareInformationDAC();
        }

        public int Add(HardwareInformationEntity Current)
        {
            General _General = new General();
            Current.DeliveryDate = _General.ShamsiToMiladi(Current.DeliveryDate);
            HardwareInformation _HardwareInformation = new HardwareInformation(Current.EmployemeId, Current.HardwareEquipmentId, Current.NetworkID, Current.NetworkIP, Current.DeliveryDate, Current.Descriptions, Current.State);
            return _HardwareInformationDAC.Add(_HardwareInformation);
        }

        public bool Delete(int ID)
        {
            return _HardwareInformationDAC.Delete(ID);
        }

        public bool Edit(HardwareInformationEntity Current)
        {
            General _General = new General();
            HardwareInformation _HardwareInformation = new HardwareInformation();
            _HardwareInformation.HardwareInformationId = Current.HardwareInformationId;
            _HardwareInformation.TimeLastModified = DateTime.Now;
            _HardwareInformation.EmployemeId = Current.EmployemeId;
            _HardwareInformation.HardwareEquipmentId = Current.HardwareEquipmentId;
            _HardwareInformation.NetworkIP = Current.NetworkIP;
            _HardwareInformation.NetworkID = Current.NetworkID;
            //_HardwareInformation.PropertyNumber = Current.PropertyNumber;
            _HardwareInformation.DeliveryDate = Current.DeliveryDate;
            _HardwareInformation.Descriptions = Current.Descriptions;
            _HardwareInformation.State = Current.State;
            return _HardwareInformationDAC.Edit(_HardwareInformation);
        }

        public HardwareInformationEntity Get(int ID)
        {
            HardwareInformationEntity _HardwareInformationEntity = new HardwareInformationEntity();
            return   _HardwareInformationDAC.GetAllHardwareInformation(ID);
            
        }
        public IQueryable<HardwareInformationEntity> GetAll()
        {
            var query = _HardwareInformationDAC.GetAllHardwareInformation();
            return query;
        }

        public IQueryable<HardwareInformationEntity> GetAll(HardwareInformationSearch HardwareInformationsearch)
        {
            return _HardwareInformationDAC.GetAllHardwareInformationModel(HardwareInformationsearch);
        }
    }

}
