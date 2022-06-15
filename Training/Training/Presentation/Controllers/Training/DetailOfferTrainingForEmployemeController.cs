using Bussiness;
using Bussiness.Provider;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.Training
{
    public class DetailOfferTrainingForEmployemeController : Controller
    {
   
        private DetailOfferTrainingForEmployemeProvider _DetailOfferTrainingForEmployemeProvider;
        private TableTypeOfTrainingProvider _TableTypeOfTrainingSetProvider, _TableTypeOfTrainingOfferProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public DetailOfferTrainingForEmployemeController()
        {
            _DetailOfferTrainingForEmployemeProvider = new DetailOfferTrainingForEmployemeProvider();
            _TableTypeOfTrainingSetProvider = new TableTypeOfTrainingProvider();
            _TableTypeOfTrainingOfferProvider = new TableTypeOfTrainingProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: DetailOfferTrainingForEmployeme
        public ActionResult Index(int OfferTrainingForEmployemesId)
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdPriority = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.Priority), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                ViewBag.OfferTrainingForEmployemesId = OfferTrainingForEmployemesId;

                var list = _DetailOfferTrainingForEmployemeProvider.GetAll(OfferTrainingForEmployemesId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get:  DetailOfferTrainingForEmployeme Page
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get:  DetailOfferTrainingForEmployeme Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_DetailOfferTrainingForEmployemeProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TableTypeOfTrainingEntity _TableTypeOfTrainingSetEntity, TableTypeOfTrainingEntity _TableTypeOfTrainingOfferEntity, DetailOfferTrainingForEmployemeEntity _DetailOfferTrainingForEmployemeEntity)
        {
            try
            {
                int result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingSetProvider.Add(_TableTypeOfTrainingSetEntity);
                    _DetailOfferTrainingForEmployemeEntity.TableTypeOfTrainingSetId = result;

                    result = _TableTypeOfTrainingOfferProvider.Add(_TableTypeOfTrainingOfferEntity);
                    _DetailOfferTrainingForEmployemeEntity.TableTypeOfTrainingOfferId = result;

                    result = _DetailOfferTrainingForEmployemeProvider.Add(_DetailOfferTrainingForEmployemeEntity);

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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TableTypeOfTrainingEntity _TableTypeOfTrainingSetEntity, TableTypeOfTrainingEntity _TableTypeOfTrainingOfferEntity, DetailOfferTrainingForEmployemeEntity _DetailOfferTrainingForEmployemeEntity)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingSetProvider.Edit(_TableTypeOfTrainingSetEntity);
                    result = _TableTypeOfTrainingOfferProvider.Edit(_TableTypeOfTrainingOfferEntity);
                    result = _DetailOfferTrainingForEmployemeProvider.Edit(_DetailOfferTrainingForEmployemeEntity);
                    scope.Complete();
                }

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, _CustomAuthorizeAttribute.UserId(), "", "", _DetailOfferTrainingForEmployemeEntity.DetailOfferTrainingForEmployemeId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int _TableTypeOfTrainingSetID, int _TableTypeOfTrainingOfferID, int _DetailOfferTrainingForEmployemeID)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _TableTypeOfTrainingSetProvider.Delete(_TableTypeOfTrainingSetID);
                    result = _TableTypeOfTrainingOfferProvider.Delete(_TableTypeOfTrainingOfferID);
                    result = _DetailOfferTrainingForEmployemeProvider.Delete(_DetailOfferTrainingForEmployemeID);
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.DetailOfferTrainingForJob, _CustomAuthorizeAttribute.UserId(), "", "", _DetailOfferTrainingForEmployemeID);
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
        public ActionResult _GetListDetailOfferTrainingForEmployeme(int OfferTrainingForEmployemesId)
        {
            try
            {
                var list = _DetailOfferTrainingForEmployemeProvider.GetAll(OfferTrainingForEmployemesId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailOfferTrainingForEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListDetailOfferTrainingForEmployeme");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}