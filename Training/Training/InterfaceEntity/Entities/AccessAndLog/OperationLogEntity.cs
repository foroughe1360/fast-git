using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class OperationLogEntity: OperationLog
    {
        public OperationLogEntity()
        {

        }

        public OperationLogEntity(int tableid, string description, int operationtypeid, int formid, int userid, string hostname, string usersystem,int recordid)
            :base(tableid,description,operationtypeid,formid,userid,hostname,usersystem,recordid)
        {
        }
    }
}
