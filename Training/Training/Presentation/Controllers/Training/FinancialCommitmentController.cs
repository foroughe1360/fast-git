using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using InterfaceEntity.Search.Trianing;
using Presentation.Utility;
using static Bussiness.General;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;
using System.Data;
using Stimulsoft.Report.Export;
using Stimulsoft.Report.Web;
using  Bussiness;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "25")]
    public class FinancialCommitmentController : Controller
    {
        private FinancialCommitmentProvider _FinancialCommitmentProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;



        public FinancialCommitmentController()
        {

            //StiMvcViewer.CacheHelper = new StiMyCacheHelper();

            _FinancialCommitmentProvider = new FinancialCommitmentProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: FinancialCommitment
        public ActionResult Index()//int ID)
        {
            try
            {
                //ViewBag.TrainingCourseId = ID;
                var list = _FinancialCommitmentProvider.GetAll().ToList();
                //var list = _FinancialCommitmentProvider.GetAll(ID).ToList();

                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }


        public ActionResult Create()
        {
            try
            {
                //نام دوره آموزشی
                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                ViewBag.TrainingCourseId = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //نام مکان برگزاری
                ViewBag.TableInterfaceIdTrainingVenue = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TrainingVenue), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);


                //DesignTrainingCourseProvider _DesignTrainingCourseProvider = new DesignTrainingCourseProvider();
                //DesignTrainingCourseEntity _DesignTrainingCourseEntity = new DesignTrainingCourseEntity();
                ////زمان برگزاری
                //ViewBag.DesignTrainingCourseDateId = new SelectList(_DesignTrainingCourseProvider.GetDesignTrainingCourseList(), "DesignTrainingCourseId", "TookHold", _DesignTrainingCourseEntity.DesignTrainingCourseDateId);


                //نام کارمند
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                //ViewBag.EmployemesId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemesName", _EmployemeEntity.EmployemeId);
                ViewBag.EmployemesId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                //نام دوره آموزشی
                ViewBag.TrainingCourseIdTemp = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                //نام مکان برگزاری
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceIdTrainingVenue = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TrainingVenue), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //نام کارمند
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                //ViewBag.EmployemesIdTemp = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemesName", _EmployemeEntity.EmployemeId);
                ViewBag.EmployemesId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                return View(_FinancialCommitmentProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReport(int ID)
        {
            try
            {
                General _General = new General();

                FinancialCommitmentEntity _FinancialCommitmentEntity = new FinancialCommitmentEntity();
                _FinancialCommitmentEntity = _FinancialCommitmentProvider.GetFinancialCommitment(ID);
                _FinancialCommitmentEntity.AmountPiercedStr = _General.ToFullyAlphabetical((Int64)_FinancialCommitmentEntity.AmountPierced, CurrencyUnits.Rial);

                //_FinancialCommitmentEntity.TookHoldStr=  _General.PersianDate(_FinancialCommitmentEntity.TookHoldStr);

                //if (_General.shamsiYear(_FinancialCommitmentEntity.TookHold) == "1131") {}

                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/FinancialCommitment.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("FinancialCommitment_business", _FinancialCommitmentEntity);

                //StiReportResponse.PrintAsPdf(mainReport);
                //1400 12 23 ADD COMMENT
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult ViewerEvent()
        {
            try
            {
                //return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
                return StiMvcViewer.ViewerEventResult();

            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(FinancialCommitmentEntity Current)
        {
            try
            {
                int result;
                result = _FinancialCommitmentProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.FinancialCommitment, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        [HttpPost]
        public ActionResult Edit(FinancialCommitmentEntity Current)
        {
            try
            {
                bool result;
                result = _FinancialCommitmentProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.FinancialCommitment, _CustomAuthorizeAttribute.UserId(), "", "", Current.FinancialCommitmentId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _FinancialCommitmentProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.FinancialCommitment, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListFinancialCommitment()
        {
            try
            {
                var list = _FinancialCommitmentProvider.GetAll().ToList();
                //var list = _FinancialCommitmentProvider.GetAll(ID).ToList();

                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FinancialCommitment, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListFinancialCommitment");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult _GetListFinancialCommitment(FinancialCommitmentSearch financialcommitmentsearch)//int EmployemeId)
        {
            try
            {
                #region set null to string.Empty
                if (financialcommitmentsearch.EmployemesName == null)
                    financialcommitmentsearch.EmployemesName = string.Empty;
                #endregion
                List<FinancialCommitmentEntity> listFinancialCommitmentEntity = new List<FinancialCommitmentEntity>();

                if (financialcommitmentsearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    listFinancialCommitmentEntity = _FinancialCommitmentProvider.GetAll().ToList();
                    View(listFinancialCommitmentEntity);
                }
                else if (
                   financialcommitmentsearch.EmployemesName.Trim() == "" 
                   && financialcommitmentsearch.CheckFinancialCommitment == -1
                   && financialcommitmentsearch.State == -1
                   && financialcommitmentsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    listFinancialCommitmentEntity = _FinancialCommitmentProvider.GetAll().ToList();
                    View(listFinancialCommitmentEntity);
                }
                else if (financialcommitmentsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    listFinancialCommitmentEntity = _FinancialCommitmentProvider.GetAll(financialcommitmentsearch).ToList();
                    View(listFinancialCommitmentEntity);
                }

                var listFinancialCommitment = listFinancialCommitmentEntity.OrderBy(a => a.EmployemeId);
                return View(listFinancialCommitment);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public class StiMyCacheHelper : StiCacheHelper
        {
            //public override StiReport GetReport(string guid)
            //{
            //    string path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/"), "CacheFiles", guid);

            //    if (System.IO.File.Exists(path))

            //    {

            //        StiReport report = new StiReport();

            //        string packedReport = System.IO.File.ReadAllText(path);

            //        if (guid.EndsWith("template")) report.LoadPackedReportFromString(packedReport);

            //        else report.LoadPackedDocumentFromString(packedReport);

            //        return report;
            //    }
            //    return null;
            //    //return base.GetReport(guid);

            //}

            //public override void SaveReport(StiReport report, string guid)
            //{

            //    string packedReport = guid.EndsWith("template") ? report.SavePackedReportToString() : report.SavePackedDocumentToString();

            //    string path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/"), "CacheFiles", guid);

            //    System.IO.File.WriteAllText(path, packedReport);

            //    //base.SaveReport(report, guid);

            //}

        }


    }
}