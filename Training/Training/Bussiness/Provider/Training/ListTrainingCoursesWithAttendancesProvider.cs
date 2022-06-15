using DataAccess.Training;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Provider.Training
{
    public class ListTrainingCoursesWithAttendancesProvider : IBaseProvider<ListTrainingCoursesWithAttendancesEntity, int>
    {
        private ListTrainingCoursesWithAttendancesDAC listtrainingcourseswithattendancesdac;
        private General general;

        public ListTrainingCoursesWithAttendancesProvider()
        {
            listtrainingcourseswithattendancesdac = new ListTrainingCoursesWithAttendancesDAC();
            general = new General();
        }
        public int Add(ListTrainingCoursesWithAttendancesEntity Current)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Edit(ListTrainingCoursesWithAttendancesEntity Current)
        {
            throw new NotImplementedException();
        }

        public ListTrainingCoursesWithAttendancesEntity Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ListTrainingCoursesWithAttendancesEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        //public IQueryable<ListTrainingCoursesWithAttendancesEntity> GetAllListTrainingCoursesWithAttendances(string CurrentPersianFristDate, string CurrentPersianLastDate)
        public List<ListTrainingCoursesWithAttendancesEntity> GetAllListTrainingCoursesWithAttendances(TrainingCoursesWithAttendancesSearch trainingcourseswithattendancessearch)
        {
            //TrainingCoursesWithAttendancesSearch objSearch = new TrainingCoursesWithAttendancesSearch();
            //objSearch.FromDate = general.ShamsiToMiladi(trainingcourseswithattendancessearch.FromDatePer);
            //objSearch.ToDate = general.ShamsiToMiladi(trainingcourseswithattendancessearch.ToDatePer);

            ////objSearch.FromDatePer = general.MiladiChangeFormat(objSearch.FromDate.Value.ToShortDateString().ToString());
            ////objSearch.ToDatePer = general.MiladiChangeFormat(objSearch.ToDate.Value.ToShortDateString().ToString());

            return listtrainingcourseswithattendancesdac.GetAllListTrainingCoursesWithAttendances(trainingcourseswithattendancessearch);
        }

    }
}
