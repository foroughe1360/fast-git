using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using InterfaceEntity.Search.Trianing;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.Training
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "22")]
    public class TrainingCalendarController : Controller
    {
        private TrainingCalendarProvider _TrainingCalendarProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public TrainingCalendarController()
        {
            _TrainingCalendarProvider = new TrainingCalendarProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: TrainingCalendar
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.TrainingCalendarDateId = ID;
                ViewBag.ReportNameId = (int)ReportName.ReportNames.TrainingCalendarDate;

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdTypeTrainingCalendarDateId = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TypeTrainingCalendarDate), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                
                var list = _TrainingCalendarProvider.GetAll(ID).ToList();
                TempData["TrainingCalendarEntity"] = list;

                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
           
        public ActionResult Create()
        {
            try
            {
                TeacherProvider _TeacherProvider = new TeacherProvider();
                TeacherEntity _TeacherEntity = new TeacherEntity();
                ViewBag.TeacherId = new SelectList(_TeacherProvider.GetAll(), "TeacherId", "TeacherName", _TeacherEntity.TeacherId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdParticipantlevel = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.Participantlevel), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                ViewBag.TableInterfaceValueIdTypeTrainingCalendarDateId = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TypeTrainingCalendarDate), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                TeacherProvider _TeacherProvider = new TeacherProvider();
                TeacherEntity _TeacherEntity = new TeacherEntity();
                ViewBag.TeacherIdTemp = new SelectList(_TeacherProvider.GetAll(), "TeacherId", "TeacherName", _TeacherEntity.TeacherId);


                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdParticipantlevelTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.Participantlevel), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                ViewBag.TableInterfaceValueIdTypeTrainingCalendarDateId = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TypeTrainingCalendarDate), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                var test = _TrainingCalendarProvider.Get(ID);
                return View(test);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReport()//(int ID)
        {
            try
            {
                General _General = new General();

                //var _TrainingCalendarReport = _TrainingCalendarProvider.GetAll(ID).ToList();

                List<TrainingCalendarEntity> trainingcalendarentityList = (List<TrainingCalendarEntity>)TempData["TrainingCalendarEntity"];
                int ID = trainingcalendarentityList.Select(a => a.TrainingCalendarDateId).First();

                TrainingCalendarEntity trainingcalendarentity;
                List<TrainingCalendarEntity> listtrainingcalendarentity = new List<TrainingCalendarEntity>();

                //نمایش تاریخ تایید و تهیه و تصویب
                SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                int ReportNameId = (int)ReportName.ReportNames.TrainingCalendarDate;
                var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);


                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                foreach (TrainingCalendarEntity item in trainingcalendarentityList)//foreach (TrainingCalendarEntity item in _TrainingCalendarReport)
                {

                    trainingcalendarentity = new TrainingCalendarEntity();
                    trainingcalendarentity.TrainingCalendarId = item.TrainingCalendarId;
                    trainingcalendarentity.CourseName = item.CourseName;
                    trainingcalendarentity.TeacherId = item.TeacherId;
                    trainingcalendarentity.TeacherName = item.TeacherName;
                    trainingcalendarentity.Participantlevel = item.Participantlevel;
                    trainingcalendarentity.Description = item.Description;
                    trainingcalendarentity.TrainingCalendarDatestr = _General.MiladiToShamsi(item.TrainingCalendarDate);
                    trainingcalendarentity.TrainingCalendarDay = _General.PersianDay((item.TrainingCalendarDay == null ? 0 : int.Parse(item.TrainingCalendarDay)));



                    trainingcalendarentity.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                    trainingcalendarentity.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                    trainingcalendarentity.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);


                    listtrainingcalendarentity.Add(trainingcalendarentity);
                }

                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/TrainingCalendar.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                //mainReport.RegBusinessObject("Post_business", _PostReport);
                mainReport.RegBusinessObject("TrainingCalendar_business", listtrainingcalendarentity);

                // 

                mainReport["EducationalExperts"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Specifications;
                mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;

                //نمایش امضاء
                //add New 990618
                EmployemeSignaturyProvider employemesignaturyprovider = new EmployemeSignaturyProvider();
                var GetEmployemeSOfSignatory = employemesignaturyprovider.GetListEmployemeSignatury().ToList();
                mainReport["HeadOfTrainingAndInformation"] = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Select(a => a.Specifications).FirstOrDefault();

                byte[] arraySignature = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Select(a => a.Signature).FirstOrDefault();
                MemoryStream ms = new MemoryStream(arraySignature);
                System.Drawing.Image imageSignature = System.Drawing.Image.FromStream(ms);
                mainReport["SignatureOFHeadOfTrainingAndInformation"] = imageSignature;


                //امضاء کارشناس آموزش 
                byte[] arraySignatureOFEducationalExperts = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Select(a => a.Signature).FirstOrDefault();
                MemoryStream msSignatureOFEducationalExperts = new MemoryStream(arraySignatureOFEducationalExperts);
                System.Drawing.Image imageSignatureOFEducationalExperts = System.Drawing.Image.FromStream(msSignatureOFEducationalExperts);
                mainReport["SignatureOFEducationalExperts"] = imageSignatureOFEducationalExperts;

                //ارسال دیتا به گزارش ساز را انجام می دهد
                //1400 12 23 ADD COMMENT
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);

            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TrainingCalendarEntity Current)
        {
            try
            {
                int result;
                result = _TrainingCalendarProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.TrainingCalendar, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TrainingCalendarEntity Current)
        {
            try
            {
                bool result;
                result = _TrainingCalendarProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.TrainingCalendar, _CustomAuthorizeAttribute.UserId(), "", "", Current.TrainingCalendarId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _TrainingCalendarProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.TrainingCalendar, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListTrainingCalendar(int ID)
        {
            try
            {
                var list = _TrainingCalendarProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingCalendar, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTrainingCalendar");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListTrainingCalendar(TrainingCalendarSearch trainingcalendarsearch)
        {
            try
            {
                #region set null to string.Empty
                if (trainingcalendarsearch.CourseName == null)
                    trainingcalendarsearch.CourseName = string.Empty;
                #endregion

                List<TrainingCalendarEntity> _TrainingCalendarEntity = new List<TrainingCalendarEntity>();
                if (trainingcalendarsearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    _TrainingCalendarEntity = _TrainingCalendarProvider.GetAll(trainingcalendarsearch.TrainingCalendarDateId).ToList();
                    return View(_TrainingCalendarEntity);
                }
                else if (trainingcalendarsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    _TrainingCalendarEntity = _TrainingCalendarProvider.GetAll(trainingcalendarsearch).ToList();
                }
                TempData["TrainingCalendarEntity"] = _TrainingCalendarEntity;
                return View(_TrainingCalendarEntity);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Teacher, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTrainingCalendar");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}