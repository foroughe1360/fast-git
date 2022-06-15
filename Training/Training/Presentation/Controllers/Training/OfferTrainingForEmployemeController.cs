using Bussiness;
using Bussiness.Provider;
using Bussiness.Provider.Training;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using InterfaceEntity.Search.Trianing;
using Microsoft.AspNetCore.Routing;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Presentation.Controllers.Training
{
    public class OfferTrainingForEmployemeController : Controller
    {
        // GET: OfferTrainingForEmployeme

        private OfferTrainingForEmployemeProvider _OfferTrainingForEmployemeProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public OfferTrainingForEmployemeController()
        {
            _OfferTrainingForEmployemeProvider = new OfferTrainingForEmployemeProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: OfferTrainingForEmployeme
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.ReportNameId = (int)ReportName.ReportNames.OfferTrainingForEmployeme;
                ViewBag.OfferTrainingForEmployeeDateId = ID;
                var list = _OfferTrainingForEmployemeProvider.GetAll(ID).ToList();

                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Create()
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //عنوان شغل
                PostGroupProvider _PostGroupProvider = new PostGroupProvider();
                PostGroupEntity _PostGroupEntity = new PostGroupEntity();
                ViewBag.PostGroupId = new SelectList(_PostGroupProvider.GetAll(), "PostGroupId", "PostGroupName", _PostGroupEntity.PostGroupId);

                ////نام کارمند
                //EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                //EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                //ViewBag.EmployemeId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);


                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdUnitSCenterTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //عنوان شغل
                PostGroupProvider _PostGroupProvider = new PostGroupProvider();
                PostGroupEntity _PostGroupEntity = new PostGroupEntity();
                ViewBag.PostGroupIdTemp = new SelectList(_PostGroupProvider.GetAll(), "PostGroupId", "PostGroupName", _PostGroupEntity.PostGroupId);

                //نام کارمند
                //EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                //EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                //ViewBag.EmployemeId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                return View(_OfferTrainingForEmployemeProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        //ساختن یک ویو برای صفحه گزارش گیری
        public ActionResult Print()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        //کار ارسال دیتا به گزارش ساز را انجام می دهد
        public ActionResult StiReport(int ID)
        {
            try
            {
                General _General = new General();
                var _PostReport = _OfferTrainingForEmployemeProvider.GetPostReport(ID);
                _PostReport.DateNeedStr = _General.MiladiToShamsi(_PostReport.DateNeed);
                int employemeid = _PostReport.EmployemeId;

                //نمایش تاریخ تایید و تهیه و تصویب
                SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                int ReportNameId = (int)ReportName.ReportNames.OfferTrainingForEmployeme;
                var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);
                _PostReport.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                _PostReport.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                _PostReport.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
                //

                DetailOfferTrainingForEmployemeProvider _DetailOfferTrainingForEmployemeProvider = new DetailOfferTrainingForEmployemeProvider();
                var _DetailOfferTrainingForEmployemeReport = _DetailOfferTrainingForEmployemeProvider.GetDetailOfferTrainingForEmployemeReport(ID).ToList();

                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/OfferTrainingForEmployeme.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("PostReportEmployeme_business", _PostReport);
                mainReport.RegBusinessObject("DetailOfferTrainingForEmployeme_business", _DetailOfferTrainingForEmployemeReport);
                // 

                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();
                // mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;
                //اسم راهبر تیم آموزش 
                //mainReport["Teamleadertraining"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.Teamleadertraining).Specifications;

                //نمایش امضاء
                //add New 990618
                EmployemeSignaturyProvider employemesignaturyprovider = new EmployemeSignaturyProvider();
                var GetEmployemeSOfSignatory = employemesignaturyprovider.GetListEmployemeSignatury().ToList();
                mainReport["HeadOfTrainingAndInformation"] = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Select(a=>a.Specifications).FirstOrDefault();

                byte[] arraySignature = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Select(a => a.Signature).FirstOrDefault();
                MemoryStream ms = new MemoryStream(arraySignature);
                System.Drawing.Image imageSignature = System.Drawing.Image.FromStream(ms);
                mainReport["SignatureOFHeadOfTrainingAndInformation"] = imageSignature;

                //اسم راهبر تیم آموزش
                mainReport["Teamleadertraining"] = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.Teamleadertraining).Select(a => a.Specifications).FirstOrDefault();
                //امضاء راهبر تیم آموزش

                byte[] arraySignatureOFTeamleadertraining = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.Teamleadertraining).Select(a => a.Signature).FirstOrDefault(); ;
                MemoryStream msSignatureOFTeamleadertraining = new MemoryStream(arraySignatureOFTeamleadertraining);
                System.Drawing.Image imageSignatureOFTeamleadertraining = System.Drawing.Image.FromStream(msSignatureOFTeamleadertraining);
                mainReport["SignatureOFTeamleadertraining"] = imageSignatureOFTeamleadertraining;

                //امضاء مدیر /مدیر فنی /سرپرست 
                //var arraySignatureOFManger = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.Manger).Select(a => a.Signature).FirstOrDefault();
                //MemoryStream msSignatureOFManger = new MemoryStream(arraySignatureOFManger);
                //System.Drawing.Image imageSignatureOFManger = System.Drawing.Image.FromStream(msSignatureOFManger);
                //mainReport["SignatureOFManger"] = imageSignatureOFManger;


                var arraySignatureOFManger = employemesignaturyprovider.GetEmployemeMangerSignatury(employemeid).ToList().Select(a => a.Signature).FirstOrDefault();
                MemoryStream msSignatureOFManger = new MemoryStream(arraySignatureOFManger);
                System.Drawing.Image imageSignatureOFManger = System.Drawing.Image.FromStream(msSignatureOFManger);
                mainReport["SignatureOFManger"] = imageSignatureOFManger;


                //
                //ارسال دیتا به گزارش ساز را انجام می دهد
                //1400 12 23 ADD COMMENT
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);

            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(OfferTrainingForEmployemeEntity Current)
        {
            try
            {
                int result;
                result = _OfferTrainingForEmployemeProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.OfferTrainingForJob, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(OfferTrainingForEmployemeEntity Current)
        {
            try
            {
                bool result;
                result = _OfferTrainingForEmployemeProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, _CustomAuthorizeAttribute.UserId(), "", "", Current.OfferTrainingForEmployemeId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _OfferTrainingForEmployemeProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //[HttpGet]
        //public ActionResult _GetListOfferTrainingForEmployeme(int ID)
        //{
        //    try
        //    {
        //        var list = _OfferTrainingForEmployemeProvider.GetAll(ID).ToList();
        //        return View(list);
        //    }
        //    catch (Exception e)
        //    {
        //        LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListOfferTrainingForEmployeme");
        //        _LogErrorProvider.Add(logerrorentity);
        //        return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
        //    }
        //}

        [HttpPost]
        public ActionResult _GetListOfferTrainingForEmployeme(DetailoffertrainingforemployemeSearch detailoffertrainingforemployemesearch)
        {
            try
            {
                #region set null to string.Empty
                if (detailoffertrainingforemployemesearch.NeedTraining == null)
                    detailoffertrainingforemployemesearch.NeedTraining = string.Empty;
                #endregion

                List<OfferTrainingForEmployemeEntity> _OfferTrainingForEmployemeEntity = new List<OfferTrainingForEmployemeEntity>();
                if (detailoffertrainingforemployemesearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    var list = _OfferTrainingForEmployemeProvider.GetAll(detailoffertrainingforemployemesearch.OfferTrainingForEmployeeDateId).ToList();
                    return View(list);
                }

                else if (detailoffertrainingforemployemesearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    _OfferTrainingForEmployemeEntity = _OfferTrainingForEmployemeProvider.GetAll(detailoffertrainingforemployemesearch).ToList();
                }

                List<OfferTrainingForEmployemeEntity> _OfferTrainingForEmployemeEntityDistinct = new List<OfferTrainingForEmployemeEntity>();
                foreach (OfferTrainingForEmployemeEntity item in _OfferTrainingForEmployemeEntity)
                {
                    _OfferTrainingForEmployemeEntityDistinct.Add(item);
                }

                return View(_OfferTrainingForEmployemeEntityDistinct);
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