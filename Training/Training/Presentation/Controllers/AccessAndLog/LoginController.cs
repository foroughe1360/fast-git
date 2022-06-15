using Bussiness;
using InterfaceEntity;
using Newtonsoft.Json;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Presentation.Controllers.AccessAndLog
{
    public class LoginController : Controller
    {
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public LoginController()
        {
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        // GET: Login
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

        [HttpPost]
        public ActionResult CheckUser(string userName, string password)
        {
            try
            {
                string _accessmenu = string.Empty;
                LoginProvider _LoginProvider = new LoginProvider();
                AccessMenuUserProvider _AccessMenuUserProvider = new AccessMenuUserProvider();

                var _UserEntity = _LoginProvider.DoesUserExist(userName, password);
                if (_UserEntity != null)
                {
                    var _AccessMenuUserTreeOnly = _AccessMenuUserProvider.GetAllAccessMenuUserTreeOnly(_UserEntity.UserId).ToList();
                    foreach (var item in _AccessMenuUserTreeOnly)
                    {
                        _UserEntity.AccessMenu += item.MenuId + ",";
                    }
                    CustomPrincipalSerializeModel _CustomPrincipalSerializeModel = new CustomPrincipalSerializeModel();
                    _CustomPrincipalSerializeModel.UserId = _UserEntity.UserId;
                    _CustomPrincipalSerializeModel.FirstName = _UserEntity.FirstName;
                    _CustomPrincipalSerializeModel.LastName = _UserEntity.LastName;
                    _CustomPrincipalSerializeModel.role = _UserEntity.Roles;
                    _CustomPrincipalSerializeModel.AccessMenu = _UserEntity.AccessMenu;
                    string userData = JsonConvert.SerializeObject(_CustomPrincipalSerializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1, _UserEntity.UserName, DateTime.Now, DateTime.Now.AddHours(8), false, userData);
                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);


                    //var authTicket = new FormsAuthenticationTicket(1, _UserEntity.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false,_UserEntity.Roles, FormsAuthentication.FormsCookiePath);
                    
                    #region Create Operation Log
                        CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                        OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.LoginUser, (int)TableInterfaceValueEntity.Form.Login, _UserEntity.UserId, "", "", 0);
                        _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Login, e.Message, (int)TableInterfaceValueEntity.OperationType.LoginUser, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }

        }
    }
}