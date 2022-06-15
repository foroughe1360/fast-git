using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class HardwareInformationEntity : HardwareInformation
    {
        public int UnitSCenterId { get; set; }
        public int SectionId { get; set; }
        public int PostGroupId { get; set; }
        public int DepartmentId { get; set; }
        public int PostTypeId { get; set; }
        public int CollectionId { get; set; }

        public string EmployemeName { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentModel { get; set; }
        public string PropertyNumber { get; set; }
        public string PostGroupName { get; set; }
        public string UnitSCenterName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string UnitDepartmentSection { get; set; }
        public string DeliveryDateStr { get; set; }
        public int EquipmentNameId { get; set; }

        public HardwareInformationEntity()
        {

        }
        public HardwareInformationEntity(int employemeid, int hardwareequipmentid, string networkid, string networkip, DateTime deliverydate, string descriptions, bool state) :
            base(employemeid, hardwareequipmentid, networkid, networkip, deliverydate, descriptions, state)
        {
        }
    }
}
