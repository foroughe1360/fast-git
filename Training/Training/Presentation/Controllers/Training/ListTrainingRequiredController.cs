using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using Presentation.Utility;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User")]
    public class ListTrainingRequiredController : Controller
    {
        private ListTrainingRequiredProvider _ListTrainingRequiredProvider;
        private TableTypeOfTrainingProvider _TableTypeOfTrainingFaceProvider, _TableTypeOfTrainingTimeProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public ListTrainingRequiredController()
        {
            _ListTrainingRequiredProvider = new ListTrainingRequiredProvider();
            _TableTypeOfTrainingFaceProvider = new TableTypeOfTrainingProvider();
            _TableTypeOfTrainingTimeProvider = new TableTypeOfTrainingProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: ListTrainingRequired
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.InventoryjobsId = ID;
                var list = _ListTrainingRequiredProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingRequired, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingRequired, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                //TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                //TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //ViewBag.TableInterfaceIdTrainingRequired = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TrainingRequired), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                return View(_ListTrainingRequiredProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingRequired, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TableTypeOfTrainingEntity _TableTypeOfTrainingFaceEntity,  ListTrainingRequiredEntity _ListTrainingRequiredEntity)
        {
            try
            {
                int result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingFaceProvider.Add(_TableTypeOfTrainingFaceEntity);
                    _ListTrainingRequiredEntity.TableTypeOfTrainingFaceId = result;
                    result = _ListTrainingRequiredProvider.Add(_ListTrainingRequiredEntity);

                    scope.Complete();
                }
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.ListTrainingRequired, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);

                //  return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingRequired, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TableTypeOfTrainingEntity _TableTypeOfTrainingFaceEntity, ListTrainingRequiredEntity _ListTrainingRequiredEntity)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    //result = _TableTypeOfTrainingTimeProvider.Edit(_TableTypeOfTrainingTimeEntity);
                    result = _TableTypeOfTrainingFaceProvider.Edit(_TableTypeOfTrainingFaceEntity);
                    result = _ListTrainingRequiredProvider.Edit(_ListTrainingRequiredEntity);
                    scope.Complete();
                }

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.ListTrainingRequired, _CustomAuthorizeAttribute.UserId(), "", "", _ListTrainingRequiredEntity.ListTrainingRequiredId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingRequired, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int tabletypeoftrainingfaceid,  int listtrainingrequiredid)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingFaceProvider.Delete(tabletypeoftrainingfaceid);
                    //result = _TableTypeOfTrainingTimeProvider.Delete(_TableTypeOfTrainingTimeID);
                    result = _ListTrainingRequiredProvider.Delete(listtrainingrequiredid);
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.ListTrainingRequired, _CustomAuthorizeAttribute.UserId(), "", "", listtrainingrequiredid);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingRequired, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListListTrainingRequired(int inventoryjobsid)
        {
            try
            {
                ViewBag.InventoryjobsId = inventoryjobsid;
                var list = _ListTrainingRequiredProvider.GetAll(inventoryjobsid).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingRequired, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListListTrainingRequired");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}