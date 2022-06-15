using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }
        public int EducationId { get; set; }
        public DateTime DateOfEmployement { get; set; }
        public string Email { get; set; }
        public bool Hidden { get; set; }
        public Teacher()
        {
            
        }

        public Teacher(string name,string family, int educationid, string mobile,DateTime dateofemployement, string email)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Name = name;
            Family = family;
            EducationId = educationid;
            Mobile = mobile;
            DateOfEmployement = dateofemployement;
            Email = email;
            Hidden = false;
        }
    }
}
