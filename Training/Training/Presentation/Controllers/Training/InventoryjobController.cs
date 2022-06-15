using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using InterfaceEntity.Report.Training.ListCommunityOrganization;
using System.IO;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "26")]
    public class InventoryjobController : Controller
    {
        private InventoryjobProvider _InventoryjobProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public InventoryjobController()
        {
            _InventoryjobProvider = new InventoryjobProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        // GET: Inventoryjob
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


                var list = _InventoryjobProvider.GetAll().ToList();
                ViewBag.ReportNameId = (int)ReportName.ReportNames.Inventoryjobs;

                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
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

                ListResponsibilitiePowerEntity listresponsibilitiepowerentity = new ListResponsibilitiePowerEntity();
                ListResponsibilitiePowerProvider listresponsibilitiepowerprovider = new ListResponsibilitiePowerProvider();

                //واحد 
                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //فهرست مسئولیت ها و اختیارات  
                ViewBag.ListResponsibilitiePower = new SelectList(listresponsibilitiepowerprovider.GetAll(), "ListResponsibilitiePowerId", "PostGroupName", listresponsibilitiepowerentity.PostGroupName);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
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

                ListResponsibilitiePowerEntity listresponsibilitiepowerentity = new ListResponsibilitiePowerEntity();
                ListResponsibilitiePowerProvider listresponsibilitiepowerprovider = new ListResponsibilitiePowerProvider();

                //واحد 
                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                //فهرست مسئولیت ها و اختیارات  
                ViewBag.ListResponsibilitiePower = new SelectList(listresponsibilitiepowerprovider.GetAll(), "ListResponsibilitiePowerId", "PostGroupName", listresponsibilitiepowerentity.PostGroupName);

                var item = _InventoryjobProvider.GetInventoryjob(ID);

                ViewBag.DepartmentId = item.DepartmentId;
                ViewBag.DepartmentName = item.DepartmentName;
                ViewBag.SectionId = item.SectionId;
                ViewBag.SectionName = item.SectionName;

                return View(item);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        public ActionResult StiReport(int ID)
        {
            try
            {
                General _General = new General();

                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                InventoryjobsReport _InventoryjobsReport = new InventoryjobsReport();
                _InventoryjobsReport = _InventoryjobProvider.GetInventoryjobsReport(ID);

                //نمایش تاریخ تایید و تهیه و تصویب
                SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                int ReportNameId = (int)ReportName.ReportNames.Inventoryjobs;
                var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);
                _InventoryjobsReport.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                _InventoryjobsReport.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                _InventoryjobsReport.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
                //

                if (_InventoryjobsReport.NumberEmployees == 1)
                {
                    _InventoryjobsReport.OnePerson = true;
                    _InventoryjobsReport.MoreThanOnePerson = false;
                }
                else
                {
                    _InventoryjobsReport.OnePerson = false;
                    _InventoryjobsReport.MoreThanOnePerson = true;
                }

                ListHealthConditionProvider _ListHealthConditionProvider = new ListHealthConditionProvider();
                var _ListHealthConditionEntity = _ListHealthConditionProvider.GetAll(ID).ToList();

                ListPhysicalConditionProvider _ListPhysicalConditionProvider = new ListPhysicalConditionProvider();
                var _ListPhysicalConditionEntity = _ListPhysicalConditionProvider.GetAll(ID);
                foreach (ListPhysicalConditionEntity item in _ListPhysicalConditionEntity)
                {
                    if (item.ListPhysicalConditionsState)
                    {
                        switch (item.PhysicalConditionsId)
                        {
                            case (int)ListPhysicalConditionEntity.ListPhysicalCondition.FullHealth:
                                _InventoryjobsReport.FullHealth = true;
                                break;

                            case (int)ListPhysicalConditionEntity.ListPhysicalCondition.OtherPhysicalConditionsAcceptable:
                                _InventoryjobsReport.OtherPhysicalConditionsAcceptable = true;
                                break;
                        }
                    }
                }

                ListAbilityRequiredJobProvider _ListAbilityRequiredJobProvider = new ListAbilityRequiredJobProvider();
                ListAbilityRequiredJobReport _ListAbilityRequiredJobReport = new ListAbilityRequiredJobReport();
                var list = _ListAbilityRequiredJobProvider.GetAll(ID).ToList();
                foreach (ListAbilityRequiredJobEntity item in list)
                {
                    if (item.ListAbilityRequiredJobState)
                    {
                        switch (item.AbilityRequiredJobId)
                        {
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.ConflictManagement:
                                _ListAbilityRequiredJobReport.ConflictManagement = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.CrisisManagement:
                                _ListAbilityRequiredJobReport.CrisisManagement = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.EffectiveCommunications:
                                _ListAbilityRequiredJobReport.EffectiveCommunications = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.Leadership:
                                _ListAbilityRequiredJobReport.Leadership = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.OtherCases:
                                _ListAbilityRequiredJobReport.OtherCases = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.PresentationAndLecturing:
                                _ListAbilityRequiredJobReport.PresentationAndLecturing = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.TeamWork:
                                _ListAbilityRequiredJobReport.TeamWork = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.TheSessions:
                                _ListAbilityRequiredJobReport.TheSessions = true;
                                break;

                        }
                    }
                }

                ListTrainingRequiredProvider _ListTrainingRequiredProvider = new ListTrainingRequiredProvider();
                var _ListTrainingRequiredEntity = _ListTrainingRequiredProvider.GetAll(ID).ToList();

                ListCommunityOrganizationProvider _ListCommunityOrganizationProvider = new ListCommunityOrganizationProvider();
                var ListCommunityOrganizationProvider = _ListCommunityOrganizationProvider.GetAll(ID).ToList();

                //ارتباطلات بالادست
                UpstreamCommunicationReport _UpstreamCommunicationReport = new UpstreamCommunicationReport();
                var _UpstreamCommunication = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.UpstreamCommunications).ToList();
                foreach (ListCommunityOrganizationEntity item in _UpstreamCommunication)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _UpstreamCommunicationReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _UpstreamCommunicationReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _UpstreamCommunicationReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _UpstreamCommunicationReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _UpstreamCommunicationReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _UpstreamCommunicationReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _UpstreamCommunicationReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _UpstreamCommunicationReport.Other = true;
                            break;
                    }
                }

                //ارتباطات برون سازمانی
                ExternalCommunicationReport _ExternalCommunicationReport = new ExternalCommunicationReport();
                var _ExternalCommunication = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.ExternalCommunication).ToList();
                foreach (ListCommunityOrganizationEntity item in _ExternalCommunication)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _ExternalCommunicationReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _ExternalCommunicationReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _ExternalCommunicationReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _ExternalCommunicationReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _ExternalCommunicationReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _ExternalCommunicationReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _ExternalCommunicationReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _ExternalCommunicationReport.Other = true;
                            break;
                    }
                }

                // ارتباطات هم ردیف
                CommunicationRowReport _CommunicationRowReport = new CommunicationRowReport();
                var _CommunicationRow = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.CommunicationRow).ToList();
                foreach (ListCommunityOrganizationEntity item in _CommunicationRow)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _CommunicationRowReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _CommunicationRowReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _CommunicationRowReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _CommunicationRowReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _CommunicationRowReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _CommunicationRowReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _CommunicationRowReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _CommunicationRowReport.Other = true;
                            break;
                    }
                }

                //ارتباطات پایین دست
                DownstreamCommunicationReport _DownstreamCommunicationReport = new DownstreamCommunicationReport();
                var _DownstreamCommunication = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.DownstreamCommunications).ToList();
                foreach (ListCommunityOrganizationEntity item in _DownstreamCommunication)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _DownstreamCommunicationReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _DownstreamCommunicationReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _DownstreamCommunicationReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _DownstreamCommunicationReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _DownstreamCommunicationReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _DownstreamCommunicationReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _DownstreamCommunicationReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _DownstreamCommunicationReport.Other = true;
                            break;
                    }
                }


                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/Inventoryjobs.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("Inventoryjobs_business", _InventoryjobsReport);
                mainReport.RegBusinessObject("ListHealthConditions_business", _ListHealthConditionEntity);
                mainReport.RegBusinessObject("ListAbilityRequiredJob_business", _ListAbilityRequiredJobReport);
                mainReport.RegBusinessObject("ListTrainingRequired_business", _ListTrainingRequiredEntity);

                mainReport.RegBusinessObject("UpstreamCommunication_business", _UpstreamCommunicationReport);
                mainReport.RegBusinessObject("ExternalCommunication_business", _ExternalCommunicationReport);
                mainReport.RegBusinessObject("CommunicationRow_business", _CommunicationRowReport);
                mainReport.RegBusinessObject("DownstreamCommunication_business", _DownstreamCommunicationReport);

                //mainReport["PostGroupName"] = _InventoryjobsReport.PostGroupName;
                //mainReport["EducationalExperts"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Specifications;
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

                // 
                //ارسال دیتا به گزارش ساز را انجام می دهد
                //1400 12 23 ADD COMMENT
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);

            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        public ActionResult StiReportPdfFile(int ID)
        {
            try
            {
                List<EmployemeEntity> ListEmployemeEntity = (List<EmployemeEntity>)TempData["ListEmployemeEntity"];
                if (TempData["ListEmployemeEntity"] != null)
                {
                    RedirectToAction("Print", "BasicInformation");
                    foreach (var listemployemeentity in ListEmployemeEntity)
                    {
                        ID = listemployemeentity.EmployemeId;
                    }
                }

                General _General = new General();
                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();

                InventoryjobsReport _InventoryjobsReport = new InventoryjobsReport();
                _InventoryjobsReport = _InventoryjobProvider.GetInventoryjobsReport(ID);

                //نمایش تاریخ تایید و تهیه و تصویب
                SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                int ReportNameId = (int)ReportName.ReportNames.Inventoryjobs;
                var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);
                _InventoryjobsReport.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                _InventoryjobsReport.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                _InventoryjobsReport.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
                //

                if (_InventoryjobsReport.NumberEmployees == 1)
                {
                    _InventoryjobsReport.OnePerson = true;
                    _InventoryjobsReport.MoreThanOnePerson = false;
                }
                else
                {
                    _InventoryjobsReport.OnePerson = false;
                    _InventoryjobsReport.MoreThanOnePerson = true;
                }

                ListHealthConditionProvider _ListHealthConditionProvider = new ListHealthConditionProvider();
                var _ListHealthConditionEntity = _ListHealthConditionProvider.GetAll(ID).ToList();

                ListPhysicalConditionProvider _ListPhysicalConditionProvider = new ListPhysicalConditionProvider();
                var _ListPhysicalConditionEntity = _ListPhysicalConditionProvider.GetAll(ID);
                foreach (ListPhysicalConditionEntity item in _ListPhysicalConditionEntity)
                {
                    if (item.ListPhysicalConditionsState)
                    {
                        switch (item.PhysicalConditionsId)
                        {
                            case (int)ListPhysicalConditionEntity.ListPhysicalCondition.FullHealth:
                                _InventoryjobsReport.FullHealth = true;
                                break;

                            case (int)ListPhysicalConditionEntity.ListPhysicalCondition.OtherPhysicalConditionsAcceptable:
                                _InventoryjobsReport.OtherPhysicalConditionsAcceptable = true;
                                break;
                        }
                    }
                }

                ListAbilityRequiredJobProvider _ListAbilityRequiredJobProvider = new ListAbilityRequiredJobProvider();
                ListAbilityRequiredJobReport _ListAbilityRequiredJobReport = new ListAbilityRequiredJobReport();
                var list = _ListAbilityRequiredJobProvider.GetAll(ID).ToList();
                foreach (ListAbilityRequiredJobEntity item in list)
                {
                    if (item.ListAbilityRequiredJobState)
                    {
                        switch (item.AbilityRequiredJobId)
                        {
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.ConflictManagement:
                                _ListAbilityRequiredJobReport.ConflictManagement = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.CrisisManagement:
                                _ListAbilityRequiredJobReport.CrisisManagement = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.EffectiveCommunications:
                                _ListAbilityRequiredJobReport.EffectiveCommunications = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.Leadership:
                                _ListAbilityRequiredJobReport.Leadership = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.OtherCases:
                                _ListAbilityRequiredJobReport.OtherCases = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.PresentationAndLecturing:
                                _ListAbilityRequiredJobReport.PresentationAndLecturing = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.TeamWork:
                                _ListAbilityRequiredJobReport.TeamWork = true;
                                break;
                            case (int)ListAbilityRequiredJobEntity.ListAbilityRequiredJob.TheSessions:
                                _ListAbilityRequiredJobReport.TheSessions = true;
                                break;

                        }
                    }
                }

                ListTrainingRequiredProvider _ListTrainingRequiredProvider = new ListTrainingRequiredProvider();
                var _ListTrainingRequiredEntity = _ListTrainingRequiredProvider.GetAll(ID).ToList();

                ListCommunityOrganizationProvider _ListCommunityOrganizationProvider = new ListCommunityOrganizationProvider();
                var ListCommunityOrganizationProvider = _ListCommunityOrganizationProvider.GetAll(ID).ToList();

                //ارتباطلات بالادست
                UpstreamCommunicationReport _UpstreamCommunicationReport = new UpstreamCommunicationReport();
                var _UpstreamCommunication = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.UpstreamCommunications).ToList();
                foreach (ListCommunityOrganizationEntity item in _UpstreamCommunication)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _UpstreamCommunicationReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _UpstreamCommunicationReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _UpstreamCommunicationReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _UpstreamCommunicationReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _UpstreamCommunicationReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _UpstreamCommunicationReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _UpstreamCommunicationReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _UpstreamCommunicationReport.Other = true;
                            break;
                    }
                }

                //ارتباطات برون سازمانی
                ExternalCommunicationReport _ExternalCommunicationReport = new ExternalCommunicationReport();
                var _ExternalCommunication = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.ExternalCommunication).ToList();
                foreach (ListCommunityOrganizationEntity item in _ExternalCommunication)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _ExternalCommunicationReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _ExternalCommunicationReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _ExternalCommunicationReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _ExternalCommunicationReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _ExternalCommunicationReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _ExternalCommunicationReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _ExternalCommunicationReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _ExternalCommunicationReport.Other = true;
                            break;
                    }
                }

                // ارتباطات هم ردیف
                CommunicationRowReport _CommunicationRowReport = new CommunicationRowReport();
                var _CommunicationRow = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.CommunicationRow).ToList();
                foreach (ListCommunityOrganizationEntity item in _CommunicationRow)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _CommunicationRowReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _CommunicationRowReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _CommunicationRowReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _CommunicationRowReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _CommunicationRowReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _CommunicationRowReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _CommunicationRowReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _CommunicationRowReport.Other = true;
                            break;
                    }
                }

                //ارتباطات پایین دست
                DownstreamCommunicationReport _DownstreamCommunicationReport = new DownstreamCommunicationReport();
                var _DownstreamCommunication = ListCommunityOrganizationProvider.Where(a => a.CommunicationOrganizationId == (int)ListCommunityOrganizationEntity.CommunicationOrganization.DownstreamCommunications).ToList();
                foreach (ListCommunityOrganizationEntity item in _DownstreamCommunication)
                {
                    switch (item.CommunityOrganizationsId)
                    {
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Facetoface:
                            _DownstreamCommunicationReport.Facetoface = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.written:
                            _DownstreamCommunicationReport.written = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.AutomationAndNetwork:
                            _DownstreamCommunicationReport.AutomationAndNetwork = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Phone:
                            _DownstreamCommunicationReport.Phone = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.SmsAndMobile:
                            _DownstreamCommunicationReport.SmsAndMobile = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Email:
                            _DownstreamCommunicationReport.Email = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Session:
                            _DownstreamCommunicationReport.Session = true;
                            break;
                        case (int)ListCommunityOrganizationEntity.ListCommunityOrganization.Other:
                            _DownstreamCommunicationReport.Other = true;
                            break;
                    }
                }


                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/Inventoryjobs.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("Inventoryjobs_business", _InventoryjobsReport);
                mainReport.RegBusinessObject("ListHealthConditions_business", _ListHealthConditionEntity);
                mainReport.RegBusinessObject("ListAbilityRequiredJob_business", _ListAbilityRequiredJobReport);
                mainReport.RegBusinessObject("ListTrainingRequired_business", _ListTrainingRequiredEntity);

                mainReport.RegBusinessObject("UpstreamCommunication_business", _UpstreamCommunicationReport);
                mainReport.RegBusinessObject("ExternalCommunication_business", _ExternalCommunicationReport);
                mainReport.RegBusinessObject("CommunicationRow_business", _CommunicationRowReport);
                mainReport.RegBusinessObject("DownstreamCommunication_business", _DownstreamCommunicationReport);

                //mainReport["PostGroupName"] = _InventoryjobsReport.PostGroupName;
                //mainReport["EducationalExperts"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.EducationalExperts).Specifications;
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

                // 
                //ارسال دیتا به گزارش ساز را انجام می دهد
                //1400 12 23 ADD COMMENT
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);

            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(InventoryjobEntity Current)
        {
            try
            {
                int result;
                result = _InventoryjobProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.Inventoryjob, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryjobEntity Current)
        {
            try
            {
                bool result;
                result = _InventoryjobProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.Inventoryjob, _CustomAuthorizeAttribute.UserId(), "", "", Current.InventoryjobId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _InventoryjobProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.Inventoryjob, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListInventoryjob()
        {
            try
            {
                var list = _InventoryjobProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListInventoryjob");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult CopyDataInventoryjob(int ID)
        {
            try
            {
                //bool result;
                //result = _InventoryjobProvider.CopyDataInventoryjob(ID);
                //return this.Json(result, JsonRequestBehavior.AllowGet);

                bool result;
                result = _InventoryjobProvider.CopyDataInventoryjob(ID);
                return Json(result);
            }

            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Inventoryjob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "CopyDataInventoryjob");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //[HttpPost]
        //public ActionResult CopyDataInventoryjob(EmployemeSearch employemesearch)
        //{
        //    try
        //    {
        //        #region set null to string.Empty
        //        if (employemesearch.FirstName == null)
        //            employemesearch.FirstName = string.Empty;

        //        if (employemesearch.LastName == null)
        //            employemesearch.LastName = string.Empty;

        //        if (employemesearch.FieldOfStudy == null)
        //            employemesearch.FieldOfStudy = string.Empty;
        //        #endregion

        //        List<EmployemeEntity> _EmployemeEntity = new List<EmployemeEntity>();
        //        if (employemesearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
        //        {
        //            _EmployemeEntity = _EmployemeProvider.GetAll().ToList();
        //            return View(_EmployemeEntity);
        //        }
        //        else if (
        //           employemesearch.FirstName.Trim() == "" && employemesearch.LastName.Trim() == "" && employemesearch.PersonnelCode == 0 &&
        //           employemesearch.EducationId == 0 && employemesearch.FieldOfStudy.Trim() == "" && employemesearch.UnitSCenterId == 0 &&
        //           employemesearch.SectionId == 0 && employemesearch.DepartmentId == 0 && employemesearch.typesearch == (int)TypeSearch.typesearch.WithParameter
        //           & employemesearch.State == -1)
        //        {
        //            _EmployemeEntity = _EmployemeProvider.GetAll().ToList();
        //            return View(_EmployemeEntity);
        //        }
        //        else if (employemesearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
        //        {
        //            employemesearch.UserState = Convert.ToBoolean(employemesearch.State);
        //            _EmployemeEntity = _EmployemeProvider.GetAll(employemesearch).ToList();
        //        }


        //        List<EmployemeEntity> _EmployemeEntityDistinct = new List<EmployemeEntity>();
        //        foreach (EmployemeEntity item in _EmployemeEntity)
        //        {
        //            int count = _EmployemeEntityDistinct.Count(a => a.EmployemeId == item.EmployemeId);
        //            if (count == 0)
        //                _EmployemeEntityDistinct.Add(item);
        //        }
        //        TempData["ListEmployemeEntity"] = _EmployemeEntityDistinct;
        //        return View(_EmployemeEntityDistinct);
        //    }
        //    catch (Exception e)
        //    {
        //        LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Employeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListEmployeme");
        //        _LogErrorProvider.Add(logerrorentity);
        //        return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
        //    }
        //}



    }
}