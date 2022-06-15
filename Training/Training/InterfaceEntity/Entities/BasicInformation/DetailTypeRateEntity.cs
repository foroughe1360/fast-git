using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class DetailTypeRateEntity: DetailTypeRate
    {
        public string TypesRateName { get; set; }
        public DetailTypeRateEntity()
        {

        }

        public DetailTypeRateEntity(int typesrateid, int parent, string detailtypename, int numdetailtype):
            base(typesrateid, parent, detailtypename, numdetailtype)
        {
        }
    }
}
