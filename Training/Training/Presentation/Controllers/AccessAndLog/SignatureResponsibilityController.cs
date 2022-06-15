using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin", RolesConfigKey = "35")]
    public class SignatureResponsibilityController : Controller
    {

        private SignatureResponsibilityProvider _SignatureResponsibilityProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public SignatureResponsibilityController()
        {
            _SignatureResponsibilityProvider = new SignatureResponsibilityProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: SignatureResponsibility
        public ActionResult Index()
        {
            try
            {
                var list = _SignatureResponsibilityProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SignatureResponsibility, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                UserProvider _UserProvider = new UserProvider();
                UserEntity _UserEntity = new UserEntity();
                ViewBag.UserId = new SelectList(_UserProvider.GetAll(), "UserId", "UserNameFamily", _UserEntity.UserId);


                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.EmployemeId = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SignatureResponsibility, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                UserProvider _UserProvider = new UserProvider();
                UserEntity _UserEntity = new UserEntity();
                ViewBag.UserIdTemp =  new SelectList(_UserProvider.GetAll(), "UserId", "UserNameFamily", _UserEntity.UserId);

                EmployemeProvider _EmployemeProvider = new EmployemeProvider();
                EmployemeEntity _EmployemeEntity = new EmployemeEntity();
                ViewBag.EmployemeIdTemp = new SelectList(_EmployemeProvider.GetAll(), "EmployemeId", "EmployemeName", _EmployemeEntity.EmployemeId);

                return View(_SignatureResponsibilityProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SignatureResponsibility, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public JsonResult Create(HttpPostedFileBase UploadedFile, int userid , int employemeid)
        {
            try
            {
                int result;
                byte[] FileByteArray = new byte[UploadedFile.ContentLength];
                UploadedFile.InputStream.Read(FileByteArray, 0, UploadedFile.ContentLength);
                SignatureResponsibilityEntity _SignatureResponsibilityEntity = new SignatureResponsibilityEntity();
                _SignatureResponsibilityEntity.UserId = 1;// userid;
                _SignatureResponsibilityEntity.Signature = FileByteArray;
                _SignatureResponsibilityEntity.EmployemeId = employemeid;
                result = _SignatureResponsibilityProvider.Add(_SignatureResponsibilityEntity);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.SignatureResponsibility, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SignatureResponsibility, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase UploadedFile, int userid,int SignatureResponsibilityId, int employemeid)
        {
            try
            {
                bool result = false;
                SignatureResponsibilityEntity _SignatureResponsibilityEntity = new SignatureResponsibilityEntity();

                if (UploadedFile != null)
                {
                    byte[] FileByteArray = new byte[UploadedFile.ContentLength];
                    UploadedFile.InputStream.Read(FileByteArray, 0, UploadedFile.ContentLength);
                    _SignatureResponsibilityEntity.Signature = FileByteArray;
                }
                else
                    _SignatureResponsibilityEntity.Signature = null;
                _SignatureResponsibilityEntity.SignatureResponsibilityId = SignatureResponsibilityId;
                _SignatureResponsibilityEntity.UserId = 1;// userid;
                _SignatureResponsibilityEntity.EmployemeId = employemeid;

                result = _SignatureResponsibilityProvider.Edit(_SignatureResponsibilityEntity);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.SignatureResponsibility, _CustomAuthorizeAttribute.UserId(), "", "", SignatureResponsibilityId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SignatureResponsibility, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _SignatureResponsibilityProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.SignatureResponsibility, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SignatureResponsibility, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public ActionResult _GetListSignatureResponsibility()
        {
            try
            {
                var list = _SignatureResponsibilityProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.SignatureResponsibility, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListSignatureResponsibility");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}