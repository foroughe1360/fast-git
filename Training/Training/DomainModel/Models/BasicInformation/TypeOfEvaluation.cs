using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public partial class TypeOfEvaluation
    {
        public int TypeOfEvaluationId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Title { get; set; }
        public int MaxScore { get; set; }
        public bool Hidden { get; set; }

        public TypeOfEvaluation()
        {
            
        }

        public TypeOfEvaluation(string title,int maxscore)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Title = title;
            MaxScore = maxscore;
            Hidden = false;
        }
    }
}
