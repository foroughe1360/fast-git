using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TypeOfEvaluationEntity: TypeOfEvaluation
    {
        public TypeOfEvaluationEntity()
        {

        }

        public TypeOfEvaluationEntity(string title, int maxscore)
        {
            Title = title;
            MaxScore = maxscore;
        }
    }
}
