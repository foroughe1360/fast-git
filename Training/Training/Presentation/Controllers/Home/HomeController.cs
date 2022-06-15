using InterfaceEntity;
using Microsoft.Extensions.Hosting;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
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

        public HomeController()
        {
            //Activation with using license file
            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/license.key");
            Stimulsoft.Base.StiLicense.LoadFromFile(path);

            //var path = Path.Combine("./Content/license.key");
            //Stimulsoft.Base.StiLicense.LoadFromFile(path);
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHn0s4gy0Fr5YoUZ9V00Y0igCSFQzwEqYBh/N77k4f0fWXTHW5rqeBNLkaurJDenJ9o97TyqHs9HfvINK18Uwzsc/bG01Rq+x3H3Rf+g7AY92gvWmp7VA2Uxa30Q97f61siWz2dE5kdBVcCnSFzC6awE74JzDcJMj8OuxplqB1CYcpoPcOjKy1PiATlC3UsBaLEXsok1xxtRMQ283r282tkh8XQitsxtTczAJBxijuJNfziYhci2jResWXK51ygOOEbVAxmpflujkJ8oEVHkOA/CjX6bGx05pNZ6oSIu9H8deF94MyqIwcdeirCe60GbIQByQtLimfxbIZnO35X3fs/94av0ODfELqrQEpLrpU6FNeHttvlMc5UVrT4K+8lPbqR8Hq0PFWmFrbVIYSi7tAVFMMe2D1C59NWyLu3AkrD3No7YhLVh7LV0Tttr/8FrcZ8xirBPcMZCIGrRIesrHxOsZH2V8t/t0GXCnLLAWX+TNvdNXkB8cF2y9ZXf1enI064yE5dwMs2fQ0yOUG/xornE";
        }

        public HomeController(IHostingEnvironment hostEnvironment) : this()
        {
            var path = Path.Combine(hostEnvironment.ContentRootPath, "Content\\license.key");

            Stimulsoft.Base.StiLicense.LoadFromFile(path);
        }

        public ActionResult HtmlPage1()
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

        public ActionResult DeletePage(int id,string viewname)
        {
            try
            {
                ViewBag.ID = id;
                ViewBag.ViewName = viewname;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public ActionResult test()
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

        public ActionResult testdate()
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
        public JsonResult Upload(HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                {
                    byte[] FileByteArray = new byte[uploadedFile.ContentLength];
                    uploadedFile.InputStream.Read(FileByteArray, 0, uploadedFile.ContentLength);
                    Attachment newAttchment = new Attachment();
                    newAttchment.FileName = uploadedFile.FileName;
                    newAttchment.FileType = uploadedFile.ContentType;
                    newAttchment.FileContent = FileByteArray;
                    //OperationResult operationResult = attachmentManager.SaveAttachment(newAttchment);
                    //if (operationResult.Success)
                    //{
                    //    string HTMLString = CaptureHelper.RenderViewToString
                    //    ("_AttachmentItem", newAttchment, this.ControllerContext);
                    //    return Json(new
                    //    {
                    //        statusCode = 200,
                    //        status = operationResult.Message,
                    //        NewRow = HTMLString
                    //    }, JsonRequestBehavior.AllowGet);

                    //}
                    //else
                    //{
                    //    return Json(new
                    //    {
                    //        statusCode = 400,
                    //        status = operationResult.Message,
                    //        file = uploadedFile.FileName
                    //    }, JsonRequestBehavior.AllowGet);

                    //}
                }
                return Json(new
                {
                    statusCode = 400,
                    status = "Bad Request! Upload Failed",
                    file = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult ExitProgram()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PageNotFound()
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

        public ActionResult PageError(string ErrorMessage)
        {
            try
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}