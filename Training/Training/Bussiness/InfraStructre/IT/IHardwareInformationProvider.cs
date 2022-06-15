using InterfaceEntity;
using InterfaceEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.InfraStructre
{
    interface IHardwareInformationProvider : IBaseProvider<HardwareInformationEntity, int>
    {
    }
}
