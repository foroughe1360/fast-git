using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InfraStructre
{
    interface IUserRepository : IBaseRepository<User, int>
    {
    }
}
