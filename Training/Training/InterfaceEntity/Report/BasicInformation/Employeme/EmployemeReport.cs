using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report
{
    public partial class EmployemeReport
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDateDatetime { get; set; }
        public string BirthDate { get; set; }
        public string FatherName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string IDNumber { get; set; }
        public string EducationName { get; set; }
        public string FieldOfStudy { get; set; }
        public string AcademicOrientation { get; set; }
        public DateTime DateOfEmployementDateTime { get; set; }
        public string DateOfEmployement { get; set; }
        public string PostGroupName { get; set; }
        public string UnitSCenterName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string NationalCode { get; set; }

        public string DateOfApproverStr { get; set; }
        public string DateOfProducerStr { get; set; }
        public string DateOfRegistrarStr { get; set; }


        public EmployemeReport()
        {

        }
    }
}
