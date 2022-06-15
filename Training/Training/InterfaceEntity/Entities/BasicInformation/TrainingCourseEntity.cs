using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TrainingCourseEntity : TrainingCourse
    {
        public string typesoftrainingName { get; set; }
        public string trainingvenueName { get; set; }

        public string CourseTypeName { get; set; }

        public TrainingCourseEntity()
        {
        }
        public TrainingCourseEntity(string coursname,int coursetypeid)
                                : base(coursname, coursetypeid)
        {

        }
    }
}
