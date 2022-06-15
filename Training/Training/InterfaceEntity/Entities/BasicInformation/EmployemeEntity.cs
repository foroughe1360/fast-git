using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class EmployemeEntity: Employeme
    {
        public enum typesearch:int
        {
            SerachAll=1,
            SerachObject=2
        }
        //ebrahimi
        public string BirthDateShamsi { get; set; }
        public string DateOfEmployementShamsi { get; set; }
        public string EmployemeName { get; set; }
        public string BirthDateStr { get; set; }
        public string DateOfEmployementStr { get; set; }
        public int EducationId { get; set; }
        public int UnitSCenterId { get; set; }
        public int departmentId { get; set; }
        public string  NationalCode { get; set; } 

        public string Name { get; set; }
        public int PostGroupId { get; set; }

        public bool ActivePostGroupName { get; set; }
        public EmployemeEntity()
        {

        }

        public EmployemeEntity(string firstname, string lastname, string fathername, string placeofbirth,
            DateTime birthdate, string fieldofstudy, string idnumber, DateTime dateofemployement,int personnelcode, bool state , string nationalcode) :
            base(firstname,lastname,fathername,placeofbirth,birthdate,fieldofstudy,idnumber,dateofemployement,personnelcode,state , nationalcode)
        {
        }
    }
}
