using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Report.Training.DesignTrainingCourse;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.Training
{
    [CustomAuthorize(Roles = "Admin,User")]
    public class AttendanceDateController : Controller
    {

        private AttendanceDateProvider _AttendanceDateProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public AttendanceDateController()
        {
            _AttendanceDateProvider = new AttendanceDateProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        // GET: AttendanceDate
        public ActionResult Index(int ID,int designtrainingcoursedateid)
        {
            try
            {
                DesignTrainingCourseProvider _DesignTrainingCourseProvider = new DesignTrainingCourseProvider();
                var list = _AttendanceDateProvider.GetAll(ID).ToList();
                ViewBag.DesignTrainingCourseId = ID;
                ViewBag.DesignTrainingCourseDateId = designtrainingcoursedateid;
                //var _CourseDate = _AttendanceDateProvider.getCourseDate(ID);

                ViewBag.ReportNameId = (int)ReportName.ReportNames.HozorVaGhiab;
                var _CourseDate = _DesignTrainingCourseProvider.GetDesignTrainingCourse(ID);
                if (_CourseDate != null)
                    ViewBag.CourseDate = _CourseDate.TrainingCourse;
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_AttendanceDateProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
       
        public ActionResult Print(int ID)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReport(int ID )
        {
            try
            {
                General _General = new General();

                DesignTrainingCourseProvider _DesignTrainingCourseProvider = new DesignTrainingCourseProvider();
                DesignTrainingCourseReport _DesignTrainingCourseReport = new DesignTrainingCourseReport();
                _DesignTrainingCourseReport = _DesignTrainingCourseProvider.GetDesignTrainingCourse(ID);
                var attendancedatereport = _AttendanceDateProvider.GetAttendanceDate(ID).ToList();

                //نمایش تاریخ تایید و تهیه و تصویب
                SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                int ReportNameId = (int)ReportName.ReportNames.HozorVaGhiab;
                var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);
                _DesignTrainingCourseReport.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                _DesignTrainingCourseReport.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                _DesignTrainingCourseReport.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
                //


                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                AttendanceDateReport _attendancedatereport;
                List<AttendanceDateReport> ListAttendanceDateReport = new List<AttendanceDateReport>();
                foreach (AttendanceDateReport item in attendancedatereport)
                {
                    _attendancedatereport = new AttendanceDateReport();
                    _attendancedatereport.AttendanceAbsenceDate = item.AttendanceAbsenceDate;
                    _attendancedatereport.AttendanceAbsenceDateFarsi = _General.MiladiToShamsi(item.AttendanceAbsenceDate);
                    _attendancedatereport.EmployemeName = item.EmployemeName;
                    _attendancedatereport.TypeAttendance = item.TypeAttendance;
                    if (item.TypeAttendance == 184)
                        _attendancedatereport.TypeAttendanceDate = "✔";
                    else
                        _attendancedatereport.TypeAttendanceDate = "-";


                    _attendancedatereport.PreTestScore = item.PreTestScore;
                    _attendancedatereport.TestScore = item.TestScore;
                    _attendancedatereport.PracticalTestScore = item.PracticalTestScore;
                    _attendancedatereport.FinalTestScore = item.FinalTestScore;

                    ListAttendanceDateReport.Add(_attendancedatereport);
                }
                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/HozorVaGhiab.mrt"));
                // 
                mainReport.Compile();

                Stimulsoft.Report.Dictionary.StiDataParameter parameter = new Stimulsoft.Report.Dictionary.StiDataParameter();
                parameter.Name = "EducationalExperts";
                parameter.Value = "9";

                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("AttendanceDate_business", ListAttendanceDateReport);
                mainReport.RegBusinessObject("DesignTrainingCourse_business", _DesignTrainingCourseReport);
                // 

                mainReport["EducationalExperts"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Specifications;

                //Comment 990625
                //mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;

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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(AttendanceDateEntity Current)
        {
            try
            {
                int result;
                result = _AttendanceDateProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.AttendanceDate, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        [HttpPost]
        public ActionResult Edit(AttendanceDateEntity Current)
        {
            try
            {
                bool result;
                result = _AttendanceDateProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.AttendanceDate, _CustomAuthorizeAttribute.UserId(), "", "", Current.AttendanceDateId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _AttendanceDateProvider.Delete(ID);

                 #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.AttendanceDate, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                    _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        
        [HttpGet]
        public ActionResult _GetListAttendanceDate(int designtrainingcourseid,int designtrainingcoursedateid)
        {
            try
            {
                ViewBag.DesignTrainingCourseId = designtrainingcourseid;
                ViewBag.DesignTrainingCourseDateId = designtrainingcoursedateid;
                var list = _AttendanceDateProvider.GetAll(designtrainingcourseid).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AttendanceDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListAttendanceDate");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}