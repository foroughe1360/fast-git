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
    [CustomAuthorize(Roles = "Admin,User")]
    public class ListTypeTestScoreController : Controller
    {
        private ListTypeTestScoreProvider _ListTypeTestScoreProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public ListTypeTestScoreController()
        {
            _ListTypeTestScoreProvider = new ListTypeTestScoreProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        // GET: ListTypeTestScore
        public ActionResult Index(int ID,int designtrainingcoursedateid)
        {
            try
            {
                var list = _ListTypeTestScoreProvider.GetAll(ID);
                ViewBag.DesignTrainingCourseId = ID;
                ViewBag.DesignTrainingCourseDateId = designtrainingcoursedateid;
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTypeTestScore, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //انواع آزمون
                ViewBag.TableInterfaceIdVarietyOfTest = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.VarietyOfTest), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTypeTestScore, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                //انواع آزمون
                ViewBag.TableInterfaceIdVarietyOfTestTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.VarietyOfTest), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);


                return View(_ListTypeTestScoreProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTypeTestScore, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(ListTypeTestScoreEntity Current)
        {
            try
            {
                int result;
                result = _ListTypeTestScoreProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.ListTypeTestScore, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTypeTestScore, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(ListTypeTestScoreEntity Current)
        {
            try
            {
                bool result;
                result = _ListTypeTestScoreProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.ListTypeTestScore, _CustomAuthorizeAttribute.UserId(), "", "", Current.ListTypeTestScoreId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTypeTestScore, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _ListTypeTestScoreProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.ListTypeTestScore, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTypeTestScore, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListListTypeTestScore(int designtrainingcourseid, int designtrainingcoursedateid)
        {
            try
            {
                var list = _ListTypeTestScoreProvider.GetAll(designtrainingcourseid);
                ViewBag.DesignTrainingCourseId = designtrainingcourseid;
                //970319
                ViewBag.DesignTrainingCourseDateId = designtrainingcoursedateid;
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTypeTestScore, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListListTypeTestScore");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}