using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListEffectivenessOfCourse
    {
        public int ListEffectivenessOfCourseId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DesignTrainingCourseId { get; set; }
        public int EffectivenessOfCoursesId { get; set; }
        public bool Hidden { get; set; }

        public ListEffectivenessOfCourse()
        {

        }

        public ListEffectivenessOfCourse(int designtrainingcourseid,int effectivenessofcoursesid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DesignTrainingCourseId = designtrainingcourseid;
            EffectivenessOfCoursesId = effectivenessofcoursesid;
            Hidden = false;
        }
    }
}
