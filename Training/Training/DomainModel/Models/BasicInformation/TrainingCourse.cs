using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TrainingCourse
    {
        public int TrainingCourseId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string CourseName { get; set; }
        public int CourseTypeId { get; set; }
        public bool Hidden { get; set; }

        public TrainingCourse()
        {
             
        }

        public TrainingCourse(string coursname,int coursetypeid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            CourseName = coursname;
            CourseTypeId = coursetypeid;
            Hidden = false;
        }
    }
}
