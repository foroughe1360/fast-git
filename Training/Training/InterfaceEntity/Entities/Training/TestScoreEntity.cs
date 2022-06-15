using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public class TestScoreEntity : TestScore
    {
        public string EmployemeName { get; set; }
        
        public TestScoreEntity() { }
        public TestScoreEntity(int listtypetestscoresid,int courseregistrationid, double score)
            :base(listtypetestscoresid, courseregistrationid, score)
        {
        }
    }
}
