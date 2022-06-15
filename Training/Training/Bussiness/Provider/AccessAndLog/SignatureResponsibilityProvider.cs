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
    public class SignatureResponsibilityProvider : ISignatureResponsibilityProvider
    {
        private SignatureResponsibilityDAC _SignatureResponsibilityDAC;
        public SignatureResponsibilityProvider()
        {
            _SignatureResponsibilityDAC = new SignatureResponsibilityDAC();
        }
        public int Add(SignatureResponsibilityEntity Current)
        {
            SignatureResponsibility _SignatureResponsibility = new SignatureResponsibility(Current.UserId,Current.EmployemeId, Current.Signature);
            return _SignatureResponsibilityDAC.Add(_SignatureResponsibility);
        }

        public bool Delete(int ID)
        {
            return _SignatureResponsibilityDAC.Delete(ID);
        }

        public bool Edit(SignatureResponsibilityEntity Current)
        {
            SignatureResponsibility _SignatureResponsibility = new SignatureResponsibility();
            _SignatureResponsibility.SignatureResponsibilityId = Current.SignatureResponsibilityId;
            _SignatureResponsibility.TimeLastModified = DateTime.Now;
            _SignatureResponsibility.UserId = Current.UserId;
            _SignatureResponsibility.EmployemeId = Current.EmployemeId;
            
            _SignatureResponsibility.Signature = Current.Signature;
            return _SignatureResponsibilityDAC.Edit(_SignatureResponsibility);
        }

        public SignatureResponsibilityEntity Get(int ID)
        {
            SignatureResponsibilityEntity _SignatureResponsibilityEntity = new SignatureResponsibilityEntity();
            var q = _SignatureResponsibilityDAC.Get(ID);
            _SignatureResponsibilityEntity.SignatureResponsibilityId = q.SignatureResponsibilityId;
            _SignatureResponsibilityEntity.UserId = q.UserId;
            _SignatureResponsibilityEntity.EmployemeId = q.EmployemeId;
            _SignatureResponsibilityEntity.Signature = q.Signature;
            _SignatureResponsibilityEntity.signatureStr= Encoding.ASCII.GetString(q.Signature);
            return _SignatureResponsibilityEntity;
        }

        public IQueryable<SignatureResponsibilityEntity> GetAll()
        {
            return _SignatureResponsibilityDAC.GetAllSignatureResponsibility();
        }
        

    }
}
