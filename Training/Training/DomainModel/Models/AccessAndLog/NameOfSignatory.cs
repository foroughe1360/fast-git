using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class NameOfSignatory
    {
        public int NameOfSignatoryId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int SideSignatoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime NameOfSignatoryDate { get; set; }
        public bool State { get; set; }
        public bool Hidden { get; set; }

        public NameOfSignatory()
        {

        }

        public NameOfSignatory(int sidesignatoryid, string firstname, string lastname, DateTime nameofsignatorydate, bool state)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            SideSignatoryId = sidesignatoryid;
            FirstName = firstname;
            LastName = lastname;
            NameOfSignatoryDate = nameofsignatorydate;
            State = state;
            Hidden = false;
        }
    }
}
