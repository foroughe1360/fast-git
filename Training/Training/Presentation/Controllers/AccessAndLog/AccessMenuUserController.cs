
using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AccessMenuUserController : Controller
    {
        private AccessMenuUserProvider _AccessMenuUserProvider;
        private LogErrorProvider _LogErrorProvider;
        
        public AccessMenuUserController()
        {
            _AccessMenuUserProvider = new AccessMenuUserProvider();
            _LogErrorProvider = new LogErrorProvider();
        }

        // GET: AccessMenuUser List
        public ActionResult Index(int ID)
        {
            try
            {
                ViewBag.UserIDTree = ID;

                UserProvider _UserProvider = new UserProvider();
                UserEntity _UserEntity = new UserEntity();
                ViewBag.UserId = new SelectList(_UserProvider.GetAll(), "UserId", "UserNameFamily", _UserEntity.UserId);

                var list = _AccessMenuUserProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser,e.Message,(int)TableInterfaceValueEntity.OperationType.Index,"");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessMenuUser Page
        public ActionResult Create()
        {
            try
            {
                UserProvider _UserProvider = new UserProvider();
                UserEntity _UserEntity = new UserEntity();
                ViewBag.UserId = new SelectList(_UserProvider.GetAll(), "UserId", "UserNameFamily", _UserEntity.UserId);

                MenuProvider _MenuProvider = new MenuProvider();
                MenuEntity _MenuEntity = new MenuEntity();
                ViewBag.MenuId = new SelectList(_MenuProvider.GetAll(), "MenuId", "Name", _MenuEntity.MenuId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdAccessType = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.AccessType), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);


                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessMenuUser Page
        public ActionResult Edit(int ID)
        {
            try
            {
                UserProvider _UserProvider = new UserProvider();
                UserEntity _UserEntity = new UserEntity();
                ViewBag.UserIdTemp = new SelectList(_UserProvider.GetAll(), "UserId", "UserNameFamily", _UserEntity.UserId);

                MenuProvider _MenuProvider = new MenuProvider();
                MenuEntity _MenuEntity = new MenuEntity();
                ViewBag.MenuIdTemp = new SelectList(_MenuProvider.GetAll(), "MenuId", "Name", _MenuEntity.MenuId);

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdAccessTypeTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.AccessType), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                return View(_AccessMenuUserProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(List<AccessMenuUserEntity> Current)
        {
            try
            {
                bool result;
                using (TransactionScope scope = new TransactionScope())
                {
                    result = _AccessMenuUserProvider.AddList(Current);
                    if (result== false)
                        return Json(false);
                   
                    scope.Complete();
                }
                return Json(true);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(AccessMenuUserEntity Current)
        {
            try
            {
                bool result;
                result = _AccessMenuUserProvider.Edit(Current);
                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _AccessMenuUserProvider.Delete(ID);
                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message }); 
            }
        }

        [HttpGet]
        public ActionResult _GetListAccessMenuUser(int ID)
        {
            try
            {
                var list = _AccessMenuUserProvider.GetAll(ID).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListAccessMenuUser");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetAllAccessMenuUserTree(int ID)
        {
            try
            {
                var list = _AccessMenuUserProvider.GetAllAccessMenuUserTree(ID).ToList();
                return Json(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetAllAccessMenuUserTree");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetAllAccessMenuUserTreeOnly(int ID)
        {
            try
            {
                var list = _AccessMenuUserProvider.GetAllAccessMenuUserTreeOnly(ID).ToList();
                return Json(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.AccessMenuUser, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetAllAccessMenuUserTreeOnly");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}