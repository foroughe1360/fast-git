using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class CodingTrainingPage
    {
        public int CodingTrainingPageId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Title { get; set; }
        public int TrainingPageCode { get; set; }
        public bool Hidden { get; set; }
        public CodingTrainingPage()
        {

        }

        public CodingTrainingPage(string title,int trainingpagecode)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Title = title;
            TrainingPageCode = trainingpagecode;
            Hidden = false;
        }
    }
}
