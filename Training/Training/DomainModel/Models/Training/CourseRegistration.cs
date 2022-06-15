using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class CourseRegistration
    {
        public int CourseRegistrationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int DesignTrainingCourseId { get; set; }
        public int EmployemeId { get; set; }
        public int EmployemeStateID { get; set; }
        public bool Hidden { get; set; }

        public CourseRegistration()
        {
        }

        public CourseRegistration(int designtrainingcourseid, int employemesid,int employemestateid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            DesignTrainingCourseId = designtrainingcourseid;
            EmployemeId = employemesid;
            EmployemeStateID = employemestateid;
            Hidden = false;

            
        }
    }
}
