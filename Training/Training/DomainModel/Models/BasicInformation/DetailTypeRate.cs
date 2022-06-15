using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class DetailTypeRate
    {
        public int DetailTypeRateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TypesRateId { get; set; }
        public int Parent { get; set; }
        public string DetailTypeName { get; set; }
        public int NumDetailType { get; set; }
        public bool Hidden { get; set; }

        public DetailTypeRate()
        {
            
        }

        public DetailTypeRate(int typesrateid,int parent,string detailtypename,int numdetailtype)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TypesRateId = typesrateid;
            Parent = parent;
            DetailTypeName = detailtypename;
            NumDetailType = numdetailtype;
            Hidden = false;
        }
    }
}
