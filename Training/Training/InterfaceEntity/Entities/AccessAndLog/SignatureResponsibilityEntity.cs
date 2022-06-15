using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace InterfaceEntity
{
    public class SignatureResponsibilityEntity: SignatureResponsibility
    {
        public string UserNameFamily { get; set; }
        public string signatureStr { get; set; }

        public string EmployemeNameFamily { get; set; }
        public SignatureResponsibilityEntity()
        {

        }

        public SignatureResponsibilityEntity(int userid , int employemeid, Byte[] signature):base(userid, employemeid, signature)
        {

        }
    }
}
