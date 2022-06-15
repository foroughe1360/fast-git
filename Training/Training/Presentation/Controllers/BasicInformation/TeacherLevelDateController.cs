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
    [CustomAuthorize(Roles = "Admin", RolesConfigKey = "9")]
    public class TeacherLevelDateController : Controller
    {
        private TeacherLevelDateProvider _TeacherLevelDateProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public TeacherLevelDateController()
        {
            _TeacherLevelDateProvider = new TeacherLevelDateProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: TeacherLevelDate
        public ActionResult Index()
        {
            try
            {
                var list = _TeacherLevelDateProvider.GetAll().ToList();
                ViewBag.ReportNameId = (int)ReportName.ReportNames.TeacherLevel;
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevelDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: TeacherLevelDate Page
        public ActionResult Create()
        {
            try
            {
                TeacherLevelDateProvider _TeacherLevelDateProvider = new TeacherLevelDateProvider();
                TeacherLevelDateEntity _TeacherLevelDateEntity = new TeacherLevelDateEntity();
                ViewBag.TeacherLevelDateListId = new SelectList(_TeacherLevelDateProvider.GetAll(), "TeacherLevelDateId", "Description", _TeacherLevelDateEntity.TeacherLevelDateId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevelDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: TeacherLevelDate Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_TeacherLevelDateProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevelDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TeacherLevelDateEntity Current)
        {
            try
            {
                int result;
                result = _TeacherLevelDateProvider.Add(Current);
                
                TeacherLevelProvider _TeacherLevelProvider = new TeacherLevelProvider();
                List<TeacherLevelEntity> teacherLevelEntity = new List<TeacherLevelEntity>();
                var listTeacherLevel = _TeacherLevelProvider.GetAll(Current.TeacherLevelDateListId);

                foreach (var item in listTeacherLevel)
                {
                    item.TeacherLevelDateId = result;
                    _TeacherLevelProvider.Add(item);
                }

                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.TeacherLevelDate, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevelDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TeacherLevelDateEntity Current)
        {
            try
            {
                bool result;
                result = _TeacherLevelDateProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.TeacherLevelDate, _CustomAuthorizeAttribute.UserId(), "", "", Current.TeacherLevelDateId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevelDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _TeacherLevelDateProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.TeacherLevelDate, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevelDate, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListTeacherLevelDate()
        {
            try
            {
                var list = _TeacherLevelDateProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevelDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTeacherLevelDate");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}