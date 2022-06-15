using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class OfferTrainingForEmployemeEntity : OfferTrainingForEmployeme
    {

        public string SectionName { get; set; }

        public int PostTypeId { get; set; }
        public int CollectionId { get; set; }
        public string PostTypeName { get; set; }
        public string CollectionName { get; set; }
        public string PostGroupName { get; set; }
        public int UnitSCenterId { get; set; }
        public string UnitSCenterName { get; set; }
        public int DepartmentId { get; set; }                                   
        public string DepartmentName { get; set; }
        public string EmployemeName { get; set; }
        public string NeedTraining { get; set; }
        public OfferTrainingForEmployemeEntity()
        {

        }

        public OfferTrainingForEmployemeEntity(int offertrainingforemployeedateid, int sectionid, int postgroupId, int employemeid, DateTime dateneeds)
               : base(offertrainingforemployeedateid, sectionid, postgroupId, employemeid, dateneeds)
        {
        }


    }
}
