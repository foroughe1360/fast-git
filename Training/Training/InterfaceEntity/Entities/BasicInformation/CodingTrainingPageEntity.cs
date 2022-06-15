using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class CodingTrainingPageEntity : CodingTrainingPage
    {
        public CodingTrainingPageEntity()
        {

        }

        public CodingTrainingPageEntity(string title, int trainingpagecode):base (title,trainingpagecode)
        {

        }
    }
}
