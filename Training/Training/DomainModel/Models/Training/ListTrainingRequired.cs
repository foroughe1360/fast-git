using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListTrainingRequired
    {
        public int ListTrainingRequiredId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int InventoryjobsId { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public int TableTypeOfTrainingFaceId { get; set; }
        public string TitleTraining { get; set; }
        public int SDTime { get; set; }
        public int OJTTime { get; set; }
        public int CTime { get; set; }

        public ListTrainingRequired()
        {

        }

        public ListTrainingRequired(int inventoryjobsid,string description, int tabletypeOftrainingfaceId,string titletraining, 
                                            int sdtime,int ojttime,int ctime)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            InventoryjobsId = inventoryjobsid;
            Description = description;
            TableTypeOfTrainingFaceId = tabletypeOftrainingfaceId;
            TitleTraining = titletraining;
            SDTime = sdtime;
            OJTTime = ojttime;
            CTime = ctime;
            Hidden = false;
        }
    }
}
