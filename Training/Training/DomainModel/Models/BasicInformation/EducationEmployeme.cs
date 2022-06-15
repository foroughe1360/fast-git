using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class EducationEmployeme
    {
        public int EducationEmployemeId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int EmployemeId { get; set; }
        public int EducationId { get; set; } 
        public string FieldOfStudy { get; set; } 
        public string AcademicOrientation { get; set; }
        public DateTime DateOfGraduation { get; set; }
        public bool LastEducationalCertificate { get; set; }

        public int TableTypeOfUniversityId { get; set; }
        public string NameOfUniversity { get; set; }
        public bool ActiveTypeOfUniversity { get; set; }

        public bool Hidden { get; set; }

        public EducationEmployeme()
        {

        }

        public EducationEmployeme(int employemeid,int educationid,string fieldofstudy,string academicorientation,DateTime dateofgraduation,
            bool lasteducationalcertificate , int tabletypeofuniversityid ,string nameofuniversity,bool activetypeofuniversity)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            EmployemeId = employemeid;
            EducationId = educationid;
            FieldOfStudy = fieldofstudy;
            AcademicOrientation = academicorientation;
            DateOfGraduation = dateofgraduation;
            LastEducationalCertificate = lasteducationalcertificate;
            TableTypeOfUniversityId = tabletypeofuniversityid;
            NameOfUniversity = nameofuniversity;
            ActiveTypeOfUniversity = activetypeofuniversity;
            Hidden = false;
        }
    }
}
