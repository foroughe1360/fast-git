using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class EducationEmployemeEntity : EducationEmployeme
    {
        public string EducationName { get; set; }
        public string DateOfGraduationStr { get; set; }

        public string TypeOfUniversityName { get; set; }


        public EducationEmployemeEntity()
        {

        }

        public EducationEmployemeEntity(int employemeid, int educationid, string fieldofstudy, string academicorientation,
            DateTime dateofgraduation, bool lasteducationalcertificate, int tabletypeofuniversityid, string nameofuniversity, bool activetypeofuniversity)
            : base(employemeid, educationid, fieldofstudy, academicorientation, dateofgraduation, lasteducationalcertificate, tabletypeofuniversityid, nameofuniversity, activetypeofuniversity)
        {

        }
    }
}
