using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Report;
using InterfaceEntity.Search.Trianing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.BasicInformation
{
    public class EmployeeTrainingPassedReportController : Controller
    {
        private EmployemeProvider _EmployemeProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;
        private DetailPlacementTabJobTrainingProvider detailplacementtabjobtrainingprovider;

        private EmployeeTrainingPassedProvider _EmployeeTrainingPassedProvider;

        public EmployeeTrainingPassedReportController()
        {
            _EmployemeProvider = new EmployemeProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
            detailplacementtabjobtrainingprovider = new DetailPlacementTabJobTrainingProvider();

            _EmployeeTrainingPassedProvider = new EmployeeTrainingPassedProvider();
        }

        // GET: EmployeeTrainingPassedReport
        public ActionResult Index(int ID)
        {
            try
            {
                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                ViewBag.TrainingCourseId = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceIdTrainingVenue = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TrainingVenue), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.EmployemeId = ID;
                //var list = _EmployeeTrainingPassedProvider.GetAll(ID).ToList();
                //return View(list);


                General _General = new General();
                List<EmployeeTrainingPassedEntity> ListEmployeeTrainingPassedReport = new List<EmployeeTrainingPassedEntity>();

                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                EmployemeJobProvider _EmployemeJobProvider = new EmployemeJobProvider();
                var Employeme = _EmployemeProvider.GetEmployemeReport(ID);
                // var EmployeeTrainingPassed = _EmployemeProvider.GetEmployeeTrainingPassedReport(ID).ToList();
                var EmployeeTrainingPassed = _EmployeeTrainingPassedProvider.GetAll(ID).ToList();
                foreach (var item in EmployeeTrainingPassed)
                {
                    ListEmployeeTrainingPassedReport.Add(item);
                }
                var DetailPlacementTabJobTraining = _EmployeeTrainingPassedProvider.GetDetailPlacementTabJobTrainingemployeme(ID).ToList();
                if (DetailPlacementTabJobTraining.Count > 0)
                {
                    foreach (var item in DetailPlacementTabJobTraining)
                    {
                        ListEmployeeTrainingPassedReport.Add(item);
                    }
                }

                var listemployeetrainingpassedreport = ListEmployeeTrainingPassedReport.OrderBy(a => a.DateCourse);
                return View(listemployeetrainingpassedreport);

            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult _GetSumDurationTrainingPassed(int EmployemeId)
        {
            List<EmployeeTrainingPassedEntity> ListEmployeeTrainingPassedReport = new List<EmployeeTrainingPassedEntity>();
            var EmployeeTrainingPassed = _EmployeeTrainingPassedProvider.GetAll(EmployemeId).ToList();

            foreach (var item in EmployeeTrainingPassed)
            {
                ListEmployeeTrainingPassedReport.Add(item);
            }

            var DetailPlacementTabJobTraining = _EmployeeTrainingPassedProvider.GetDetailPlacementTabJobTrainingemployeme(EmployemeId).ToList();
            if (DetailPlacementTabJobTraining.Count > 0)
            {
                foreach (var item in DetailPlacementTabJobTraining)
                {
                    ListEmployeeTrainingPassedReport.Add(item);
                }
            }

            var SumDuration = ListEmployeeTrainingPassedReport.Sum(p => p.Duration);
            return Json(SumDuration);

            //var SumDuration = _EmployeeTrainingPassedProvider.SumDuration(EmployemeId);
            //return Json(SumDuration);
        }

        [HttpPost]
        public ActionResult _GetListEmployeeTrainingPassedSearch(EmployeeTrainingPassedReportSearch employeetrainingpassedreportsearch)
        {
            try
            {
                ViewBag.EmployemeIdSearch = 30;
                if (employeetrainingpassedreportsearch.TrainingCourseName == null)
                    employeetrainingpassedreportsearch.TrainingCourseName = string.Empty;

                List<EmployeeTrainingPassedEntity> _employeetrainingpassedentity = new List<EmployeeTrainingPassedEntity>();
                _employeetrainingpassedentity = _EmployeeTrainingPassedProvider.GetListEmployeeTrainingPassedSearch(employeetrainingpassedreportsearch).ToList();

                List<EmployeeTrainingPassedEntity> _EmployeeTrainingPassedEntityDistinct = new List<EmployeeTrainingPassedEntity>();
                foreach (EmployeeTrainingPassedEntity item in _employeetrainingpassedentity)
                {
                    int count = _EmployeeTrainingPassedEntityDistinct.Count(a => a.Employemeid == item.Employemeid);
                    if (count == 0)
                        _EmployeeTrainingPassedEntityDistinct.Add(item);
                }

                return View(_employeetrainingpassedentity);
                // return Json(true);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListEmployeme");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

     
    }
}