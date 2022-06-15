using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DataAccess.InfraStructre
{
    interface IDepartmentRepository : IBaseRepository<Department, int>
    {
    }
}
