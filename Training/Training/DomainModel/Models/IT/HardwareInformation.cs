using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class HardwareInformation
    {
        public int HardwareInformationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }

        // Foreign key
        public int EmployemeId { get; set; }
        // Foreign key
        public int HardwareEquipmentId { get; set; }
        
        public string NetworkID { get; set; }
        public string NetworkIP { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Descriptions { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        // Navigation properties 
        //public Employeme Employeme { get; set; }
        //public HardwareEquipment HardwareEquipment { get; set; }

        public HardwareInformation()
        {

        }

        public HardwareInformation(int employemeid, int hardwareequipmentid, string networkid, string networkip, DateTime deliverydate, string descriptions, bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            EmployemeId = employemeid;
            HardwareEquipmentId = hardwareequipmentid;
            NetworkID = networkid;
            NetworkIP = networkip;
            DeliveryDate = deliverydate;
            Descriptions = descriptions;
            State = state;
            Hidden = false;
        }
    }
}
