using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class ListTrainingRequiredEntity : ListTrainingRequired
    {
        public bool SD { get; set; }
        public bool OJT { get; set; }
        public bool C { get; set; }

        public string TrainingRequiredName { get; set; }
        public ListTrainingRequiredEntity() { }
        public ListTrainingRequiredEntity(int inventoryjobsid, string description, int tabletypeOftrainingfaceId,string titletraining, int sdtime,int ojttime ,int ctime)
            : base(inventoryjobsid,  description, tabletypeOftrainingfaceId,titletraining,  sdtime,  ojttime,  ctime)
        {
        }
    }
}
