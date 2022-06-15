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
    public class ListEffectivenessOfCourseController : Controller
    {
        private ListEffectivenessOfCourseProvider _ListEffectivenessOfCourseProvider;
        private LogErrorProvider _LogErrorProvider;

        public ListEffectivenessOfCourseController()
        {
            _ListEffectivenessOfCourseProvider = new ListEffectivenessOfCourseProvider();
            _LogErrorProvider = new LogErrorProvider();
        }
        
        // GET: ListEffectivenessOfCourse
        public ActionResult Index(int ID)
        {
            try
            {
                var list = _ListEffectivenessOfCourseProvider.GetAll(ID).ToList();
                ViewBag.designtrainingcourseid = ID;
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListEffectivenessOfCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListEffectivenessOfCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_ListEffectivenessOfCourseProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListEffectivenessOfCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(ListEffectivenessOfCourseEntity Current)
        {
            try
            {
                _ListEffectivenessOfCourseProvider.Add(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListEffectivenessOfCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Createlist(List<ListEffectivenessOfCourseEntity> Current)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _ListEffectivenessOfCourseProvider.Addlist(Current);
                    scope.Complete();
                }
                return Json(true);
            }
            catch(Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListEffectivenessOfCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "Createlist");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(ListEffectivenessOfCourseEntity Current)
        {
            try
            {
                _ListEffectivenessOfCourseProvider.Edit(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListEffectivenessOfCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                _ListEffectivenessOfCourseProvider.Delete(ID);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListEffectivenessOfCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}