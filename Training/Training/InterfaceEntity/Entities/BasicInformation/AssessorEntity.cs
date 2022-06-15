using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class AssessorEntity: Assessor
    {
        public string UserName { get; set; }
        public AssessorEntity()
        {

        }

        public AssessorEntity(int userid):base(userid)
        {;
        }
    }
}
