using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
   public class FinancialCommitmentEntity : FinancialCommitment
    {
        public string EmployemesName { get; set; }
        public string TrainingCourseName { get; set; }
        public string TrainingVenueName { get; set; }
        public string FromDateStr { get; set; }
        public string ToDateStr { get; set; }
        public DateTime TookHold { get; set; }
        public string TookHoldStr { get; set; }
        public string AmountPiercedStr { get; set; }
        public bool CheckFinancialCommitment { get; set; }

        public bool ActivePostGroupName { get; set; }
        public bool State { get; set; }
        public string  NationalCode { get; set; }
        public int DesignTrainingCourseDateId { get; set; }

        public FinancialCommitmentEntity() { }
        public FinancialCommitmentEntity(int employemeid, int trainingcourseid, int trainingvenueid,Int64 amountpierced, int timeemployment,
            DateTime fromdate,DateTime todate,int financialyear)
            :base (employemeid, trainingcourseid,  trainingvenueid,amountpierced,  timeemployment,fromdate,todate , financialyear)
        {
            
        }
    }
}
