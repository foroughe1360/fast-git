using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class HardwareEquipmentEntity : HardwareEquipment
    {
        public string EquipmentName { get; set; }
        
        public HardwareEquipmentEntity()
        {

        }

        public HardwareEquipmentEntity(int equipmentnameid, string equipmentmodel, string propertynumber, bool State) :
            base(equipmentnameid, equipmentmodel, propertynumber, State)
        {
        }

    }
}
