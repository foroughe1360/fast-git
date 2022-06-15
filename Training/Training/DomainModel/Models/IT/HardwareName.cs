using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
   public class HardwareName
    {
        public int HardwareNameId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string HardwareTitle { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public HardwareName()
        {

        }


        public HardwareName(string hardwaretitle,  bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            HardwareTitle = hardwaretitle;
            State = state;
            Hidden = false;
        }
    }
   
}
