using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public  class ListStyleCourseEntity : ListStyleCourse
    {
        public string CourseName { get; set; }
        public int TrainingCourseId { get; set; }
        public string ListStyleCourseName { get; set; }
        public bool StyleCourseState { get; set; }
        public bool State { get; set; }

        public ListStyleCourseEntity() { }
        public ListStyleCourseEntity(int designtrainingcourseid, int stylecoursesid)
        {
            DesignTrainingCourseId = designtrainingcourseid;
            StyleCoursesId = stylecoursesid;
        }
    }
}
