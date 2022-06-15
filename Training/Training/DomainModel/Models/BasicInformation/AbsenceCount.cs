using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class AbsenceCount
    {
        public int AbsenceCountId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int MaxAbsenceCount { get; set; }
        public DateTime AbsenceCountDate { get; set; }
        public bool Hidden { get; set; }

        public AbsenceCount()
        {
                
        }

        public AbsenceCount(int maxabsencecount, DateTime absencecountdate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            MaxAbsenceCount = maxabsencecount;
            AbsenceCountDate = absencecountdate;
            Hidden = false;
        }
    }
}
