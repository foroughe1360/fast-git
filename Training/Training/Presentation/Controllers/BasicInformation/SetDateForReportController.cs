using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class SetDateForReportController : Controller
    {
        private SetDateForReportProvider _SetDateForReportProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;
        public SetDateForReportController()
        {
            _SetDateForReportProvider = new SetDateForReportProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        // GET: SetDateForReport
        public ActionResult Index(int PublicCode, int EmployemeId, int ReportNameId)
        {
            //نام فرم گزارش
            TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
            TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
            ViewBag.TableInterfaceIdReportNameId = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.ReportName), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
            ViewBag.PlacementTabJobTrainingId = PublicCode;
            ViewBag.EmployemeId = EmployemeId;

            var list = _SetDateForReportProvider.GetAll(PublicCode , ReportNameId).ToList();
            return View(list);
        }


        [HttpPost]
        public ActionResult Create(SetDateForReportEntity Current)
        {
            try
            {
                int result;
                result = _SetDateForReportProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.SetDateForReport, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SetDateForReport, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        [HttpPost]
        public ActionResult Edit(SetDateForReportEntity Current)
        {
            try
            {
                bool result;
                result = _SetDateForReportProvider.Edit(Current);

                #region Edit Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.SetDateForReport, _CustomAuthorizeAttribute.UserId(), "", "", Current.EmployemeId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SetDateForReport, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListSetDateForReport(int PublicCode ,  int ReportNameId)//, int EmployemeId)
        {
            try
            { 
                //نام فرم گزارش
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceIdReportNameId = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.ReportName), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.PublicCode = PublicCode;
                //ViewBag.EmployemeId = EmployemeId;
                var list = _SetDateForReportProvider.GetAll(PublicCode , ReportNameId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListPlacementTabJobTraining");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}