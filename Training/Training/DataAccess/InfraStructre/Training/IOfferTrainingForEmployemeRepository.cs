using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InfraStructre
{
    interface IOfferTrainingForEmployemeRepository : IBaseRepository<OfferTrainingForEmployeme, int>
    {
        OfferTrainingForEmployemeEntity GetOfferTrainingForEmployeme(int ID);
        PostReportEmployeme GetPostReport(int ID);
        IQueryable<OfferTrainingForEmployemeEntity> GetAllOfferTrainingForEmployeme();
        IQueryable<OfferTrainingForEmployemeEntity> GetAllOfferTrainingForEmployeme(int ID);

    }
}
