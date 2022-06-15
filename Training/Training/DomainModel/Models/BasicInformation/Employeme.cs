using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Employeme
    {
        public int EmployemeId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime BirthDate { get; set; }
        public string FieldOfStudy { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfEmployement { get; set; }
        public int PersonnelCode { get; set; }
        public string   NationalCode { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }


        // Navigation properties 
        //public ICollection<HardwareInformation> ICollectionHardwareInformation { get; set; }


        public Employeme()
        {

        }

        public Employeme(string firstname,string lastname,string fathername,string placeofbirth,
            DateTime birthdate,string fieldofstudy,string idnumber,DateTime dateofemployement,int personnelcode,bool state , string nationalcode)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            FirstName = firstname;
            LastName = lastname;
            FatherName = fathername;
            PlaceOfBirth = placeofbirth;
            BirthDate = birthdate;
            FieldOfStudy = fieldofstudy;
            IDNumber = idnumber;
            DateOfEmployement = dateofemployement;
            PersonnelCode = personnelcode;
            NationalCode = nationalcode;
            State = state;
            Hidden = false;
        }
    }
}
