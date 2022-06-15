using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class ListEmployeeEvaluation
    {
        public int ListEmployeeEvaluationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int EmployemesId { get; set; }
        public int AssessorsId { get; set; }
        public int AssessorTypeId { get; set; }
        public int Ver { get; set; }
        public int EmployeeEvaluationState { get; set; }
        public bool Hidden { get; set; }

        public ListEmployeeEvaluation()
        {
            
        }

        public ListEmployeeEvaluation(int employemesid,int assessorsid,int assessortypeid,int ver,int employeeevaluationstate)
        {
            EmployemesId = employemesid;
            AssessorsId = assessorsid;
            AssessorTypeId = assessortypeid;
            Ver = ver;
            EmployeeEvaluationState = employeeevaluationstate;
        }
    }
}
