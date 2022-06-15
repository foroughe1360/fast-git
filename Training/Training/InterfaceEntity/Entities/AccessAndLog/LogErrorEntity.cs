using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class LogErrorEntity: LogError
    {
        public LogErrorEntity()
        {

        }

        public LogErrorEntity(int formid, string errormessage, int operationtypeid, string description)
            :base(formid,errormessage,operationtypeid,description)
        {

        }
    }
}
