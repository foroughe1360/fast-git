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
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "10")]
    public class ReportOfEmployemeController : Controller
    {
        private EmployemeProvider _EmployemeProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public ReportOfEmployemeController()
        {
            _EmployemeProvider = new EmployemeProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();

        }
        // GET: ReportOfEmployeme
        public ActionResult Index()
        {
            var list = _EmployemeProvider.GetAllForReport().ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult _GetListReportOfEmployeme()
        {
            try
            {
                var list = _EmployemeProvider.GetAllForReport().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.ReportOfEmployeme, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListReportOfEmployeme");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}