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
    public class DetailOfferTrainingForJobController : Controller
    {
        private DetailOfferTrainingForJobProvider _DetailOfferTrainingForJobProvider;
        private TableTypeOfTrainingProvider _TableTypeOfTrainingSetProvider, _TableTypeOfTrainingOfferProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public DetailOfferTrainingForJobController()
        {
            _DetailOfferTrainingForJobProvider = new DetailOfferTrainingForJobProvider();
            _TableTypeOfTrainingSetProvider = new TableTypeOfTrainingProvider();
            _TableTypeOfTrainingOfferProvider = new TableTypeOfTrainingProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: DetailOfferTrainingForJob List
        public ActionResult Index(int OfferTrainingForJobsId)
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdPriority = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.Priority), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.OfferTrainingForJobsId = OfferTrainingForJobsId;

                var list = _DetailOfferTrainingForJobProvider.GetAll(OfferTrainingForJobsId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: DetailOfferTrainingForJob Page
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: DetailOfferTrainingForJob Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_DetailOfferTrainingForJobProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TableTypeOfTrainingEntity _TableTypeOfTrainingSetEntity, TableTypeOfTrainingEntity _TableTypeOfTrainingOfferEntity, DetailOfferTrainingForJobEntity _DetailOfferTrainingForJobEntity)
        {
            try
            {
                int result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingSetProvider.Add(_TableTypeOfTrainingSetEntity);
                    _DetailOfferTrainingForJobEntity.TableTypeOfTrainingSetId = result;

                    result = _TableTypeOfTrainingOfferProvider.Add(_TableTypeOfTrainingOfferEntity);
                    _DetailOfferTrainingForJobEntity.TableTypeOfTrainingOfferId = result;

                    result = _DetailOfferTrainingForJobProvider.Add(_DetailOfferTrainingForJobEntity);

                    scope.Complete();
                }
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TableTypeOfTrainingEntity _TableTypeOfTrainingSetEntity, TableTypeOfTrainingEntity _TableTypeOfTrainingOfferEntity, DetailOfferTrainingForJobEntity _DetailOfferTrainingForJobEntity)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingSetProvider.Edit(_TableTypeOfTrainingSetEntity);
                    result = _TableTypeOfTrainingOfferProvider.Edit(_TableTypeOfTrainingOfferEntity);
                    result = _DetailOfferTrainingForJobProvider.Edit(_DetailOfferTrainingForJobEntity);
                    scope.Complete();
                }

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, _CustomAuthorizeAttribute.UserId(), "", "", _DetailOfferTrainingForJobEntity.DetailOfferTrainingForJobId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int _TableTypeOfTrainingSetID, int _TableTypeOfTrainingOfferID, int _DetailOfferTrainingForJobID)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingSetProvider.Delete(_TableTypeOfTrainingSetID);
                    result = _TableTypeOfTrainingOfferProvider.Delete(_TableTypeOfTrainingOfferID);
                    result = _DetailOfferTrainingForJobProvider.Delete(_DetailOfferTrainingForJobID);
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, _CustomAuthorizeAttribute.UserId(), "", "", _DetailOfferTrainingForJobID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListDetailOfferTrainingForJob(int OfferTrainingForJobsId)
        {
            try
            {
                var list = _DetailOfferTrainingForJobProvider.GetAll(OfferTrainingForJobsId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListDetailOfferTrainingForJob");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}