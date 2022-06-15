using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Training;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;

namespace Bussiness.Provider.Training
{
    public class OfferTrainingForEmployemeProvider : IOfferTrainingForEmployemeProvider
    {

        private OfferTrainingForEmployemeDAC _OfferTrainingForEmployemeDAC;
        public OfferTrainingForEmployemeProvider()
        {
            _OfferTrainingForEmployemeDAC = new OfferTrainingForEmployemeDAC();
        }
        public int Add(OfferTrainingForEmployemeEntity Current)
        {
            General _General = new General();
            Current.DateNeeds = _General.ShamsiToMiladi(Current.DateNeeds);
            OfferTrainingForEmployeme _OfferTrainingForEmployeme = new OfferTrainingForEmployeme(Current.OfferTrainingForEmployeeDateId, Current.SectionId, Current.PostGroupId, Current.EmployemeId, Current.DateNeeds);
            return _OfferTrainingForEmployemeDAC.Add(_OfferTrainingForEmployeme);
        }

        public bool Delete(int ID)
        {
            return _OfferTrainingForEmployemeDAC.Delete(ID);
        }

        public bool Edit(OfferTrainingForEmployemeEntity Current)
        {
            General _General = new General();
            OfferTrainingForEmployeme _OfferTrainingForEmployeme = new OfferTrainingForEmployeme();
            _OfferTrainingForEmployeme.OfferTrainingForEmployemeId = Current.OfferTrainingForEmployemeId;
            _OfferTrainingForEmployeme.TimeLastModified = DateTime.Now;
            _OfferTrainingForEmployeme.SectionId = Current.SectionId;
            _OfferTrainingForEmployeme.PostGroupId = Current.PostGroupId;
            _OfferTrainingForEmployeme.EmployemeId = Current.EmployemeId;
            _OfferTrainingForEmployeme.DateNeeds = _General.ShamsiToMiladi(Current.DateNeeds);

            return _OfferTrainingForEmployemeDAC.Edit(_OfferTrainingForEmployeme);
        }

        public OfferTrainingForEmployemeEntity Get(int ID)
        {
            OfferTrainingForEmployemeEntity _OfferTrainingForEmployemeEntity = new OfferTrainingForEmployemeEntity();
            return _OfferTrainingForEmployemeDAC.GetOfferTrainingForEmployeme(ID);
        }

        public PostReportEmployeme GetPostReport(int ID)
        {
            return _OfferTrainingForEmployemeDAC.GetPostReport(ID);
        }
        public PostReportEmployeme GetPostReports(int ID)
        {
            return _OfferTrainingForEmployemeDAC.GetPostReports(ID);

        }

        public IQueryable<OfferTrainingForEmployemeEntity> GetAll()
        {
            return _OfferTrainingForEmployemeDAC.GetAllOfferTrainingForEmployeme();
        }

        public IQueryable<OfferTrainingForEmployemeEntity> GetAll(int ID)
        {
            return _OfferTrainingForEmployemeDAC.GetAllOfferTrainingForEmployeme(ID);
        }

        public IQueryable<OfferTrainingForEmployemeEntity> GetAll(DetailoffertrainingforemployemeSearch detailoffertrainingforemployemesearch)
        {
            return _OfferTrainingForEmployemeDAC.GetAll(detailoffertrainingforemployemesearch);
        }

    }
}
