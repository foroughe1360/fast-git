using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public  class CompetencyTestingEntity : CompetencyTesting
    {
        public CompetencyTestingEntity() { }
        public CompetencyTestingEntity(int listqualificationofstaffid, int laboratorytestsid)
        {
            ListQualificationOfStaffId = listqualificationofstaffid;
            LaboratoryTestsId = laboratorytestsid;
        }
    }
}
