using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;

namespace DataAccess
{
    public class TestsCollectionDAC : ITestsCollectionRepository
    {
        public int Add(TestsCollection Current)
        {
            TrainingContext db = new TrainingContext();
            db.TestsCollections.Add(Current);
            db.SaveChanges();
            return Current.TestsCollectionId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var testscollection = new TestsCollection() { TestsCollectionId = ID, Hidden = true };
                db.TestsCollections.Attach(testscollection);
                db.Entry(testscollection).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(TestsCollection Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.TestsCollections.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.CollectionId).IsModified = true;
                db.Entry(Current).Property(x => x.TestsCollectionName).IsModified = true;
                db.Entry(Current).Property(x => x.State).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public TestsCollection Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.TestsCollections.SingleOrDefault(x => x.TestsCollectionId == ID);
        }

        public IQueryable<TestsCollection> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.TestsCollections select item;
        }

        public IQueryable<TestsCollectionEntity> GetAllTestsCollection()
        {
            TrainingContext db = new TrainingContext();
            return
                (from testscollections in db.TestsCollections.Where(a => a.Hidden==false)
                 join tableinterfacevalues in db.TableInterfaceValues on testscollections.CollectionId equals tableinterfacevalues.TableInterfaceValueId
                 select new TestsCollectionEntity
                 {
                     CollectionId = testscollections.CollectionId,
                     State = testscollections.State,
                     TestsCollectionId = testscollections.TestsCollectionId,
                     TestsCollectionName = testscollections.TestsCollectionName,
                     TimeCreated = testscollections.TimeCreated,
                     CollectionName = tableinterfacevalues.TableValue
                 });
        }
    }
}
