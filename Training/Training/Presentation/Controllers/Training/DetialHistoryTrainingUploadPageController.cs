using Bussiness;
using Bussiness.Provider;
using Bussiness.Provider.Training;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.Training
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "29")]
    public class DetialHistoryTrainingUploadPageController : Controller
    {
        DetialHistoryTrainingUploadPageProvider _DetialHistoryTrainingUploadPageProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public DetialHistoryTrainingUploadPageController()
        {
            _DetialHistoryTrainingUploadPageProvider = new DetialHistoryTrainingUploadPageProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: DetialHistoryTrainingUploadPage
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.HistoryTrainingUploadPageId = ID;
                var list = _DetialHistoryTrainingUploadPageProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                CodingTrainingPageProvider _CodingTrainingPageProvider = new CodingTrainingPageProvider();
                CodingTrainingPageEntity _CodingTrainingPageEntity = new CodingTrainingPageEntity();
                ViewBag.CodingTrainingPage = new SelectList(_CodingTrainingPageProvider.GetAll(), "CodingTrainingPageId", "Title", _CodingTrainingPageEntity.CodingTrainingPageId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                CodingTrainingPageProvider _CodingTrainingPageProvider = new CodingTrainingPageProvider();
                CodingTrainingPageEntity _CodingTrainingPageEntity = new CodingTrainingPageEntity();
                ViewBag.CodingTrainingPage = new SelectList(_CodingTrainingPageProvider.GetAll(), "CodingTrainingPageId", "Title", _CodingTrainingPageEntity.CodingTrainingPageId);

                return View(_DetialHistoryTrainingUploadPageProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        
        [HttpPost]
        public ActionResult Create(DetialHistoryTrainingUploadPageEntity Current)
        {
            try
            {
                int result;
                result = _DetialHistoryTrainingUploadPageProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(DetialHistoryTrainingUploadPageEntity Current)
        {
            try
            {
                bool result;
                result = _DetialHistoryTrainingUploadPageProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, _CustomAuthorizeAttribute.UserId(), "", "", Current.DetialHistoryTrainingUploadPageId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _DetialHistoryTrainingUploadPageProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListDetialHistoryTrainingUploadPage(int historytraininguploadpageid)
        {
            try
            {
                ViewBag.HistoryTrainingUploadPageId = historytraininguploadpageid;
                var list = _DetialHistoryTrainingUploadPageProvider.GetAll(historytraininguploadpageid).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailHistoryTrainingUploadPage, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListDetialHistoryTrainingUploadPage");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}