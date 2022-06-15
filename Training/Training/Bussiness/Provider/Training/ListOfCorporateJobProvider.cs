using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DomainModel.Models;
using DataAccess;

namespace Bussiness
{
    public class ListOfCorporateJobProvider : IListOfCorporateJobProvider
    {
        private ListOfCorporateJobDAC _ListOfCorporateJobDAC;

        public ListOfCorporateJobProvider()
        {
            _ListOfCorporateJobDAC = new ListOfCorporateJobDAC();
        }

        public int Add(ListOfCorporateJobEntity Current)
        {
            ListOfCorporateJob _ListOfCorporateJob = new ListOfCorporateJob(Current.ListOfCorporateJobDateId,Current.CollectionId,Current.PostTypeId, Current.NumberOfPeopleEmployed, Current.Description, Current.Year);
            return _ListOfCorporateJobDAC.Add(_ListOfCorporateJob);
        }

        public bool Delete(int ID)
        {
            return _ListOfCorporateJobDAC.Delete(ID);
        }

        public bool Edit(ListOfCorporateJobEntity Current)
        {
            General _General = new General();
            ListOfCorporateJob _ListOfCorporateJob = new ListOfCorporateJob();
            _ListOfCorporateJob.ListOfCorporateJobId = Current.ListOfCorporateJobId;
            _ListOfCorporateJob.TimeLastModified = DateTime.Now;
            _ListOfCorporateJob.ListOfCorporateJobDateId = Current.ListOfCorporateJobDateId;
            _ListOfCorporateJob.CollectionId = Current.CollectionId;
            _ListOfCorporateJob.PostTypeId = Current.PostTypeId;
            _ListOfCorporateJob.NumberOfPeopleEmployed = Current.NumberOfPeopleEmployed;
            _ListOfCorporateJob.Description = Current.Description;
            _ListOfCorporateJob.Year = Current.Year;
            return _ListOfCorporateJobDAC.Edit(_ListOfCorporateJob);
        }

        public ListOfCorporateJobEntity Get(int ID)
        {
            ListOfCorporateJobEntity _ListOfCorporateJobEntity = new ListOfCorporateJobEntity();
            var q = _ListOfCorporateJobDAC.Get(ID);
            _ListOfCorporateJobEntity.ListOfCorporateJobId = q.ListOfCorporateJobId;
            _ListOfCorporateJobEntity.ListOfCorporateJobDateId = q.ListOfCorporateJobDateId;
            _ListOfCorporateJobEntity.CollectionId = q.CollectionId;
            _ListOfCorporateJobEntity.PostTypeId = q.PostTypeId;
            _ListOfCorporateJobEntity.NumberOfPeopleEmployed = q.NumberOfPeopleEmployed;
            _ListOfCorporateJobEntity.Description = q.Description;
            _ListOfCorporateJobEntity.Year = q.Year;
            return _ListOfCorporateJobEntity;
        }

        public IQueryable<ListOfCorporateJobEntity> GetAll()
        {
            return (IQueryable < ListOfCorporateJobEntity > )_ListOfCorporateJobDAC.GetAll();
        }

        public IQueryable<ListOfCorporateJobEntity> GetAll(int ID)
        {
            return _ListOfCorporateJobDAC.GetAllListOfCorporateJob(ID);
        }

        public IQueryable<ListOfCorporateJobReport> GetAllReport(int ID)
        {
            var list = _ListOfCorporateJobDAC.GetAllListOfCorporateJob(ID);
            return
                (from q in list
                 select new ListOfCorporateJobReport
                 {
                    collectionposttypeName = q.collectionName+" "+q.posttypeName,
                    Description=q.Description,
                    NumberOfPeopleEmployed=q.NumberOfPeopleEmployed
                 });
        }

        public IQueryable<ListOfCorporateJobReport> GetCollectionReport(int ListOfCorporateJobDateId,int CollectionId)
        {
            var list = _ListOfCorporateJobDAC.GetCollectionListOfCorporateJob(ListOfCorporateJobDateId,CollectionId);
            return
                (from q in list
                 select new ListOfCorporateJobReport
                 {
                     collectionposttypeName = q.posttypeName + " " + q.collectionName,
                     Description = q.Description,
                     NumberOfPeopleEmployed = q.NumberOfPeopleEmployed
                 });
        }
    }
}
