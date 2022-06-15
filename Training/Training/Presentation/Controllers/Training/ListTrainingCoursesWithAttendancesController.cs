using Bussiness;
using Bussiness.Provider.Training;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "39")]
    public class ListTrainingCoursesWithAttendancesController : Controller
    {
        private ListTrainingCoursesWithAttendancesProvider _ListTrainingCoursesWithAttendancesProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;
        private General general;

        public ListTrainingCoursesWithAttendancesController()
        {
            _ListTrainingCoursesWithAttendancesProvider = new ListTrainingCoursesWithAttendancesProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
            general = new General();
        }

        // GET: ListTrainingCoursesWithAttendances
        public ActionResult Index()
        {
            var CurrentPersianDate = general.CurrentPersianDate();
            ViewBag.CurrentPersianDate = CurrentPersianDate;

            string NowDateTimeMiladi = DateTime.Now.ToShortDateString().ToString();
            ViewBag.CurrentDateMiladi = general.MiladiChangeFormat(NowDateTimeMiladi);

            TrainingCoursesWithAttendancesSearch trainingcourseswithattendancessearch = new TrainingCoursesWithAttendancesSearch();
            trainingcourseswithattendancessearch.FromDatePer = NowDateTimeMiladi;
            trainingcourseswithattendancessearch.ToDatePer =NowDateTimeMiladi;

            //return Content(NowDateTimeMiladi + "----" + general.MiladiChangeFormat(NowDateTimeMiladi));
            var list = _ListTrainingCoursesWithAttendancesProvider.GetAllListTrainingCoursesWithAttendances(trainingcourseswithattendancessearch);
            return View(list);
        }

        public ActionResult Test(string par)
        {
            ViewBag.TestViewBage = par + " ----- " + general.CurrentPersianDate(); 
            return View();
        }

        [HttpPost]
        public ActionResult _GetListTrainingCoursesWithAttendances(TrainingCoursesWithAttendancesSearch trainingcourseswithattendancessearch)
        {
            try
            {
                 var list = _ListTrainingCoursesWithAttendancesProvider.GetAllListTrainingCoursesWithAttendances(trainingcourseswithattendancessearch);
                return View(list);
                //return RedirectToAction("Test", new { par = "55555555555" });
                //return Content("hello");
               
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingCoursesWithAttendances, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTrainingCoursesWithAttendances");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}