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
    public class SignatureResponsibilityDAC : ISignatureResponsibilityRepository
    {
        public int Add(SignatureResponsibility Current)
        {
            TrainingContext db = new TrainingContext();
            db.SignatureResponsibilities.Add(Current);
            db.SaveChanges();
            return Current.UserId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var signatureresponsibility = new SignatureResponsibility() { SignatureResponsibilityId = ID, Hidden = true };
                db.SignatureResponsibilities.Attach(signatureresponsibility);
                db.Entry(signatureresponsibility).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(SignatureResponsibility Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.SignatureResponsibilities.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.UserId).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                
                if (Current.Signature!=null)
                    db.Entry(Current).Property(x => x.Signature).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public SignatureResponsibility Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.SignatureResponsibilities.SingleOrDefault(x => x.SignatureResponsibilityId == ID);
        }

        public IQueryable<SignatureResponsibility> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.SignatureResponsibilities select item;
        }

        public IQueryable<SignatureResponsibilityEntity> GetAllSignatureResponsibility()
        {
            TrainingContext db = new TrainingContext();
            return
                (from signatureresponsibilities in db.SignatureResponsibilities.Where(a => a.Hidden == false)
                 join users in db.Users on signatureresponsibilities.UserId equals users.UserId
                 join employemes in db.Employemes on signatureresponsibilities.EmployemeId equals employemes.EmployemeId
                 select new SignatureResponsibilityEntity
                 {
                     SignatureResponsibilityId = signatureresponsibilities.SignatureResponsibilityId,
                     UserId = signatureresponsibilities.UserId,
                     UserNameFamily = users.FirstName + " " + users.LastName,

                     EmployemeId = signatureresponsibilities.EmployemeId,
                     EmployemeNameFamily = employemes.FirstName + " " + employemes.LastName
                 });
        }    
    }
}
