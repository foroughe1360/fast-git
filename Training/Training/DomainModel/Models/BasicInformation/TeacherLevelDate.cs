using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TeacherLevelDate
    {
        public int TeacherLevelDateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Description { get; set; }
        public DateTime LevelDate { get; set; }
        public bool Hidden { get; set; }

        public TeacherLevelDate()
        {

        }

        public TeacherLevelDate(string description, DateTime leveldate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Description = description;
            LevelDate = leveldate;
            Hidden = false;
        }
    }
}
