using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TeacherLevelDateEntity: TeacherLevelDate
    {
        public string LevelDateStr { get; set; }
        public int TeacherLevelDateListId { get; set; }

        public TeacherLevelDateEntity()
        {

        }

        public TeacherLevelDateEntity(string description,DateTime leveldate) :base(description, leveldate)
        {

        }
    }
}
