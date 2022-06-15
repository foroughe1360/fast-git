using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TypesRateEntity: TypesRate
    {
        public TypesRateEntity()
        {

        }

        public TypesRateEntity(string ratename, int numberrate)
        {
            RateName = ratename;
            NumberRate = numberrate;
        }
    }
}
