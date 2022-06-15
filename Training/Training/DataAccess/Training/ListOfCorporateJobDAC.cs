using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class ListOfCorporateJobDAC : IListOfCorporateJob
    {
        public int Add(ListOfCorporateJob Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListOfCorporateJobs.Add(Current);
            db.SaveChanges();
            return Current.ListOfCorporateJobId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listofcorporatejob = new ListOfCorporateJob() { ListOfCorporateJobId = ID, Hidden = true };
                db.ListOfCorporateJobs.Attach(listofcorporatejob);
                db.Entry(listofcorporatejob).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListOfCorporateJob Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListOfCorporateJobs.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.CollectionId).IsModified = true;
                db.Entry(Current).Property(x => x.PostTypeId).IsModified = true;
                db.Entry(Current).Property(x => x.NumberOfPeopleEmployed).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListOfCorporateJob Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListOfCorporateJobs.SingleOrDefault(x => x.ListOfCorporateJobId == ID);
        }

        public IQueryable<ListOfCorporateJob> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListOfCorporateJobs select item;
        }

        public IQueryable<ListOfCorporateJobEntity> GetAllListOfCorporateJob(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from listofcorporatejobs in db.ListOfCorporateJobs.Where(a => a.Hidden==false && a.ListOfCorporateJobDateId==ID)
                 join tableinterfacevaluesPostTypeId in db.TableInterfaceValues on listofcorporatejobs.PostTypeId equals tableinterfacevaluesPostTypeId.TableInterfaceValueId
                 join tableinterfacevaluesCollectionId in db.TableInterfaceValues on listofcorporatejobs.CollectionId equals tableinterfacevaluesCollectionId.TableInterfaceValueId
                 orderby listofcorporatejobs.CollectionId
                 select new ListOfCorporateJobEntity
                 {
                     ListOfCorporateJobId=listofcorporatejobs.ListOfCorporateJobId,
                     ListOfCorporateJobDateId = listofcorporatejobs.ListOfCorporateJobDateId,
                     PostTypeId =listofcorporatejobs.PostTypeId,
                     collectionName= tableinterfacevaluesCollectionId.TableValue,
                     posttypeName = tableinterfacevaluesPostTypeId.TableValue,
                     NumberOfPeopleEmployed=listofcorporatejobs.NumberOfPeopleEmployed,
                     Description=listofcorporatejobs.Description,
                     Year=listofcorporatejobs.Year
                 });
        }

        public IQueryable<ListOfCorporateJobEntity> GetCollectionListOfCorporateJob(int ListOfCorporateJobDateId, int CollectionId)
        {
            TrainingContext db = new TrainingContext();
            return
                (from listofcorporatejobs in db.ListOfCorporateJobs.Where(a => a.Hidden == false && a.ListOfCorporateJobDateId == ListOfCorporateJobDateId && a.CollectionId== CollectionId)
                 join tableinterfacevaluesPostTypeId in db.TableInterfaceValues on listofcorporatejobs.PostTypeId equals tableinterfacevaluesPostTypeId.TableInterfaceValueId
                 join tableinterfacevaluesCollectionId in db.TableInterfaceValues on listofcorporatejobs.CollectionId equals tableinterfacevaluesCollectionId.TableInterfaceValueId
                 select new ListOfCorporateJobEntity
                 {
                     ListOfCorporateJobId = listofcorporatejobs.ListOfCorporateJobId,
                     ListOfCorporateJobDateId = listofcorporatejobs.ListOfCorporateJobDateId,
                     PostTypeId = listofcorporatejobs.PostTypeId,
                     collectionName = tableinterfacevaluesCollectionId.TableValue,
                     posttypeName = tableinterfacevaluesPostTypeId.TableValue,
                     NumberOfPeopleEmployed = listofcorporatejobs.NumberOfPeopleEmployed,
                     Description = listofcorporatejobs.Description,
                     Year = listofcorporatejobs.Year
                 });
        }
    }
}
