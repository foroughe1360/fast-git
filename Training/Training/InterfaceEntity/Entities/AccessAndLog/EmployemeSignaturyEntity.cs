using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class EmployemeSignaturyEntity : EmployemeSignatury
    {
        public string EmployemesName { get; set; }
        public string EmployemeSignaturyDatestr { get; set; }
        public string Specifications { get; set; }
        public int SideSignatoryCode { get; set; }
        public string StateStr { get; set; }
        public string signatureStr { get; set; }
        public Byte[] Signature { get; set; }

        public EmployemeSignaturyEntity()
        {
        }

        public EmployemeSignaturyEntity(int sidesignatoryid , int employemeid, DateTime employemesignaturydate, bool state)
            : base(sidesignatoryid, employemeid, employemesignaturydate, state)
        {

        }
    }
}
