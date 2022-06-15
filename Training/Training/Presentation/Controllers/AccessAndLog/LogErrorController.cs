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
    [CustomAuthorize(Roles = "Admin")]
    public class LogErrorController : Controller
    {

        private LogErrorProvider _LogErrorProvider;

        public LogErrorController()
        {
            _LogErrorProvider = new LogErrorProvider();
        }

        // GET: AccessAndLog List
        public ActionResult Index()
        {
            try
            {
                var list = _LogErrorProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(LogErrorEntity Current)
        {
            try
            {
                int result;
                result = _LogErrorProvider.Add(Current);
                if (result > 0)
                    return Json(true);
                else
                    return Json(false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(LogErrorEntity Current)
        {
            try
            {
                bool result;
                result = _LogErrorProvider.Edit(Current);
                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                bool result;
                result = _LogErrorProvider.Delete(ID);
                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}