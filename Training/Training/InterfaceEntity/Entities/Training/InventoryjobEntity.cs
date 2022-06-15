using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class InventoryjobEntity : Inventoryjob
    {
        public int UnitSCenterId { get; set; }
        public string UnitSCenterName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string EducationName { get; set; }
        public string CollectionName { get; set; }
        public string PostTypeName { get; set; }
        public InventoryjobEntity() { }


        public InventoryjobEntity(int sectionid, string postgroupname, int numberemployees, string asjobs2,
            string asjobs3, string education, string experience,
            int listresponsibilitiepowerid, string percentphysicalactivity, string percentmentalactivity, 
            string theoreticalknowledge, string qualified, string othertraining,
            string otherabilityrequiredjob, string listcommunityorganizationcomment)

            : base(sectionid, postgroupname, numberemployees, asjobs2, asjobs3, education, experience,
             listresponsibilitiepowerid, percentphysicalactivity, percentmentalactivity, theoreticalknowledge, 
             qualified, othertraining, otherabilityrequiredjob, listcommunityorganizationcomment)
        {
        }
    }
}
