using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Report;
using InterfaceEntity.Search.BasicInformation;
using Presentation.Utility;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "10")]
    public class EmployemeController : Controller
    {
        private EmployemeProvider _EmployemeProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;
        private DetailPlacementTabJobTrainingProvider detailplacementtabjobtrainingprovider;

        public EmployemeController()
        {
            _EmployemeProvider = new EmployemeProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
            detailplacementtabjobtrainingprovider = new DetailPlacementTabJobTrainingProvider();
        }

        // GET: AccessAndLog List
        public ActionResult Index()
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueId = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.Education), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                DepartmentProvider _DepartmentProvider = new DepartmentProvider();
                DepartmentEntity _DepartmentEntity = new DepartmentEntity();
                ViewBag.DepartmentId = new SelectList(_DepartmentProvider.GetAll(), "DepartmentId", "Name", _DepartmentEntity.DepartmentId);

                ViewBag.ReportNameId = (int)ReportName.ReportNames.Employemes;

                var list = _EmployemeProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_EmployemeProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReport(int ID)
        {
            try
            {
                General _General = new General();
                List<EmployeeTrainingPassedReport> ListEmployeeTrainingPassedReport = new List<EmployeeTrainingPassedReport>();

                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                EmployemeJobProvider _EmployemeJobProvider = new EmployemeJobProvider();
                var Employeme = _EmployemeProvider.GetEmployemeReport(ID);
                var EmployeeTrainingPassed = _EmployemeProvider.GetEmployeeTrainingPassedReport(ID).ToList();
                foreach (var item in EmployeeTrainingPassed)
                {
                    if (item.OJT == true)
                        item.Datecourse = _General.shamsiYear(item.DateCourseDateTime);
                    else
                        item.Datecourse = _General.MiladiToShamsi(item.DateCourseDateTime);
                    ListEmployeeTrainingPassedReport.Add(item);
                }

                var DetailPlacementTabJobTraining = detailplacementtabjobtrainingprovider.GetDetailPlacementTabJobTrainingemployeme(ID).ToList();
                if (DetailPlacementTabJobTraining.Count > 0)
                {
                    foreach (var item in DetailPlacementTabJobTraining)
                    {
                        if (item.OJT == true)
                            item.Datecourse = _General.shamsiYear(item.DateCourseDateTime);
                        else
                            item.Datecourse = _General.MiladiToShamsi(item.DateCourseDateTime);
                        ListEmployeeTrainingPassedReport.Add(item);
                    }
                }

                //var ActivePostGroupName = _EmployemeJobProvider.GetAllActivePostGroupName(ID).ToList();
                //var SignatureResponsibility = new List<SignatureResponsibilityReport>()

                //970119 add by ForoughEbrahimi 
                var listemployeetrainingpassedreport = ListEmployeeTrainingPassedReport.OrderBy(a => a.Datecourse);

                var ActivePostGroupName = _EmployemeJobProvider.GetAllActivePostGroupName(ID).ToList();
                var SignatureResponsibility = new List<SignatureResponsibilityReport>()
            {
                new SignatureResponsibilityReport() { producerJob="کارشناس آموزش",producerName="",SeconderJob="",SeconderName=""}
            };

                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/Employemes.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("Employeme_business", Employeme);
                mainReport.RegBusinessObject("EmployeeTrainingPassed_business", listemployeetrainingpassedreport);
                mainReport.RegBusinessObject("CurrentPostGroup_business", ActivePostGroupName);
                mainReport.RegBusinessObject("SignatureResponsibility_business", SignatureResponsibility);
                // 

                mainReport["EducationalExperts"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Specifications;
                mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;


                //نمایش امضاء
                //add New 990922
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

                //Create Pdf File
                //Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
                //mainReport.ExportDocument(StiExportFormat.Pdf, "C:\\1.pdf");
                //

                //ارسال دیتا به گزارش ساز را انجام می دهد
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);

            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult PrintToPdf()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        public ActionResult StiReportPdfFile()
        {
            List<EmployemeEntity> ListEmployemeEntity = (List<EmployemeEntity>)TempData["ListEmployemeEntity"];
            int ID = 0;
            if (TempData["ListEmployemeEntity"] != null)
            {
                RedirectToAction("Print", "BasicInformation");
                foreach (var listemployemeentity in ListEmployemeEntity)
                {
                     ID = listemployemeentity.EmployemeId;

                    General _General = new General();
                    List<EmployeeTrainingPassedReport> ListEmployeeTrainingPassedReport = new List<EmployeeTrainingPassedReport>();

                    NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                    var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                    EmployemeJobProvider _EmployemeJobProvider = new EmployemeJobProvider();
                    var Employeme = _EmployemeProvider.GetEmployemeReport(ID);
                    //Employeme Employeme.FirstName
                    var EmployeeTrainingPassed = _EmployemeProvider.GetEmployeeTrainingPassedReport(ID).ToList();
                    foreach (var item in EmployeeTrainingPassed)
                    {
                        if (item.OJT == true)
                            item.Datecourse = _General.shamsiYear(item.DateCourseDateTime);
                        else
                            item.Datecourse = _General.MiladiToShamsi(item.DateCourseDateTime);
                        ListEmployeeTrainingPassedReport.Add(item);
                    }

                    var DetailPlacementTabJobTraining = detailplacementtabjobtrainingprovider.GetDetailPlacementTabJobTrainingemployeme(ID).ToList();
                    if (DetailPlacementTabJobTraining.Count > 0)
                    {
                        foreach (var item in DetailPlacementTabJobTraining)
                        {
                            if (item.OJT == true)
                                item.Datecourse = _General.shamsiYear(item.DateCourseDateTime);
                            else
                                item.Datecourse = _General.MiladiToShamsi(item.DateCourseDateTime);
                            ListEmployeeTrainingPassedReport.Add(item);
                        }
                    }

                    //var ActivePostGroupName = _EmployemeJobProvider.GetAllActivePostGroupName(ID).ToList();
                    //var SignatureResponsibility = new List<SignatureResponsibilityReport>()

                    //970119 add by ForoughEbrahimi 
                    var listemployeetrainingpassedreport = ListEmployeeTrainingPassedReport.OrderBy(a => a.Datecourse);

                    var ActivePostGroupName = _EmployemeJobProvider.GetAllActivePostGroupName(ID).ToList();
                    var SignatureResponsibility = new List<SignatureResponsibilityReport>()
                    {
                    new SignatureResponsibilityReport() { producerJob="کارشناس آموزش",producerName="",SeconderJob="",SeconderName=""}
                    };

                    // ایجاد شی جدید
                    var mainReport = new Stimulsoft.Report.StiReport();
                    // فراخوانی فایل استیمول
                    mainReport.Load(Server.MapPath("~/FilesReport/Employemes.mrt"));
                    // 
                    mainReport.Compile();
                    // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                    mainReport.RegBusinessObject("Employeme_business", Employeme);
                    mainReport.RegBusinessObject("EmployeeTrainingPassed_business", listemployeetrainingpassedreport);
                    mainReport.RegBusinessObject("CurrentPostGroup_business", ActivePostGroupName);
                    mainReport.RegBusinessObject("SignatureResponsibility_business", SignatureResponsibility);
                    // 

                    mainReport["EducationalExperts"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Specifications;
                    mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;

                    //نمایش امضاء
                    //add New 990922
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

                    //Create Pdf File
                    //string Todaydate = _General.CurrentPersianDate().Replace("/", "");
                    //string fileName = Employeme.FirstName + "-" + Employeme.LastName;
                    //string pathString = @"\\192.168.0.27\EmployeReport\" + Todaydate + '\\' ;

                    //Directory.CreateDirectory(pathString);
                    //Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
                    ////mainReport.ExportDocument(StiExportFormat.Pdf, "C:\\" + fileName + ".pdf");
                    //mainReport.ExportDocument(StiExportFormat.Pdf, pathString + fileName + ".pdf");


                    string Todaydate = _General.CurrentPersianDate().Replace("/", "");
                    string fileName = Employeme.FirstName + "-" + Employeme.LastName;

                    //1400 12 23 ADD COMMENT
                    //Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
                    Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);




                    string folderPath = Server.MapPath("~/Files/" + "/" + Todaydate + "/");

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).

                    //mainReport.ExportDocument(StiExportFormat.Pdf, folderPath + fileName + ".pdf");
                    mainReport.ExportDocument(StiExportFormat.ImagePng, folderPath + fileName + ".Png");

                }
            }


            return RedirectToAction("Index", new { id = ID });
        }

        public ActionResult ViewerEvent()
        {
            try
            {
                return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }

        }

        [HttpPost]
        public ActionResult Create(EmployemeEntity Current)
        {
            try
            {
                int result;
                result = _EmployemeProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.Employeme, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployemeEntity Current)
        {
            try
            {
                bool result;
                result = _EmployemeProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.Employeme, _CustomAuthorizeAttribute.UserId(), "", "", Current.EmployemeId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _EmployemeProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.Employeme, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }

        }


        [HttpPost]
        public ActionResult _GetListEmployeme(EmployemeSearch employemesearch)
        {
            try
            {
                #region set null to string.Empty
                if (employemesearch.FirstName == null)
                    employemesearch.FirstName = string.Empty;

                if (employemesearch.LastName == null)
                    employemesearch.LastName = string.Empty;

                if (employemesearch.FieldOfStudy == null)
                    employemesearch.FieldOfStudy = string.Empty;
                #endregion

                List<EmployemeEntity> _EmployemeEntity = new List<EmployemeEntity>();
                if (employemesearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    _EmployemeEntity = _EmployemeProvider.GetAll().ToList();
                    return View(_EmployemeEntity);
                }
                else if (
                   employemesearch.FirstName.Trim() == "" && employemesearch.LastName.Trim() == "" && employemesearch.PersonnelCode == 0 &&
                   employemesearch.EducationId == 0 && employemesearch.FieldOfStudy.Trim() == "" && employemesearch.UnitSCenterId == 0 &&
                   employemesearch.SectionId == 0 && employemesearch.DepartmentId == 0 && employemesearch.typesearch == (int)TypeSearch.typesearch.WithParameter
                   & employemesearch.State == -1)
                {
                    _EmployemeEntity = _EmployemeProvider.GetAll().ToList();
                    return View(_EmployemeEntity);
                }
                else if (employemesearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    employemesearch.UserState = Convert.ToBoolean(employemesearch.State);
                    _EmployemeEntity = _EmployemeProvider.GetAll(employemesearch).ToList();
                }


                List<EmployemeEntity> _EmployemeEntityDistinct = new List<EmployemeEntity>();
                foreach (EmployemeEntity item in _EmployemeEntity)
                {
                    int count = _EmployemeEntityDistinct.Count(a => a.EmployemeId == item.EmployemeId);
                    if (count == 0)
                        _EmployemeEntityDistinct.Add(item);
                }
                TempData["ListEmployemeEntity"] = _EmployemeEntityDistinct;
                return View(_EmployemeEntityDistinct);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListEmployeme");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetEmployemeByPostGroupId(int postgroupid)
        {
            try
            {
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.Employeme = new SelectList(_EmployemeProvider.GetAll(postgroupid), "EmployemeId", "Name", _EmployemeEntity.EmployemeId);

                return Json(ViewBag.Employeme);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetEmployemeByPostGroupId");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}