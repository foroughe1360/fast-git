using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListResponsibilitiePower
    {
        public int ListResponsibilitiePowerId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int PostGroupId { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }

        public ListResponsibilitiePower()
        {

        }

        public ListResponsibilitiePower(int postgroupid,string description)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            PostGroupId = postgroupid;
            Description = description;
            Hidden = false;
        }
    }
}
