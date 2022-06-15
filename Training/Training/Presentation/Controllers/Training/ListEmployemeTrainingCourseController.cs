using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.Training
{
  
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "24")]
    public class ListEmployemeTrainingCourseController : Controller
    {
        private DesignTrainingCourseProvider _DesignTrainingCourseProvider;
        private LogErrorProvider _LogErrorProvider;

        public ListEmployemeTrainingCourseController()
        {
            _DesignTrainingCourseProvider = new DesignTrainingCourseProvider();
            _LogErrorProvider = new LogErrorProvider();

        }
        // GET: ListEmployemeTrainingCourse
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.DesignTrainingCourseDateId = ID;
                var list = _DesignTrainingCourseProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ListTrainingCourse, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}
   