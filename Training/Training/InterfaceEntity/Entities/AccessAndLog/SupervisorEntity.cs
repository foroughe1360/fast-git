using DomainModel.Models.AccessAndLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{ 
    public class SupervisorEntity : Supervisor
    {
        public string Department { get; set; }
        public string Employeme { get; set; }
        public string PostType { get; set; }
        public string EmployemePostType { get; set; }

        public SupervisorEntity()
        {

        }

        public SupervisorEntity(int departmentid, int employemeid, int posttypeid, bool state)
            :base(departmentid, employemeid,posttypeid, state)
        {

        }
    }
}
