using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public bool Status { get; set; }
        public bool Hidden { get; set; }

        public Menu()
        {
            
        }

        public Menu(string name,int parent,bool status)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Name = name;
            Parent = parent;
            Status = status;
            Hidden = false;
        }
    }
}
