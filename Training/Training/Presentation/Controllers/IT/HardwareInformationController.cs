using Bussiness;
using Bussiness.Provider;
using InterfaceEntity;
using InterfaceEntity.Report;
using InterfaceEntity.Search.BasicInformation;
using InterfaceEntity.Search.IT;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.IT
{
    public class HardwareInformationController : Controller
    {
        private HardwareInformationProvider _HardwareInformationProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public HardwareInformationController()
        {
            _HardwareInformationProvider = new HardwareInformationProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: HardwareInformation
        public ActionResult Index()
        {
            try
            {
                var list = _HardwareInformationProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareInformation, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // GET: HardwareInformation/Create
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

                //نام تجهیز
                HardwareEquipmentProvider _HardwareEquipmentProvider = new HardwareEquipmentProvider();
                HardwareEquipmentEntity _HardwareEquipmentEntity = new HardwareEquipmentEntity();
                ViewBag.TableInterfaceValueIdHardwareEquipmentId = new SelectList(_HardwareEquipmentProvider.GetAll(), "HardwareEquipmentId", "EquipmentName", _HardwareEquipmentEntity.HardwareEquipmentId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareInformation, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // GET: HardwareInformation/Edit/5
        public ActionResult Edit(int ID)
        {
            try
            {

                /*
                 wrap it up
                 what is your brith order
                 we are 2 years apart

                 */
                //TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                //TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdUnitSCenterTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);


                //عنوان شغل
                PostGroupProvider _PostGroupProvider = new PostGroupProvider();
                PostGroupEntity _PostGroupEntity = new PostGroupEntity();
                ViewBag.PostGroupId = new SelectList(_PostGroupProvider.GetAll(), "PostGroupId", "PostGroupName", _PostGroupEntity.PostGroupId);

                //نام تجهیز
                HardwareEquipmentProvider _HardwareEquipmentProvider = new HardwareEquipmentProvider();
                HardwareEquipmentEntity _HardwareEquipmentEntity = new HardwareEquipmentEntity();
                ViewBag.HardwareEquipmentId = new SelectList(_HardwareEquipmentProvider.GetAll(), "HardwareEquipmentId", "EquipmentName", _HardwareEquipmentEntity.HardwareEquipmentId);

                return View(_HardwareInformationProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareInformation, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
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

        public ActionResult StiReport()//int ID)
        {
            try
            {
                General _General = new General();
                //List<HardwareInformationReport> ListHardwareInformationReport = new List<HardwareInformationReport>();

                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                EmployemeJobProvider _EmployemeJobProvider = new EmployemeJobProvider();
                List<HardwareInformationEntity> hardwareinformationentityList = (List<HardwareInformationEntity>)TempData["hardwareinformationentity"];
                if (TempData["hardwareinformationentity"] == null)
                {
                    hardwareinformationentityList = _HardwareInformationProvider.GetAll().ToList();
                }
                foreach (var hardwareinformationentity in hardwareinformationentityList)
                {
                    hardwareinformationentity.DeliveryDateStr = _General.MiladiToShamsi(hardwareinformationentity.DeliveryDate);
                }
                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/HardwareInformationReport.mrt"));
                // 
                mainReport.Compile();
//                hardwareinformationentity.de = _General.MiladiToShamsi(_PostReport.DateNeed);
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("HardwareInformation_business", hardwareinformationentityList);
                // 

                mainReport["EducationalExperts"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Specifications;
                mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;

                //نمایش امضاء
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }

        }

        // POST: HardwareInformation/Create
        [HttpPost]
        public ActionResult Create(HardwareInformationEntity Current)
        {
            try
            {
                int result;
                result = _HardwareInformationProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.HardwareInformation, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareInformation, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // POST: HardwareInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(HardwareInformationEntity Current)
        {
            try
            {
                bool result;                
                General _General = new General();
                Current.DeliveryDate = _General.ShamsiToMiladi(Current.DeliveryDate);
                result = _HardwareInformationProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.HardwareInformation, _CustomAuthorizeAttribute.UserId(), "", "", Current.HardwareInformationId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareInformation, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // POST: HardwareInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                bool result;
                result = _HardwareInformationProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.HardwareInformation, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareInformation, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListHardwareInformation(HardwareInformationSearch hardwareinformationsearch)
        {
            try
            {
                #region set null to string.Empty
                if (hardwareinformationsearch.HardwareEquipmentName == null)
                    hardwareinformationsearch.HardwareEquipmentName = string.Empty;

                if (hardwareinformationsearch.EmployemeName == null)
                    hardwareinformationsearch.EmployemeName = string.Empty;

                if (hardwareinformationsearch.NetworkIP == null)
                    hardwareinformationsearch.NetworkIP = string.Empty;
                #endregion

                List<HardwareInformationEntity> _HardwareInformationEntity = new List<HardwareInformationEntity>();
                if (hardwareinformationsearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    _HardwareInformationEntity = _HardwareInformationProvider.GetAll().ToList();
                    if (_HardwareInformationEntity.Count > 0)
                    {
                        TempData["hardwareinformationentity"] = _HardwareInformationEntity;
                        //return View(_HardwareInformationEntity);
                    }
                }
                else if (hardwareinformationsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    _HardwareInformationEntity = _HardwareInformationProvider.GetAll(hardwareinformationsearch).ToList();
                    if (_HardwareInformationEntity.Count > 0)
                    {
                        TempData["hardwareinformationentity"] = _HardwareInformationEntity;
                    }
                }

                List<HardwareInformationEntity> _HardwareInformationEntityDistinct = new List<HardwareInformationEntity>();
                foreach (HardwareInformationEntity item in _HardwareInformationEntity)
                {
                    _HardwareInformationEntityDistinct.Add(item);
                }
                TempData["hardwareinformationentity"] = _HardwareInformationEntityDistinct;
                return View(_HardwareInformationEntityDistinct);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareInformation, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTeacher");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}
