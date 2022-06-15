using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using InterfaceEntity.Report.Training.DesignTrainingCourse;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "23")]
    public class DesignTrainingCourseController : Controller
    {
        private DesignTrainingCourseProvider _DesignTrainingCourseProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public DesignTrainingCourseController()
        {
            _DesignTrainingCourseProvider = new DesignTrainingCourseProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: AccessAndLog List
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.DesignTrainingCourseDateId = ID;
                var list = _DesignTrainingCourseProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //محل برگزاری
                ViewBag.TableInterfaceIdTrainingVenue = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TrainingVenue), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //نوع دوره آموزشی
                ViewBag.TableInterfaceValueIdTypesOfTraining = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TypesOfTraining), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //نام دوره های آموزش
                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                ViewBag.TrainingCourseId = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                //نام استاد
                TeacherProvider _TeacherProvider = new TeacherProvider();
                TeacherEntity _TeacherEntity = new TeacherEntity();
                ViewBag.TeacherId = new SelectList(_TeacherProvider.GetAll(), "TeacherId", "TeacherName", _TeacherEntity.TeacherId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //محل برگزاری
                ViewBag.TableInterfaceIdTrainingVenue = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TrainingVenue), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //نوع دوره آموزشی
                ViewBag.TableInterfaceValueIdTypesOfTrainingTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TypesOfTraining), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //نام دوره های آموزش
                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                ViewBag.TrainingCourseIdTemp = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                //نام استاد
                TeacherProvider _TeacherProvider = new TeacherProvider();
                TeacherEntity _TeacherEntity = new TeacherEntity();
                ViewBag.TeacherIdTemp = new SelectList(_TeacherProvider.GetAll(), "TeacherId", "Name", _TeacherEntity.TeacherId);


                return View(_DesignTrainingCourseProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Print()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReport(int ID)
        {
            try
            {
                General _General = new General();

                DesignTrainingCourseReport _DesignTrainingCourseReport = new DesignTrainingCourseReport();

                ListLearningAssistToolProvider _ListLearningAssistToolProvider = new ListLearningAssistToolProvider();
                ListLearningAssistToolReport _ListLearningAssistToolReport = new ListLearningAssistToolReport();

                ListStyleCourseProvider _ListStyleCourseProvider = new ListStyleCourseProvider();
                ListStyleCourseReport _ListStyleCourseReport = new ListStyleCourseReport();

                ListEffectivenessOfCourseProvider _ListEffectivenessOfCourseProvider = new ListEffectivenessOfCourseProvider();
                ListEffectivenessOfCourseReport _ListEffectivenessOfCourseReport = new ListEffectivenessOfCourseReport();

                _DesignTrainingCourseReport = _DesignTrainingCourseProvider.GetDesignTrainingCourse(ID);

                var _ListLearningAssistTool = _ListLearningAssistToolProvider.GetListLearningAssistTool(ID).ToList();
                foreach (ListLearningAssistToolEntity item in _ListLearningAssistTool)
                {
                    switch (item.LearningAssistToolId)
                    {
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.PersianBook:
                            _ListLearningAssistToolReport.PersianBook = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.PersianLeaflet:
                            _ListLearningAssistToolReport.PersianLeaflet = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.BooksInEnglish:
                            _ListLearningAssistToolReport.BooksInEnglish = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.PamphletsInEnglish:
                            _ListLearningAssistToolReport.PamphletsInEnglish = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.OriginalPersian:
                            _ListLearningAssistToolReport.OriginalPersian = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.EnglishArticle:
                            _ListLearningAssistToolReport.EnglishArticle = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.PowerpointPersian:
                            _ListLearningAssistToolReport.PowerpointPersian = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.PowerpointEnglish:
                            _ListLearningAssistToolReport.PowerpointEnglish = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.VideoProjector:
                            _ListLearningAssistToolReport.VideoProjector = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.Whiteboard:
                            _ListLearningAssistToolReport.Whiteboard = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.DVD:
                            _ListLearningAssistToolReport.DVD = true;
                            break;
                        case (int)ListLearningAssistToolReport.ListLearningAssistTool.Other:
                            _ListLearningAssistToolReport.Other = true;
                            break;
                    }

                }
                var _ListStyleCourse = _ListStyleCourseProvider.getListStyleCoursesReport(ID).ToList();
                foreach (ListStyleCourseEntity item in _ListStyleCourse)
                {
                    switch (item.StyleCoursesId)
                    {
                        case (int)ListStyleCourseReport.ListStyleCourse.Classroom:
                            _ListStyleCourseReport.Classroom = true;
                            break;
                        case (int)ListStyleCourseReport.ListStyleCourse.OJT:
                            _ListStyleCourseReport.OJT = true;
                            break;
                        case (int)ListStyleCourseReport.ListStyleCourse.SD:
                            _ListStyleCourseReport.SD = true;
                            break;
                        case (int)ListStyleCourseReport.ListStyleCourse.Workshop:
                            _ListStyleCourseReport.Workshop = true;
                            break;
                        case (int)ListStyleCourseReport.ListStyleCourse.PracticalWork:
                            _ListStyleCourseReport.PracticalWork = true;
                            break;
                    }

                }

                var _ListEffectivenessOfCourse = _ListEffectivenessOfCourseProvider.getListEffectivenessOfCourse(ID).ToList();
                foreach (ListEffectivenessOfCourseEntity item in _ListEffectivenessOfCourse)
                {
                    switch (item.EffectivenessOfCoursesId)
                    {
                        case (int)ListEffectivenessOfCourseReport.ListEffectivenessOfCourse.CompareScore:
                            _ListEffectivenessOfCourseReport.CompareScore = true;
                            break;
                        case (int)ListEffectivenessOfCourseReport.ListEffectivenessOfCourse.SurveyParticipants:
                            _ListEffectivenessOfCourseReport.SurveyParticipants = true;
                            break;
                        case (int)ListEffectivenessOfCourseReport.ListEffectivenessOfCourse.SurveySupervisor:
                            _ListEffectivenessOfCourseReport.SurveySupervisor = true;
                            break;
                    }

                }

                DetailOfferTrainingForJobProvider _DetailOfferTrainingForJobProvider = new DetailOfferTrainingForJobProvider();
                var _DetailOfferTrainingForJobReport = _DetailOfferTrainingForJobProvider.GetDetailOfferTrainingForJobReport(ID).ToList();

                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/DesignTraining.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                //mainReport.RegBusinessObject("Post_business", _PostReport);
                mainReport.RegBusinessObject("DesignTrainingCourse_business", _DesignTrainingCourseReport);
                mainReport.RegBusinessObject("ListLearningAssistTool_business", _ListLearningAssistToolReport);
                mainReport.RegBusinessObject("ListStyleCourse_business", _ListStyleCourseReport);
                mainReport.RegBusinessObject("ListEffectivenessOfCourse_business", _ListEffectivenessOfCourseReport);

                // 
                //ارسال دیتا به گزارش ساز را انجام می دهد
                //1400 12 23 ADD COMMENT
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult ViewerEvent()
        {
            try
            {
                return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(DesignTrainingCourseEntity Current)
        {
            try
            {
                int result;
                result = _DesignTrainingCourseProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.DesignTrainingCourse, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(DesignTrainingCourseEntity Current)
        {
            try
            {
                bool result;
                result = _DesignTrainingCourseProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.DesignTrainingCourse, _CustomAuthorizeAttribute.UserId(), "", "", Current.DesignTrainingCourseId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                bool result;
                result = _DesignTrainingCourseProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.DesignTrainingCourse, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListDesignTrainingCourse(int ID)
        {
            try
            {
                var list = _DesignTrainingCourseProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListDesignTrainingCourse");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult GetDesignTrainingCourseListDPD(int trainingcourseid)
        {
            try
            {
                var list = _DesignTrainingCourseProvider.GetDesignTrainingCourseListDPD(trainingcourseid).ToList();
                DesignTrainingCourseEntity _DesignTrainingCourseEntity = new DesignTrainingCourseEntity();
                ViewBag.list = new SelectList(_DesignTrainingCourseProvider.GetDesignTrainingCourseListDPD(trainingcourseid), "DesignTrainingCourseId", "TookHold", _DesignTrainingCourseEntity.DesignTrainingCourseId);
                return Json(ViewBag.list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DesignTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetDesignTrainingCourseListDPD");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }


    }
}