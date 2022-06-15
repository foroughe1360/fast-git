using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel;

namespace Bussiness
{
    public class CodingTrainingPageProvider : ICodingTrainingPageProvider
    {
        private CodingTrainingPageDAC _CodingTrainingPageDAC;
        public CodingTrainingPageProvider()
        {
            _CodingTrainingPageDAC = new CodingTrainingPageDAC();
        }
        public int Add(CodingTrainingPageEntity Current)
        {
            CodingTrainingPage _CodingTrainingPage = new CodingTrainingPage(Current.Title,Current.TrainingPageCode);
            return _CodingTrainingPageDAC.Add(_CodingTrainingPage);
        }

        public bool Delete(int ID)
        {
            return _CodingTrainingPageDAC.Delete(ID);
        }

        public bool Edit(CodingTrainingPageEntity Current)
        {
            CodingTrainingPage _CodingTrainingPage = new CodingTrainingPage();
            _CodingTrainingPage.CodingTrainingPageId = Current.CodingTrainingPageId;
            _CodingTrainingPage.TimeLastModified = DateTime.Now;
            _CodingTrainingPage.Title = Current.Title;
            _CodingTrainingPage.TrainingPageCode = Current.TrainingPageCode;
            return _CodingTrainingPageDAC.Edit(_CodingTrainingPage);
        }

        public CodingTrainingPageEntity Get(int ID)
        {
            CodingTrainingPageEntity _CodingTrainingPageEntity = new CodingTrainingPageEntity();
            var q = _CodingTrainingPageDAC.Get(ID);
            _CodingTrainingPageEntity.CodingTrainingPageId = q.CodingTrainingPageId;
            _CodingTrainingPageEntity.Title = q.Title;
            _CodingTrainingPageEntity.TrainingPageCode = q.TrainingPageCode;
            return _CodingTrainingPageEntity;
        }

        public IQueryable<CodingTrainingPageEntity> GetAll()
        {
            var query = _CodingTrainingPageDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new CodingTrainingPageEntity()
                 {
                     CodingTrainingPageId = q.CodingTrainingPageId,
                     Title = q.Title,
                     TrainingPageCode = q.TrainingPageCode
                 });
            return _query;
        }
    }
}
