using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Search.Trianing
{
   public class TrainingCoursesWithAttendancesSearch
    {
        public string FromDatePer{ get; set; }
        public string ToDatePer { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
