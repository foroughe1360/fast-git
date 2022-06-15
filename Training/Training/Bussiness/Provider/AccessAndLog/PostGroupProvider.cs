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
    public class PostGroupProvider : IPostGroupProvider
    {
        private PostGroupDAC _PostGroupDAC;
        public PostGroupProvider()
        {
            _PostGroupDAC = new PostGroupDAC();
        }
        public int Add(PostGroupEntity Current)
        {
            PostGroup _PostGroup = new PostGroup(Current.CollectionId, Current.PostTypeId, Current.State);
            return _PostGroupDAC.Add(_PostGroup);
        }
        public bool Delete(int ID)
        {
            return _PostGroupDAC.Delete(ID);
        }
        public bool Edit(PostGroupEntity Current)
        {
            PostGroup _PostGroup = new PostGroup();
            _PostGroup.PostGroupId = Current.PostGroupId;
            _PostGroup.TimeLastModified = DateTime.Now;
            _PostGroup.CollectionId = Current.CollectionId;
            _PostGroup.PostTypeId = Current.PostTypeId;
            _PostGroup.State = Current.State;
            return _PostGroupDAC.Edit(_PostGroup);
        }
        public PostGroupEntity Get(int ID)
        {
            PostGroupEntity _PostGroupEntity = new PostGroupEntity();
            var q = _PostGroupDAC.Get(ID);
            _PostGroupEntity.PostGroupId = q.PostGroupId;
            _PostGroupEntity.PostTypeId = q.PostTypeId;
            _PostGroupEntity.CollectionId = q.CollectionId;
            _PostGroupEntity.PostTypeId = q.PostTypeId;
            _PostGroupEntity.State = q.State;
            return _PostGroupEntity;
        }
        public IQueryable<PostGroupEntity> GetAll()
        {
            return _PostGroupDAC.GetAllPostGroup();
        }
    }
}
