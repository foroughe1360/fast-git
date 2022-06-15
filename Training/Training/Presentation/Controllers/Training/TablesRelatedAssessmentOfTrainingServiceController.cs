using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using Presentation.Utility;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User")]
    public class TablesRelatedAssessmentOfTrainingServiceController : Controller
    {
        private TablesRelatedAssessmentOfTrainingServiceProvider _TablesRelatedAssessmentOfTrainingServiceProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public TablesRelatedAssessmentOfTrainingServiceController()
        {
            _TablesRelatedAssessmentOfTrainingServiceProvider = new TablesRelatedAssessmentOfTrainingServiceProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: TablesRelatedAssessmentOfTrainingService
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.AssessmentOfTrainingServiceId = ID;

                AssessmentOfTrainingServiceInformationProvider _AssessmentOfTrainingServiceInformationProvider = new AssessmentOfTrainingServiceInformationProvider();
                AssessmentOfTrainingServiceInformationEntity _AssessmentOfTrainingServiceInformationEntity = new AssessmentOfTrainingServiceInformationEntity();
                ViewBag.AOTSI = new SelectList(_AssessmentOfTrainingServiceInformationProvider.GetAll(), "AssessmentOfTrainingServiceInformationId", "Name", _AssessmentOfTrainingServiceInformationEntity.AssessmentOfTrainingServiceInformationId);


                var list = _TablesRelatedAssessmentOfTrainingServiceProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService,e.Message,(int)TableInterfaceValueEntity.OperationType.Index,"");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TablesRelatedAssessmentOfTrainingServiceEntity Current)
        {
            try
            {
                int result;
                result = _TablesRelatedAssessmentOfTrainingServiceProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TablesRelatedAssessmentOfTrainingServiceEntity Current)
        {
            try
            {
                bool result;
                result = _TablesRelatedAssessmentOfTrainingServiceProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, _CustomAuthorizeAttribute.UserId(), "", "", Current.TablesRelatedAssessmentOfTrainingServiceId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _TablesRelatedAssessmentOfTrainingServiceProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListTablesRelatedAssessmentOfTrainingService(int AssessmentOfTrainingServiceId)
        {
            try
            {
                var list = _TablesRelatedAssessmentOfTrainingServiceProvider.GetAll(AssessmentOfTrainingServiceId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TablesRelatedAssessmentOfTrainingService, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTablesRelatedAssessmentOfTrainingService");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}