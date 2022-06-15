using Bussiness;
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
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "29")]
    public class PlacementTabJobTrainingDateController : Controller
    {
        private PlacementTabJobTrainingDateProvider _PlacementTabJobTrainingDateProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;
        private PlacementTabJobTrainingProvider _PlacementTabJobTrainingProvider;
        private PlacementTabJobTrainingEntity _placementtabjobtrainingentity;
        private DetailPlacementTabJobTrainingProvider detailplacementtabjobtrainingprovider;
        private DetailPlacementTabJobTrainingEntity detailplacementtabjobtrainingentity;

        public PlacementTabJobTrainingDateController()
        {
            _PlacementTabJobTrainingDateProvider = new PlacementTabJobTrainingDateProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        
        // GET: PlacementTabJobTrainingDate
        public ActionResult Index()
        {
            try
            {
                var list = _PlacementTabJobTrainingDateProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: OfferTrainingForJobDate Page
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: OfferTrainingForJobDate Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_PlacementTabJobTrainingDateProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult CopyPlacementTabJobTraining()
        {
            PlacementTabJobTrainingDateEntity placementtabjobtrainingdateentity = new PlacementTabJobTrainingDateEntity();
            var list = _PlacementTabJobTrainingDateProvider.GetAll();
            ViewBag.ptjtSource = new SelectList(list, "PlacementTabJobTrainingDateId", "Description", placementtabjobtrainingdateentity.PlacementTabJobTrainingDateId);
            ViewBag.ptjtDestination = new SelectList(list, "PlacementTabJobTrainingDateId", "Description", placementtabjobtrainingdateentity.PlacementTabJobTrainingDateId);

            return View();
        }

        [HttpPost]
        public ActionResult Create(PlacementTabJobTrainingDateEntity Current)
        {
            try
            {
                int result;
                result = _PlacementTabJobTrainingDateProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(PlacementTabJobTrainingDateEntity Current)
        {
            try
            {
                bool result;
                result = _PlacementTabJobTrainingDateProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, _CustomAuthorizeAttribute.UserId(), "", "", Current.PlacementTabJobTrainingDateId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _PlacementTabJobTrainingDateProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult CopyPlacementTabJobTraining(int sourceid, int destinationid)
        {
            try
            {
                _PlacementTabJobTrainingProvider = new PlacementTabJobTrainingProvider();
                detailplacementtabjobtrainingprovider = new DetailPlacementTabJobTrainingProvider();
                using (TransactionScope scope = new TransactionScope())
                {
                   

                    var listsource = _PlacementTabJobTrainingProvider.GetAllPlacementTabJobTraining(sourceid, destinationid).ToList();
                    foreach (var item in listsource)
                    {
                        _placementtabjobtrainingentity = new PlacementTabJobTrainingEntity(destinationid, item.EmployemeId, 
                            item.SectionId,item.PostGroupId, item.DateStartPostGroupName, item.PreviousJobs,item.CorporateResponsibility);
                        _PlacementTabJobTrainingProvider.Add(_placementtabjobtrainingentity);
                    }

                    //var listdestination = _PlacementTabJobTrainingProvider.GetAllPlacementTabJobTraining(destinationid);
                    var listdetailplacementtabjobtraining = detailplacementtabjobtrainingprovider.GetAllDetailPlacementTabJobTraining(sourceid, destinationid).ToList();
                    foreach (var item in listdetailplacementtabjobtraining)
                    {
                        detailplacementtabjobtrainingentity = new DetailPlacementTabJobTrainingEntity(item.PlacementTabJobTrainingId,
                            item.Title, item.FinalComment, item.NumberOfHours, item.OJTLevelId);
                        detailplacementtabjobtrainingprovider.Add(detailplacementtabjobtrainingentity);
                    }

                    scope.Complete();
                    return Json(true);
                }
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpGet]
        public ActionResult _GetListPlacementTabJobTrainingDate()
        {
            try
            {
                var list = _PlacementTabJobTrainingDateProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.PlacementTabJobTrainingDate, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListPlacementTabJobTrainingDate");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}