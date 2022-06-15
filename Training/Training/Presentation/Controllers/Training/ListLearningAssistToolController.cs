using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using System.Transactions;
using Presentation.Utility;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User")]
    public class ListLearningAssistToolController : Controller
    {
        private ListLearningAssistToolProvider _ListLearningAssistToolProvider;
        private LogErrorProvider _LogErrorProvider;

        public ListLearningAssistToolController()
        {
            _ListLearningAssistToolProvider = new ListLearningAssistToolProvider();
            _LogErrorProvider = new LogErrorProvider();
        }

        // GET: ListLearningAssistTool
        public ActionResult Index(int ID)
        {
            try
            {
                var list = _ListLearningAssistToolProvider.GetAll(ID).ToList();
                ViewBag.designtrainingcourseid = ID;
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListLearningAssistTool, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListLearningAssistTool, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_ListLearningAssistToolProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListLearningAssistTool, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(ListLearningAssistToolEntity Current)
        {
            try
            {
                _ListLearningAssistToolProvider.Add(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListLearningAssistTool, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Createlist(List<ListLearningAssistToolEntity> Current)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _ListLearningAssistToolProvider.Addlist(Current);
                    scope.Complete();
                }
                return Json(true);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListLearningAssistTool, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "Createlist");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(ListLearningAssistToolEntity Current)
        {
            try
            {
                _ListLearningAssistToolProvider.Edit(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListLearningAssistTool, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                _ListLearningAssistToolProvider.Delete(ID);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListLearningAssistTool, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}