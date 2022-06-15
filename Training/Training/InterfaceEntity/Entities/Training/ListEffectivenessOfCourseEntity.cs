using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class ListEffectivenessOfCourseEntity : ListEffectivenessOfCourse
    {

        public string CourseName { get; set; }
        public int TrainingCourseId { get; set; }
        public string EffectivenessOfCoursesName { get; set; }
        public bool EffectivenessOfCoursesState { get; set; }
        public bool State { get; set; }

        public ListEffectivenessOfCourseEntity() { }
        public ListEffectivenessOfCourseEntity(int designtrainingcourseid, int effectivenessofcoursesid)
        {
            DesignTrainingCourseId = designtrainingcourseid;
            EffectivenessOfCoursesId = effectivenessofcoursesid;
        }
    }
}
