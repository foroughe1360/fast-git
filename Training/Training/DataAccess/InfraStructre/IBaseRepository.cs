using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InfraStructre
{
    interface IBaseRepository<TModel, Tkey>
    {
        bool Delete(Tkey ID);
        Tkey Add(TModel Current);
        TModel Get(Tkey ID);
        IQueryable<TModel> GetAll();
        bool Edit(TModel Current);

    }
}
