using DataAccess.InfraStructre;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface ISideSignatoryRepository : IBaseRepository<SideSignatory, int>
    {
    }
}
