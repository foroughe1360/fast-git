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
    public class DetailPlacementTabJobTrainingController : Controller
    {
        private DetailPlacementTabJobTrainingProvider _DetailPlacementTabJobTrainingProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public DetailPlacementTabJobTrainingController()
        {
            _DetailPlacementTabJobTrainingProvider = new DetailPlacementTabJobTrainingProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: DetailPlacementTabJobTraining
        public ActionResult Index(int PlacementTabJobTrainingId)
        {
            try
            {
                OJTLevelProvider _OJTLevelProvider = new OJTLevelProvider();
                OJTLevelEntity _OJTLevelEntity = new OJTLevelEntity();
                ViewBag.OJTLevelId = new SelectList(_OJTLevelProvider.GetAll(), "OJTLevelId", "LevelNumber", _OJTLevelEntity.OJTLevelId);

                ViewBag.PlacementTabJobTrainingId = PlacementTabJobTrainingId;

                //GetAll : 
                //yek method mibashe ke "IQueryable" 
                //هیچ رفت و آمدی به بانک وجود ندارد
                //اطلاعات با دستور ToList() فراخوانی می شود
                //،در این صورت اطلاعات همان سمت پایگاه داده فیلتر می شوند.
                var list = _DetailPlacementTabJobTrainingProvider.GetAll(PlacementTabJobTrainingId).ToList();

                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        } 

        public ActionResult Create()
        {
            try
            {
                OJTLevelProvider _OJTLevelProvider = new OJTLevelProvider();
                OJTLevelEntity _OJTLevelEntity = new OJTLevelEntity();
                ViewBag.OJTLevelId = new SelectList(_OJTLevelProvider.GetAll(), "OJTLevelId", "LevelNumber", _OJTLevelEntity.OJTLevelId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                OJTLevelProvider _OJTLevelProvider = new OJTLevelProvider();
                OJTLevelEntity _OJTLevelEntity = new OJTLevelEntity();
                ViewBag.OJTLevelId = new SelectList(_OJTLevelProvider.GetAll(), "OJTLevelId", "LevelNumber", _OJTLevelEntity.OJTLevelId);

                return View(_DetailPlacementTabJobTrainingProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(DetailPlacementTabJobTrainingEntity Current)
        {
            try
            {
                int result;
                result = _DetailPlacementTabJobTrainingProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(DetailPlacementTabJobTrainingEntity Current)
        {
            try
            {
                bool result;
                result = _DetailPlacementTabJobTrainingProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, _CustomAuthorizeAttribute.UserId(), "", "", Current.DetailPlacementTabJobTrainingId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _DetailPlacementTabJobTrainingProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListDetailPlacementTabJobTraining(int PlacementTabJobTrainingId)
        {
            try
            {
                var list = _DetailPlacementTabJobTrainingProvider.GetAll(PlacementTabJobTrainingId).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.DetailPlacementTabJobTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListDetailPlacementTabJobTraining");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }

}