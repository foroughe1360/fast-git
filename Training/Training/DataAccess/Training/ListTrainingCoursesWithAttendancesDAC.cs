using DataAccess.InfraStructre;
using DataAccess.InfraStructre.Training;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DataAccess.Training
{
    public class ListTrainingCoursesWithAttendancesDAC
    {

        public ListTrainingCoursesWithAttendancesDAC()
        {

        }

        public List<ListTrainingCoursesWithAttendancesEntity> GetAllListTrainingCoursesWithAttendances(TrainingCoursesWithAttendancesSearch trainingcourseswithattendancessearch)
        {
            TrainingContext db = new TrainingContext();

            var query = db.Database.SqlQuery<ListTrainingCoursesWithAttendancesEntity>(
            "ListTrainingCoursesWithAttendancesSearch @FromDate, @LastDate",
            new System.Data.SqlClient.SqlParameter("FromDate", trainingcourseswithattendancessearch.FromDatePer),
            new System.Data.SqlClient.SqlParameter("LastDate", trainingcourseswithattendancessearch.ToDatePer)
            ).ToList();
            return query;
        }



    }
}
