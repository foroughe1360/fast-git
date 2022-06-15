using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class HardwareEquipment
    {
        public int HardwareEquipmentId { get; set; } 
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int EquipmentNameId { get; set; } 
        public string EquipmentModel { get; set; }
        public string PropertyNumber { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        // Navigation properties 
        //public ICollection<HardwareInformation> ICollectionHardwareInformation { get; set; }

        public HardwareEquipment()
        {

        }

        public HardwareEquipment(int equipmentnameid, string equipmentmodel, string propertynumber,bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            EquipmentNameId = equipmentnameid;
            EquipmentModel = equipmentmodel;
            PropertyNumber = propertynumber;
            State = state;
            Hidden = false;
        }
    }
}
