using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
  public   class ListEmployeeEvaluationEntity : ListEmployeeEvaluation
    {
        public ListEmployeeEvaluationEntity() { }
        public ListEmployeeEvaluationEntity(int employemesid, int assessorsid, int assessortypeid, int ver, int employeeevaluationstate)
        {
            EmployemesId = employemesid;
            AssessorsId = assessorsid;
            AssessorTypeId = assessortypeid;
            Ver = ver;
            EmployeeEvaluationState = employeeevaluationstate;
        }
    }
}
