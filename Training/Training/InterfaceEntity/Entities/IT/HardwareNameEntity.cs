using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class HardwareNameEntity : HardwareName
    {
        public HardwareNameEntity()
        {

        }

        public HardwareNameEntity(string hardwaretitle, bool State) :
            base(hardwaretitle, State)
        {
        }

    }
}
