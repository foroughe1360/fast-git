using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;

namespace Bussiness.Provider
{
    public class DetailOfferTrainingForEmployemeProvider : IDetailOfferTrainingForEmployemeProvider
    {
        private DetailOfferTrainingForEmployemeDAC _DetailOfferTrainingForEmployemeDAC;

        public DetailOfferTrainingForEmployemeProvider()
        {
            _DetailOfferTrainingForEmployemeDAC = new DetailOfferTrainingForEmployemeDAC();
        }
        public int Add(DetailOfferTrainingForEmployemeEntity Current)
        {
            DetailOfferTrainingForEmployeme _DetailOfferTrainingForEmployeme = new DetailOfferTrainingForEmployeme(Current.OfferTrainingForEmployemesId, Current.NeedTraining, Current.PriorityId, Current.TableTypeOfTrainingOfferId, Current.TableTypeOfTrainingSetId);
            return _DetailOfferTrainingForEmployemeDAC.Add(_DetailOfferTrainingForEmployeme);
        }

        public bool Delete(int ID)
        {
            return _DetailOfferTrainingForEmployemeDAC.Delete(ID);
        }

        public bool Edit(DetailOfferTrainingForEmployemeEntity Current)
        {
            DetailOfferTrainingForEmployeme _DetailOfferTrainingForEmployeme = new DetailOfferTrainingForEmployeme();
            _DetailOfferTrainingForEmployeme.DetailOfferTrainingForEmployemeId = Current.DetailOfferTrainingForEmployemeId;
            _DetailOfferTrainingForEmployeme.TimeLastModified = DateTime.Now;
            _DetailOfferTrainingForEmployeme.NeedTraining = Current.NeedTraining;
            _DetailOfferTrainingForEmployeme.OfferTrainingForEmployemesId = Current.OfferTrainingForEmployemesId;
            _DetailOfferTrainingForEmployeme.PriorityId = Current.PriorityId;
            _DetailOfferTrainingForEmployeme.TableTypeOfTrainingOfferId = Current.TableTypeOfTrainingOfferId;
            _DetailOfferTrainingForEmployeme.TableTypeOfTrainingSetId = Current.TableTypeOfTrainingSetId;

            return _DetailOfferTrainingForEmployemeDAC.Edit(_DetailOfferTrainingForEmployeme);
        }

        public DetailOfferTrainingForEmployemeEntity Get(int ID)
        {
            DetailOfferTrainingForEmployemeEntity _DetailOfferTrainingForEmployemeEntity = new DetailOfferTrainingForEmployemeEntity();
            var q = _DetailOfferTrainingForEmployemeDAC.Get(ID);
            _DetailOfferTrainingForEmployemeEntity.DetailOfferTrainingForEmployemeId = q.DetailOfferTrainingForEmployemeId;
            _DetailOfferTrainingForEmployemeEntity.NeedTraining = q.NeedTraining;
            _DetailOfferTrainingForEmployemeEntity.OfferTrainingForEmployemesId = q.OfferTrainingForEmployemesId;
            _DetailOfferTrainingForEmployemeEntity.PriorityId = q.PriorityId;
            _DetailOfferTrainingForEmployemeEntity.TableTypeOfTrainingOfferId = q.TableTypeOfTrainingOfferId;
            _DetailOfferTrainingForEmployemeEntity.TableTypeOfTrainingSetId = q.TableTypeOfTrainingSetId;
            return _DetailOfferTrainingForEmployemeEntity;
        }

        public IQueryable<DetailOfferTrainingForEmployemeEntity> GetAll()
        {
            return (IQueryable<DetailOfferTrainingForEmployemeEntity>)_DetailOfferTrainingForEmployemeDAC.GetAll();
        }

        public IQueryable<DetailOfferTrainingForEmployemeEntity> GetAll(int ID)
        {
            return _DetailOfferTrainingForEmployemeDAC.GetAllDetailOfferTrainingForEmployeme(ID);
        }

        public IQueryable<DetailOfferTrainingForEmployemeReport> GetDetailOfferTrainingForEmployemeReport(int ID)
        {
            return _DetailOfferTrainingForEmployemeDAC.GetDetailOfferTrainingForEmployemeReport(ID);

        }
    }
}
