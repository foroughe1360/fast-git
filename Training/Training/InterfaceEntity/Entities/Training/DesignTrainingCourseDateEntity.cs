using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class DesignTrainingCourseDateEntity: DesignTrainingCourseDate
    {
        public string DTCDateStr { get; set; }
        public DesignTrainingCourseDateEntity()
        {

        }

        public DesignTrainingCourseDateEntity(string description, DateTime dtcdate,int financialyear) :base(description,dtcdate, financialyear)
        {

        }
    }
}
