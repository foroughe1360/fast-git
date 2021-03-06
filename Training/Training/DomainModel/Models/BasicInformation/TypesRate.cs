using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TypesRate
    {
        public int TypesRateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string RateName { get; set; }
        public int NumberRate { get; set; }
        public bool Hidden { get; set; }

        public TypesRate()
        {
            
        }

        public TypesRate(string ratename,int numberrate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            RateName = ratename;
            NumberRate = numberrate;
            Hidden = false;
        }
    }
}
