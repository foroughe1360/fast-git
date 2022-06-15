using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class OfferTrainingForJobEntity : OfferTrainingForJob
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


        public OfferTrainingForJobEntity() { }
            
        public OfferTrainingForJobEntity(int offertrainingforjobdateid, int sectionid, int postgroupId, DateTime dateneeds) : base(offertrainingforjobdateid,sectionid, postgroupId, dateneeds)
        {
        }
    }
}
