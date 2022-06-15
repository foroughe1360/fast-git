using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TeacherEntity : Teacher
    {
        public string EducationName { get; set; }
        public string TeacherName { get; set; }
        public string DateOfEmployementStr { get; set; }
        public TeacherEntity()
        {

        }

        public TeacherEntity(string name,string family, int educationid,string mobile,DateTime dateofemployement,string email) 
            :base(name,family,educationid,mobile, dateofemployement,email)
        {
        }
    }
}
