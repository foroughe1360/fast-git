using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class MasterRateIt
    {
        public int MasterRateItId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int TypesRateItId { get; set; }
        public string Name { get; set; }
        public double MinRating { get; set; }
        public double MaxRating { get; set; }
        public int Parent { get; set; }
        public bool Hidden { get; set; }

        public MasterRateIt()
        {
             
        }

        public MasterRateIt(int typesrateitid,string name, double minrating, double maxrating, int parent)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            TypesRateItId = typesrateitid;
            Name = name;
            MinRating = minrating;
            MaxRating = maxrating;
            Parent = parent;
            Hidden = false;
        }
    }
}
