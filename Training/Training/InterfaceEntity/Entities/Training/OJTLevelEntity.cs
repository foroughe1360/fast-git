using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace InterfaceEntity
{
    public   class OJTLevelEntity : OJTLevel
    {
        public OJTLevelEntity() { }
        public OJTLevelEntity(int levelnumber, string description)
        {
            LevelNumber = levelnumber;
            Description = description;
        }
    }
}