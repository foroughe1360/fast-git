using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class TestsCollectionProvider : ITestsCollectionProvider
    {
        private TestsCollectionDAC _TestsCollectionDAC;
        public TestsCollectionProvider()
        {
            _TestsCollectionDAC = new TestsCollectionDAC();
        }
        public int Add(TestsCollectionEntity Current)
        {
            TestsCollection _TestsCollection = new TestsCollection(Current.CollectionId,Current.TestsCollectionName,Current.State);
            return _TestsCollectionDAC.Add(_TestsCollection);
        }
        public bool Delete(int ID)
        {
            return _TestsCollectionDAC.Delete(ID);
        }
        public bool Edit(TestsCollectionEntity Current)
        {
            TestsCollection _TestsCollection = new TestsCollection();
            _TestsCollection.TestsCollectionId = Current.TestsCollectionId;
            _TestsCollection.TimeLastModified = DateTime.Now;
            _TestsCollection.CollectionId = Current.CollectionId;
            _TestsCollection.TestsCollectionName = Current.TestsCollectionName;
            _TestsCollection.State = Current.State;
            return _TestsCollectionDAC.Edit(_TestsCollection);
        }
        public TestsCollectionEntity Get(int ID)
        {
            TestsCollectionEntity _TestsCollectionEntity = new TestsCollectionEntity();
            var q = _TestsCollectionDAC.Get(ID);
            _TestsCollectionEntity.CollectionId = q.CollectionId;
            _TestsCollectionEntity.State = q.State;
            _TestsCollectionEntity.TestsCollectionId = q.TestsCollectionId;
            _TestsCollectionEntity.TestsCollectionName = q.TestsCollectionName;
            _TestsCollectionEntity.TimeCreated = q.TimeCreated;
            return _TestsCollectionEntity;
        }
        public IQueryable<TestsCollectionEntity> GetAll()
        {
            return _TestsCollectionDAC.GetAllTestsCollection();
        }
    }
}
