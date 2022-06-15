using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using System.Transactions;
using Presentation.Utility;
using Bussiness.Provider.AccessAndLog;
using System.IO;
using InterfaceEntity.Search.Trianing;
using InterfaceEntity.Search.BasicInformation;
using Stimulsoft.Report;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "29")]
    public class PlacementTabJobTrainingController : Controller
    {
        private PlacementTabJobTrainingProvider _PlacementTabJobTrainingProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public PlacementTabJobTrainingController()
        {
            _PlacementTabJobTrainingProvider = new PlacementTabJobTrainingProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: Attendance
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.PlacementTabJobTrainingDateId = ID;
                ViewBag.ReportNameId = (int)ReportName.ReportNames.OJT;

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueId = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.Education), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                DepartmentProvider _DepartmentProvider = new DepartmentProvider();
                DepartmentEntity _DepartmentEntity = new DepartmentEntity();
                ViewBag.DepartmentId = new SelectList(_DepartmentProvider.GetAll(), "DepartmentId", "Name", _DepartmentEntity.DepartmentId);

                var list = _PlacementTabJobTrainingProvider.GetAll(ID).ToList();

              
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Create()
        {
            try
            {
                //نام کارمند
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.EmployemeId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);


                SupervisorProvider supervisorprovider = new SupervisorProvider();
                SupervisorEntity SupervisorEntity = new SupervisorEntity();

                ViewBag.PostType = new SelectList(supervisorprovider.GetAll(), "SupervisorId", "EmployemePostType", SupervisorEntity.SupervisorId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                var q = _PlacementTabJobTrainingProvider.Get(ID);

                //نام کارمند
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.Employeme = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                SupervisorProvider supervisorprovider = new SupervisorProvider();
                SupervisorEntity SupervisorEntity = new SupervisorEntity();

                ViewBag.PostType = new SelectList(supervisorprovider.GetAll(), "SupervisorId", "EmployemePostType", SupervisorEntity.SupervisorId);

                return View(_PlacementTabJobTrainingProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReport(int ID)
        {
            try
            {
                General _General = new General();
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                var GetPlacementTabJobTraining = _EmployemeProvider.GetPlacementTabJobTraining(ID);

                var _PlacementTabJobTraining = _EmployemeProvider.GetPlacementTabJobTrainings(ID);

                _PlacementTabJobTraining.DateOfEmployementStr = _General.MiladiToShamsi(_PlacementTabJobTraining.DateOfEmployement);
                _PlacementTabJobTraining.DateStartPostGroupNameStr = _General.MiladiToShamsi(_PlacementTabJobTraining.DateStartPostGroupName);

                //نمایش تاریخ تایید و تهیه و تصویب
                SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                int ReportNameId = (int)ReportName.ReportNames.OJT;
                var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);
                _PlacementTabJobTraining.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                _PlacementTabJobTraining.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                _PlacementTabJobTraining.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
                //

                DetailPlacementTabJobTrainingProvider _DetailPlacementTabJobTrainingProvider = new DetailPlacementTabJobTrainingProvider();
                var _DetailPlacementTabJobTraining = _DetailPlacementTabJobTrainingProvider.GetAllDetailPlacementTabJobTrainingReport(ID).ToList();

                DetailOfferTrainingForJobProvider _DetailOfferTrainingForJobProvider = new DetailOfferTrainingForJobProvider();
                var _DetailOfferTrainingForJobReport = _DetailOfferTrainingForJobProvider.GetDetailOfferTrainingForJobReport(ID).ToList();

                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/OJT.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("Employeme_business", _PlacementTabJobTraining);
                mainReport.RegBusinessObject("PlacementTabJobTraining_business", _DetailPlacementTabJobTraining);


                EmployemeSignaturyProvider employemesignaturyprovider = new EmployemeSignaturyProvider();
                var GetEmployemeSOfSignatory = employemesignaturyprovider.GetListEmployemeSignatury().ToList();
                mainReport["HeadOfTrainingAndInformation"] = GetEmployemeSOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;

                byte[] arraySignature = GetEmployemeSOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Signature;
                MemoryStream ms = new MemoryStream(arraySignature);
                System.Drawing.Image imageSignature = System.Drawing.Image.FromStream(ms);
                mainReport["SignatureOFHeadOfTrainingAndInformation"] = imageSignature;

                //NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                //var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();
                //mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;


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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReportPdfFile()
        {
            int ID = 0;

            List<PlacementTabJobTrainingEntity> ListPlacementTabJobTrainingEntity = (List<PlacementTabJobTrainingEntity>)TempData["ListPlacementTabJobTrainingEntity"];

            if (TempData["ListPlacementTabJobTrainingEntity"] != null)
            {
                RedirectToAction("Print", "BasicInformation");
                foreach (var listemployemeentity in ListPlacementTabJobTrainingEntity)
                {
                    ID = listemployemeentity.PlacementTabJobTrainingId;



                    General _General = new General();
                    EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                    var GetPlacementTabJobTraining = _EmployemeProvider.GetPlacementTabJobTraining(ID);

                    var _PlacementTabJobTraining = _EmployemeProvider.GetPlacementTabJobTrainings(ID);



                    _PlacementTabJobTraining.DateOfEmployementStr = _General.MiladiToShamsi(_PlacementTabJobTraining.DateOfEmployement);
                    _PlacementTabJobTraining.DateStartPostGroupNameStr = _General.MiladiToShamsi(_PlacementTabJobTraining.DateStartPostGroupName);

                    //نمایش تاریخ تایید و تهیه و تصویب
                    SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                    int ReportNameId = (int)ReportName.ReportNames.OJT;
                    var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);
                    _PlacementTabJobTraining.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                    _PlacementTabJobTraining.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                    _PlacementTabJobTraining.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
                    //


                    DetailPlacementTabJobTrainingProvider _DetailPlacementTabJobTrainingProvider = new DetailPlacementTabJobTrainingProvider();
                    var _DetailPlacementTabJobTraining = _DetailPlacementTabJobTrainingProvider.GetAllDetailPlacementTabJobTrainingReport(ID).ToList();

                    DetailOfferTrainingForJobProvider _DetailOfferTrainingForJobProvider = new DetailOfferTrainingForJobProvider();
                    var _DetailOfferTrainingForJobReport = _DetailOfferTrainingForJobProvider.GetDetailOfferTrainingForJobReport(ID).ToList();

                    // ایجاد شی جدید
                    var mainReport = new Stimulsoft.Report.StiReport();
                    // فراخوانی فایل استیمول
                    mainReport.Load(Server.MapPath("~/FilesReport/OJT.mrt"));
                    // 
                    mainReport.Compile();
                    // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                    mainReport.RegBusinessObject("Employeme_business", _PlacementTabJobTraining);
                    mainReport.RegBusinessObject("PlacementTabJobTraining_business", _DetailPlacementTabJobTraining);


                    EmployemeSignaturyProvider employemesignaturyprovider = new EmployemeSignaturyProvider();
                    var GetEmployemeSOfSignatory = employemesignaturyprovider.GetListEmployemeSignatury().ToList();
                    mainReport["HeadOfTrainingAndInformation"] = GetEmployemeSOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;

                    byte[] arraySignature = GetEmployemeSOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Signature;
                    MemoryStream ms = new MemoryStream(arraySignature);
                    System.Drawing.Image imageSignature = System.Drawing.Image.FromStream(ms);
                    mainReport["SignatureOFHeadOfTrainingAndInformation"] = imageSignature;

                    //NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                    //var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();
                    //mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;


                    //امضاء کارشناس آموزش 
                    byte[] arraySignatureOFEducationalExperts = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Select(a => a.Signature).FirstOrDefault();
                    MemoryStream msSignatureOFEducationalExperts = new MemoryStream(arraySignatureOFEducationalExperts);
                    System.Drawing.Image imageSignatureOFEducationalExperts = System.Drawing.Image.FromStream(msSignatureOFEducationalExperts);
                    mainReport["SignatureOFEducationalExperts"] = imageSignatureOFEducationalExperts;


                    //ارسال دیتا به گزارش ساز را انجام می دهد
                    //1400 12 23 ADD COMMENT
                    Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                    //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);

                    string Todaydate = _General.CurrentPersianDate().Replace("/", "");
                    string fileName = _PlacementTabJobTraining.EmployemeName + "-" + _PlacementTabJobTraining.UnitDepartmentSection;
                    string folderPath = Server.MapPath("~/Files/" + "/" + Todaydate + "-OjT Report" + "/");

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }


                    //Save the File to the Directory (Folder).
                    // Stimulsoft.Report.Export.StiExportSettings stiExportSettings = { mainReport.re };
                    mainReport.ExportDocument(StiExportFormat.ImagePng, folderPath + fileName + ".Png");

                    //mainReport.ExportDocument((StiExportFormat.ImagePng, folderPath + fileName + ".Png",new Stimulsoft.Report.Export.StiExportSettings{);
                    //Display the success message.

                }
            }

            return RedirectToAction("Index", new { id = ID });
        }

        public ActionResult ViewerEvent()
        {
            try
            {
                //return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
                return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(PlacementTabJobTrainingEntity Current)
        {
            try
            {
                int result;
                result = _PlacementTabJobTrainingProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(PlacementTabJobTrainingEntity Current)
        {
            try
            {
                bool result;
                result = _PlacementTabJobTrainingProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, _CustomAuthorizeAttribute.UserId(), "", "", Current.PlacementTabJobTrainingDateId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _PlacementTabJobTrainingProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListPlacementTabJobTraining(int ID)
        {
            try
            {
                var list = _PlacementTabJobTrainingProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListPlacementTabJobTraining");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult CopyDataPlacementTabJob(int ID)
        {
            try
            {
                //bool result;
                //result = _InventoryjobProvider.CopyDataInventoryjob(ID);
                //return this.Json(result, JsonRequestBehavior.AllowGet);

                bool result;
                result = _PlacementTabJobTrainingProvider.CopyDataPlacementTabJob(ID);
                return Json(result);
            }

            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "CopyDataInventoryjob");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //1401 01 27

        [HttpPost]
        public ActionResult _GetListPlacementTabJobTraining(PlacementTabJobTrainingSearch placementtabjobtrainingsearch, int ID)
        {
            try
            {
                #region set null to string.Empty
                if (placementtabjobtrainingsearch.EmployemeName == null)
                    placementtabjobtrainingsearch.EmployemeName = string.Empty;
                #endregion

                List<PlacementTabJobTrainingEntity> _PlacementTabJobTrainingEntity = new List<PlacementTabJobTrainingEntity>();
                if (placementtabjobtrainingsearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    _PlacementTabJobTrainingEntity = _PlacementTabJobTrainingProvider.GetAll(ID).ToList();
                    return View(_PlacementTabJobTrainingEntity);
                }
                else if (
                   placementtabjobtrainingsearch.EmployemeName.Trim() == "" &&
                   placementtabjobtrainingsearch.UnitSCenterId == 0 &&
                    placementtabjobtrainingsearch.SectionId == 0 && placementtabjobtrainingsearch.DepartmentId == 0 &&
                   placementtabjobtrainingsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    _PlacementTabJobTrainingEntity = _PlacementTabJobTrainingProvider.GetAll(ID).ToList();
                    return View(_PlacementTabJobTrainingEntity);
                }
                else if (placementtabjobtrainingsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    _PlacementTabJobTrainingEntity = _PlacementTabJobTrainingProvider.GetAll(placementtabjobtrainingsearch, ID).ToList();
                }


                List<PlacementTabJobTrainingEntity> _PlacementTabJobTrainingEntityDistinct = new List<PlacementTabJobTrainingEntity>();
                foreach (PlacementTabJobTrainingEntity item in _PlacementTabJobTrainingEntity)
                {
                    int count = _PlacementTabJobTrainingEntityDistinct.Count(a => a.EmployemeId == item.EmployemeId);
                    if (count == 0)
                        _PlacementTabJobTrainingEntityDistinct.Add(item);
                }
                TempData["ListPlacementTabJobTrainingEntity"] = _PlacementTabJobTrainingEntityDistinct;
                return View(_PlacementTabJobTrainingEntityDistinct);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListPlacementTabJobTraining");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }


    }
}