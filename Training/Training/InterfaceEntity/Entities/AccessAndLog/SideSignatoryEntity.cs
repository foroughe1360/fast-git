using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class SideSignatoryEntity: SideSignatory
    {
        public SideSignatoryEntity()
        {

        }

        public SideSignatoryEntity(string title, string titleen, int sidesignatorycode) 
            :base(title,titleen,sidesignatorycode)
        {

        }
    }
}
