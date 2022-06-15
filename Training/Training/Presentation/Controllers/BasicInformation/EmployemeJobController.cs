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
    [CustomAuthorize(Roles = "Admin", RolesConfigKey = "10")]
    public class EmployemeJobController : Controller
    {
        private EmployemeJobProvider _EmployemeJobProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public EmployemeJobController()
        {
            _EmployemeJobProvider = new EmployemeJobProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: AccessAndLog List
        public ActionResult Index(int ID)
        {
            try
            {
                PostGroupProvider _PostGroupProvider = new PostGroupProvider();
                PostGroupEntity _PostGroupEntity = new PostGroupEntity();
                ViewBag.PostGroupId = new SelectList(_PostGroupProvider.GetAll(), "PostGroupId", "PostGroupName", _PostGroupEntity.PostGroupId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdUnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.EmployemeId = ID;

                var list = _EmployemeJobProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(EmployemeJobEntity Current)
        {
            try
            {
                int result;
                result = _EmployemeJobProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.EmployemeJob, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployemeJobEntity Current)
        {
            try
            {
                bool result;
                result = _EmployemeJobProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.EmployemeJob, _CustomAuthorizeAttribute.UserId(), "", "", Current.EmployemeJobId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _EmployemeJobProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.EmployemeJob, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public JsonResult GetEmployemeJob(int employemeid)
        {
            try
            {
                var list = _EmployemeJobProvider.GetAll(employemeid).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetEmployemeJob");
                _LogErrorProvider.Add(logerrorentity);
                List<EmployemeJobEntity> listEmployemeJobEntity = new List<EmployemeJobEntity>();
                return Json(listEmployemeJobEntity, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet] 
        public ActionResult _GetListEmployemeJob(int employemeid)
        {
            try
            {
                var list = _EmployemeJobProvider.GetAll(employemeid).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetEmployemeJob");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListCurrentPostGroupDPD(int employemeid)
        {
            try
            {
                var list = _EmployemeJobProvider.GetAllEmployemeJobDPD(employemeid).ToList();

                EmployemeJobEntity _EmployemeJobEntity = new EmployemeJobEntity();

                ViewBag.list = new SelectList(_EmployemeJobProvider.GetAllEmployemeJobDPD(employemeid), "EmployemeJobId", "PostGroupName", _EmployemeJobEntity.EmployemeJobId);

                return Json(ViewBag.list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetEmployemeJob");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListCurrentPostGroupInfo(int employemejobid)
        {
            try
            {
                General _General = new General();
                var list = _EmployemeJobProvider.GetCurrentPostGroupInfo(employemejobid);
                list.DateStartPostGroupNameStr = _General.MiladiToShamsi(list.DateStartPostGroupName);
                var listPreviousJobs = _EmployemeJobProvider.GetAllPreviousJobs(list.EmployemeId);
                foreach (var item in listPreviousJobs)
                {
                    if (list.PreviousJobs != null)
                        list.PreviousJobs += "\n";
                    list.PreviousJobs += item.PostGroupName;
                }
                return Json(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployemeJob, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetEmployemeJob");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        
    }
}