using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class NameOfSignatoryEntity: NameOfSignatory
    {
        public string NameOfSignatoryDatestr { get; set; }
        public string Specifications { get; set; }
        public int SideSignatoryCode { get; set; }
        public string StateStr { get; set; }
        public NameOfSignatoryEntity()
        {

        }

        public NameOfSignatoryEntity(int sidesignatoryid, string firstname, string lastname, DateTime nameofsignatorydate, bool state)
            :base(sidesignatoryid,firstname,lastname,nameofsignatorydate,state)
        {

        }
    }
}
