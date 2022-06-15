using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class SideSignatory
    {
        public int SideSignatoryId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Title { get; set; }
        public string TitleEN { get; set; }
        public int SideSignatoryCode { get; set; }
        public bool Hidden { get; set; }
        public SideSignatory()
        {

        }

        public SideSignatory(string title,string titleen,int sidesignatorycode)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Title = title;
            TitleEN = titleen;
            SideSignatoryCode = sidesignatorycode;
            Hidden = false;
        }
    }
}
