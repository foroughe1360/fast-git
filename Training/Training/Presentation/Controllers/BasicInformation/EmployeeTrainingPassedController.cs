using Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using InterfaceEntity;
using Presentation.Utility;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin", RolesConfigKey = "10")]
    public class EmployeeTrainingPassedController : Controller
    {
        private EmployeeTrainingPassedProvider _EmployeeTrainingPassedProvider;
        private TableTypeOfTrainingProvider _TableTypeOfTrainingProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public EmployeeTrainingPassedController()
        {
            _EmployeeTrainingPassedProvider = new EmployeeTrainingPassedProvider();
            _TableTypeOfTrainingProvider = new TableTypeOfTrainingProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: AccessAndLog List
        public ActionResult Index(int ID) 
        {
            try
            {
                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                ViewBag.TrainingCourseId = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceIdTrainingVenue = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TrainingVenue), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.EmployemeId = ID;
                var list = _EmployeeTrainingPassedProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TableTypeOfTrainingEntity _TableTypeOfTrainingEntity, EmployeeTrainingPassedEntity _EmployeeTrainingPassedEntity)
        {
            try
            {
                int result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingProvider.Add(_TableTypeOfTrainingEntity);
                    _EmployeeTrainingPassedEntity.TableTypeOfTrainingId = result;
                    result = _EmployeeTrainingPassedProvider.Add(_EmployeeTrainingPassedEntity);
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TableTypeOfTrainingEntity _TableTypeOfTrainingEntity, EmployeeTrainingPassedEntity _EmployeeTrainingPassedEntity)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingProvider.Edit(_TableTypeOfTrainingEntity);
                    result = _EmployeeTrainingPassedProvider.Edit(_EmployeeTrainingPassedEntity);
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }
                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, _CustomAuthorizeAttribute.UserId(), "", "", _EmployeeTrainingPassedEntity.EmployeeTrainingPassedId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion
                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int TableTypeOfTrainingID,int EmployeeTrainingPassedID)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingProvider.Delete(TableTypeOfTrainingID);
                    result = _EmployeeTrainingPassedProvider.Delete(EmployeeTrainingPassedID);
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }
                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, _CustomAuthorizeAttribute.UserId(), "", "", EmployeeTrainingPassedID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion
                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListEmployeeTrainingPassed(int EmployemeId)
        {
            try
            {
                var list = _EmployeeTrainingPassedProvider.GetAll(EmployemeId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.EmployeeTrainingPassed, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListEmployeeTrainingPassed");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}