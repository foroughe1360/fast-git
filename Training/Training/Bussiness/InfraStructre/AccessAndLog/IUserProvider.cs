﻿using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.InfraStructre
{
    interface IUserProvider : IBaseProvider<UserEntity,int>
    {
    }
}