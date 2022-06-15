using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class CourseRegistrationEntity : CourseRegistration
    {
        public enum EmployemeState :int
        {
            PreRegistration=180,
            Register = 181,
            Dissuasion = 182,
            Deleted = 183
        }
        public string CourseName { get; set; }
        public int TrainingCourseId { get; set; }
        public string EmployemesName { get; set; }
        public string StyleCoursesName { get; set; }
        public string EmployemeStateName { get; set; }

        public CourseRegistrationEntity() { }
        public CourseRegistrationEntity(int designtrainingcourseid, int employemeid,int employemestateid)
            : base(designtrainingcourseid, employemeid, employemestateid)
        {
        }
    }
}
