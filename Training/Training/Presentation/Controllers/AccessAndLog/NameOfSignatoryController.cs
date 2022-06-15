using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.AccessAndLog
{
    public class NameOfSignatoryController : Controller
    {
        private NameOfSignatoryProvider _NameOfSignatoryProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public NameOfSignatoryController()
        {
            _NameOfSignatoryProvider = new NameOfSignatoryProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: NameOfSignatory
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.SideSignatoryId = ID;
                var list = _NameOfSignatoryProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.NameOfSignatory, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: Create NameOfSignatory Page
        public ActionResult Create()
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();

                ViewBag.TableInterfaceValueIdCollection = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.Collection), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                ViewBag.TableInterfaceValueIdPostType = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.PostType), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.NameOfSignatory, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: Edit NameOfSignatory Page
        public ActionResult Edit(int ID)
        {
            try
            {
                var q = _NameOfSignatoryProvider.Get(ID);
                return View(q);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.NameOfSignatory, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(NameOfSignatoryEntity Current)
        {
            try
            {
                int result;
                result = _NameOfSignatoryProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                        CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                        OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.NameOfSignatory, _CustomAuthorizeAttribute.UserId(), "", "", result);
                        _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.NameOfSignatory, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(NameOfSignatoryEntity Current)
        {
            try
            {
                bool result;
                result = _NameOfSignatoryProvider.Edit(Current);

                #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.NameOfSignatory, _CustomAuthorizeAttribute.UserId(), "", "", Current.NameOfSignatoryId);
                    _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.NameOfSignatory, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _NameOfSignatoryProvider.Delete(ID);

                #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.NameOfSignatory, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                    _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.NameOfSignatory, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListNameOfSignatory(int ID)
        {
            try
            {
                ViewBag.SideSignatoryId = ID;
                var list = _NameOfSignatoryProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.NameOfSignatory, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListNameOfSignatory");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }

        }
    }
}