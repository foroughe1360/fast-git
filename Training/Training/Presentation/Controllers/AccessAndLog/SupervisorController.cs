using Bussiness;
using Bussiness.Provider.AccessAndLog;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.AccessAndLog
{
    public class SupervisorController : Controller
    {
        private SupervisorProvider supervisorprovider;
        private LogErrorProvider logerrorprovider;
        private OperationLogProvider operationlogprovider;

        public SupervisorController()
        {
            supervisorprovider = new SupervisorProvider();
            logerrorprovider = new LogErrorProvider();
            operationlogprovider = new OperationLogProvider();
        }

        // GET: Supervisor
        public ActionResult Index()
        {
            var list = supervisorprovider.GetAll().ToList();
            return View(list);
        }

        //Get: Supervisor Page
        public ActionResult Create()
        {
            try
            {
                //لیست کارمندان 
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.EmployemeId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                //لیست واحدها
                //TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                //TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //ViewBag.UnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                DepartmentProvider departmentprovider = new DepartmentProvider();
                DepartmentEntity departmententity = new DepartmentEntity();
                ViewBag.Department = new SelectList(departmentprovider.GetAll(), "DepartmentId", "Name", departmententity.DepartmentId);

                //لیست شغل ها
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.PostType = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.PostType), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);


                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Teacher, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                logerrorprovider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: Supervisor Page
        public ActionResult Edit(int ID)
        {
            try
            {
                //لیست کارمندان 
                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.Employeme = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                //لیست واحدها
                //TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                //TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //ViewBag.UnitSCenter = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.UnitSCenter), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                DepartmentProvider departmentprovider = new DepartmentProvider();
                DepartmentEntity departmententity = new DepartmentEntity();
                ViewBag.Department = new SelectList(departmentprovider.GetAll(), "DepartmentId", "Name", departmententity.DepartmentId);

                //لیست شغل ها
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.PostType = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.PostType), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);


                return View(supervisorprovider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Teacher, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                logerrorprovider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(SupervisorEntity Current)
        {
            try
            {
                int result;
                result = supervisorprovider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.Teacher, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    operationlogprovider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Teacher, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                logerrorprovider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(SupervisorEntity Current)
        {
            try
            {
                bool result;
                result = supervisorprovider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.Supervisor, _CustomAuthorizeAttribute.UserId(), "", "", Current.SupervisorId);
                operationlogprovider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Teacher, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                logerrorprovider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                bool result;
                result = supervisorprovider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.Teacher, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                operationlogprovider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Teacher, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                logerrorprovider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListSupervisor()
        {
            try
            {
                var list = supervisorprovider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Teacher, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTeacher");
                logerrorprovider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}