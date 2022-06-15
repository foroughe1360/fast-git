using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Point
    {
        public int PointId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DetailTypeRateId { get; set; }
        public string PointName { get; set; }
        public int NumPoint { get; set; }
        public bool Hidden { get; set; }

        public Point()
        {
            
        }

        public Point(int detailtyperateid,string pointname,int numpoint)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DetailTypeRateId = detailtyperateid;
            PointName = pointname;
            NumPoint = numpoint;
            Hidden = false;
        }
    }
}
