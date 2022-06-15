using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class RatingEvaluation
    {
        public int RatingEvaluationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int RatingEvaluationCoursesID { get; set; }
        public int Number { get; set; }
        public DateTime RatingEvaluationDate { get; set; }
        public bool Hidden { get; set; }

        public RatingEvaluation()
        {

        }

        public RatingEvaluation(int ratingevaluationcoursesid,int number,DateTime ratingevaluationdate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            RatingEvaluationCoursesID = ratingevaluationcoursesid;
            Number = number;
            RatingEvaluationDate = ratingevaluationdate;
            Hidden = false;
        }
    }
}
