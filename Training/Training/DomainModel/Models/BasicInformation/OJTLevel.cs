using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OJTLevel
    {
        public int OJTLevelId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int LevelNumber { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public OJTLevel() { }
        public OJTLevel(int levelnumber, string description)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            LevelNumber = levelnumber;
            Description = description;
            Hidden = false;
        }
    }
}
