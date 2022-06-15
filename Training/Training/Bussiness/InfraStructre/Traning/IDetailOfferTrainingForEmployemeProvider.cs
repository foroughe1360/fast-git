using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.InfraStructre
{
    interface IDetailOfferTrainingForEmployemeProvider : IBaseProvider<DetailOfferTrainingForEmployemeEntity, int>
    {
        IQueryable<DetailOfferTrainingForEmployemeEntity> GetAll(int ID);
        IQueryable<DetailOfferTrainingForEmployemeReport> GetDetailOfferTrainingForEmployemeReport(int ID);
    }
}
