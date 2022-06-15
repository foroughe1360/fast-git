using Bussiness;
using Bussiness.Provider;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.Training
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "21")]
    public class OfferTrainingForEmployeeDateController : Controller
    {
        private OfferTrainingForEmployeeDateProvider _OfferTrainingForEmployeeDateProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public OfferTrainingForEmployeeDateController()
        {
            _OfferTrainingForEmployeeDateProvider = new OfferTrainingForEmployeeDateProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        // GET: OfferTrainingForEmployeeDate
        public ActionResult Index()
        {
            try
            {
                var list = _OfferTrainingForEmployeeDateProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

       //public ActionResult Index(int ID, int offertrainingforemployeedateid)
       // {
       //     try
       //     {
       //         var list = _OfferTrainingForEmployeeDateProvider.GetAll().ToList();
       //         return View(list);
       //     }
       //     catch (Exception e)
       //     {
       //         LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
       //         _LogErrorProvider.Add(logerrorentity);
       //         return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
       //     }
       // }

        //Get: OfferTrainingForEmployeeDate Page
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: OfferTrainingForEmployeeDate Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_OfferTrainingForEmployeeDateProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(OfferTrainingForEmployeeDateEntity Current)
        {
            try
            {
                int result;
                result = _OfferTrainingForEmployeeDateProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(OfferTrainingForEmployeeDateEntity Current)
        {
            try
            {
                bool result;
                result = _OfferTrainingForEmployeeDateProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, _CustomAuthorizeAttribute.UserId(), "", "", Current.OfferTrainingForEmployeeDateId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _OfferTrainingForEmployeeDateProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.OfferTrainingForJobDate, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListOfferTrainingForEmployeeDate()
        {
            try
            {
                var list = _OfferTrainingForEmployeeDateProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.OfferTrainingForEmployeeDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListOfferTrainingForJobDate");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }


    }
}