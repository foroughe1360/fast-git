using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using InterfaceEntity.Search.IT;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin", RolesConfigKey = "44")]
    public class HardwareEquipmentController : Controller
    {

        private HardwareEquipmentProvider _HardwareEquipmentProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public HardwareEquipmentController()
        {
            _HardwareEquipmentProvider = new HardwareEquipmentProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: HardwareEquipment
        public ActionResult Index()
        {
            try
            {
                var list = _HardwareEquipmentProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // GET: HardwareEquipment/Create
        public ActionResult Create()
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdEquipmentName = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.HardwareEquipment), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // GET: HardwareEquipment/Edit/5
        public ActionResult Edit(int ID)
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdEquipmentNameTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.HardwareEquipment), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                return View(_HardwareEquipmentProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // POST: HardwareEquipment/Create
        [HttpPost]
        public ActionResult Create(HardwareEquipmentEntity Current)
        {
            try
            {
                int result;
                result = _HardwareEquipmentProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.HardwareEquipment, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        // POST: HardwareEquipment/Edit/5
        [HttpPost]
        public ActionResult Edit(HardwareEquipmentEntity Current)
        {
            try
            {
                bool result;
                result = _HardwareEquipmentProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.HardwareEquipment, _CustomAuthorizeAttribute.UserId(), "", "", Current.HardwareEquipmentId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
     
        // POST: HardwareEquipment/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                bool result;
                result = _HardwareEquipmentProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.HardwareEquipment, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListHardwareEquipment(HardwareEquipmentSearch hardwareequipmentsearch)
        {
            try
            {
                #region set null to string.Empty
                if (hardwareequipmentsearch.EquipmentName == null)
                    hardwareequipmentsearch.EquipmentName = string.Empty;

                if (hardwareequipmentsearch.EquipmentModel == null)
                    hardwareequipmentsearch.EquipmentModel = string.Empty;
                #endregion

                List<HardwareEquipmentEntity> _HardwareEquipmentEntity = new List<HardwareEquipmentEntity>();
                if (hardwareequipmentsearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    _HardwareEquipmentEntity = _HardwareEquipmentProvider.GetAll().ToList();
                    return View(_HardwareEquipmentEntity);
                }
                else if (hardwareequipmentsearch.EquipmentName.Trim() == "" && hardwareequipmentsearch.EquipmentName.Trim() == "")
                {
                    _HardwareEquipmentEntity = _HardwareEquipmentProvider.GetAll().ToList();
                    return View(_HardwareEquipmentEntity);
                }
                else if (hardwareequipmentsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    _HardwareEquipmentEntity = _HardwareEquipmentProvider.GetAll(hardwareequipmentsearch).ToList();
                }
                return View(_HardwareEquipmentEntity);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTeacher");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetHardwareEquipmentModel(int hardwareequipmentid)
        {

            /*
            * Wie whonen in shark daneshgah Sharif.
            * Mien wohnung ist auf dem Land,Das is nicht weit von Teharn ,ich bin in zehn Minuten In Tehran.Uber Mieten sind sehr hoch /sehr viel.
            * Es ist sehr ruhig und schön und ganz Klein.
            * Die Häuser sind neu(!=alt) und größ.
            * Es gibt zwie Parks mit sehr altem (Der Baum) Bäume  und ein Gemüsegeschäft und  ein Lebensmittelgeschäft.
            * In dem Park konnen  wir Radfahren und wandern, walking, Football spielen, Tenis spielen(das Tenis)
            * Das Geschäft schließen bis 23:30 Uhr. 
            * Es gibt nicht Cafes und Restaurants , kinos,..
            * Mein Lieblingsplatz ist  (Das) Wohnzimmer.
            * Wie habe ein größtes Wohnzimmer ,Es gibt Dunkelrot und größte (Die) Couch,auf dem ich kann schlafen(Kann ich  darauf schlafen) meine Couch is super bequem(rahat).
            * Links gibt es einen (Der Stuhl)(Die Stühle) und  ein (Das)Bild von meinen Eltern und eine Lampe mit gelber (Die)Farbe  
            * Immer Mache ich die Lampe an. 
            * Ein Bild von meinen Eltern hängt über meinem Schreibtisch. 
            * Es gibt auch einen braunen (Der)Tisch, Auf dem Tisch (gibt es) liegen Weiß (Die) Vase.  
            * Rechts ist ein weißer (Der)Schrank,auf dem Schrank ligen viele Bücher.(Das)Buch.
            * (Der)Fernseher liegt direkt gegenüber (Die) Couch / der Tisch
            * Wir sitzen im Wohnzimmer und sehen fern, trinken Tea, end ....
            * Manchmal Morgen lese ich Deutsch da(dort!=hier). 
            */

            try
            {
                HardwareEquipmentProvider _HardwareEquipmentProvider = new HardwareEquipmentProvider();
                HardwareEquipmentEntity _HardwareEquipmentEntity = new HardwareEquipmentEntity();
                ViewBag.HardwareEquipmentModelId = new SelectList(_HardwareEquipmentProvider.GetAllEquipmentModel(hardwareequipmentid), "HardwareEquipmentId", "EquipmentModel", hardwareequipmentid);

                return Json(ViewBag.HardwareEquipmentModelId);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.HardwareEquipment, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetHardwareEquipmentModelId");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}
