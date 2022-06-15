using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListStyleCourse
    {
        public int ListStyleCourseId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DesignTrainingCourseId { get; set; }
        public int StyleCoursesId { get; set; }
        public bool Hidden { get; set; }

        public ListStyleCourse()
        {
            
        }

        public ListStyleCourse(int designtrainingcourseid,int stylecoursesid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DesignTrainingCourseId = designtrainingcourseid;
            StyleCoursesId = stylecoursesid;
            Hidden = false;
        }
    }
}
