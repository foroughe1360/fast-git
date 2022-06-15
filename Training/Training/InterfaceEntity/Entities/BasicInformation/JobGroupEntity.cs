using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class JobGroupEntity: JobGroup
    {
        public JobGroupEntity()
        {

        }

        public JobGroupEntity(string jobgroupname, int ponitjobgroup, int groupnumber):base(jobgroupname, ponitjobgroup, groupnumber)
        {
        }
    }
}
