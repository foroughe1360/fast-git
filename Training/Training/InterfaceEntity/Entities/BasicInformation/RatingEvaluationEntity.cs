using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class RatingEvaluationEntity: RatingEvaluation
    {
        public string ratingevaluationcourseName { get; set; }
        public string RatingEvaluationDateStr { get; set; }
        public RatingEvaluationEntity()
        {

        }

        public RatingEvaluationEntity(int ratingevaluationcoursesid, int number,DateTime ratingevaluationdate) 
            :base(ratingevaluationcoursesid, number, ratingevaluationdate)
        {

        }
    }
}
