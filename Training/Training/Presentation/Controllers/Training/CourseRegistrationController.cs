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
    public class CourseRegistrationController : Controller
    {
        private CourseRegistrationProvider _CourseRegistrationProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;
        private AttendanceProvider attendanceprovider;

        public CourseRegistrationController()
        {
            _CourseRegistrationProvider = new CourseRegistrationProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: CourseRegistration
        public ActionResult Index(int ID)
        {
            try
            {
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.Employeme = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceIdEmployemeState = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.EmployemeState), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.DesignTrainingCourseId = ID;
                var list = _CourseRegistrationProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult CourseRegistrationIndex(int ID, int designtrainingcoursedateid)
        {
            try
            {
                ViewBag.DesignTrainingCourseId = ID;
                ViewBag.DesignTrainingCourseDateId = designtrainingcoursedateid;
                var list = _CourseRegistrationProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "CourseRegistrationIndex");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Create()
        {
            try
            {
                //نام کارمند
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                //ViewBag.EmployemesId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemesName", _EmployemeEntity.EmployemeId);
                ViewBag.EmployemesId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "LastName", _EmployemeEntity.EmployemeId);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                //نام کارمند
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                //ViewBag.EmployemesId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemesName", _EmployemeEntity.EmployemeId);
                ViewBag.EmployemesId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "LastName", _EmployemeEntity.EmployemeId);

                return View(_CourseRegistrationProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(CourseRegistrationEntity Current)
        {
            try
            {
                int result;
                result = _CourseRegistrationProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.CourseRegistration, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(CourseRegistrationEntity Current)
        {
            try
            {
                bool result;
                result = _CourseRegistrationProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.CourseRegistration, _CustomAuthorizeAttribute.UserId(), "", "", Current.CourseRegistrationId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                attendanceprovider = new AttendanceProvider();
                if (attendanceprovider.CheckAttendance(ID)) return Json(false);
                result = _CourseRegistrationProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.CourseRegistration, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListCourseRegistration(int designtrainingcourseid)
        {
            try
            {
                var list = _CourseRegistrationProvider.GetAll(designtrainingcourseid).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseRegistration, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListCourseRegistration");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}