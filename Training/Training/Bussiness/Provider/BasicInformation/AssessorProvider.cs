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
    public class AssessorProvider : IAssessorProvider
    {
        private AssessorDAC _AssessorDAC;
        public AssessorProvider()
        {
            _AssessorDAC = new AssessorDAC();
        }
        public int Add(AssessorEntity Current)
        {
            Assessor _Assessor = new Assessor(Current.UserId);
            return _AssessorDAC.Add(_Assessor);
        }
        public bool Delete(int ID)
        {
            return _AssessorDAC.Delete(ID);
        }
        public bool Edit(AssessorEntity Current)
        {
            Assessor _Assessor = new Assessor();
            _Assessor.AssessorId=Current.AssessorId;
            _Assessor.TimeLastModified = DateTime.Now;
            _Assessor.UserId=Current.UserId;
            return _AssessorDAC.Edit(_Assessor);
        }
        public AssessorEntity Get(int ID)
        {
            AssessorEntity _AssessorEntity = new AssessorEntity();
            var q = _AssessorDAC.Get(ID);
            _AssessorEntity.AssessorId = q.AssessorId;
            _AssessorEntity.UserId = q.UserId;
            return _AssessorEntity;
            // return (AssessorEntity)_AssessorDAC.Get(ID);
        }
        public IQueryable<AssessorEntity> GetAll()
        {
            return _AssessorDAC.GetAllAssessor();
        }
    }
}
