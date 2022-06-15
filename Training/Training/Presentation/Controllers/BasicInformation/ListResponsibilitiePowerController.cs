using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin", RolesConfigKey = "18")]
    public class ListResponsibilitiePowerController : Controller
    {
        private ListResponsibilitiePowerProvider _ListResponsibilitiePowerProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public ListResponsibilitiePowerController()
        {
            _ListResponsibilitiePowerProvider = new ListResponsibilitiePowerProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        
        // GET: ListResponsibilitiePower
        public ActionResult Index()
        {
            try
            {
                PostGroupProvider _PostGroupProvider = new PostGroupProvider();
                PostGroupEntity _PostGroupEntity = new PostGroupEntity();
                ViewBag.PostGroupId = new SelectList(_PostGroupProvider.GetAll(), "PostGroupId", "PostGroupName", _PostGroupEntity.PostGroupId);

                var list = _ListResponsibilitiePowerProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: ListResponsibilitiePower
        public ActionResult Create()
        {
            try
            {
                PostGroupProvider _PostGroupProvider = new PostGroupProvider();
                PostGroupEntity _PostGroupEntity = new PostGroupEntity();
                ViewBag.PostGroupId = new SelectList(_PostGroupProvider.GetAll(), "PostGroupId", "PostGroupName", _PostGroupEntity.PostGroupId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: ListResponsibilitiePower
        public ActionResult Edit(int ID)
        {
            try
            {
                PostGroupProvider _PostGroupProvider = new PostGroupProvider();
                PostGroupEntity _PostGroupEntity = new PostGroupEntity();
                ViewBag.PostGroupIdTemp = new SelectList(_PostGroupProvider.GetAll(), "PostGroupId", "PostGroupName", _PostGroupEntity.PostGroupId);

                return View(_ListResponsibilitiePowerProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(ListResponsibilitiePowerEntity Current)
        {
            try
            {
                int result;
                result = _ListResponsibilitiePowerProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(ListResponsibilitiePowerEntity Current)
        {
            try
            {
                bool result;
                result = _ListResponsibilitiePowerProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, _CustomAuthorizeAttribute.UserId(), "", "", Current.ListResponsibilitiePowerId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _ListResponsibilitiePowerProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListListResponsibilitiePower(ListResponsibilitiePowerSearch listresponsibilitiepowersearch)
        {
            try
            {
                //var list = _ListResponsibilitiePowerProvider.GetAll().ToList();
                //return View(list);

                List<ListResponsibilitiePowerEntity> _ListResponsibilitiePowerEntity = new List<ListResponsibilitiePowerEntity>();
                if (listresponsibilitiepowersearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    _ListResponsibilitiePowerEntity = _ListResponsibilitiePowerProvider.GetAll().ToList();
                    return View(_ListResponsibilitiePowerEntity);
                }
                else if (listresponsibilitiepowersearch.PostGroupId == 0)
                {
                    _ListResponsibilitiePowerEntity = _ListResponsibilitiePowerProvider.GetAll().ToList();
                    return View(_ListResponsibilitiePowerEntity);
                }
                else if (listresponsibilitiepowersearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    _ListResponsibilitiePowerEntity = _ListResponsibilitiePowerProvider.GetAll(listresponsibilitiepowersearch).ToList();
                }

                return View(_ListResponsibilitiePowerEntity);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListResponsibilitiePower, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListListResponsibilitiePower");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}