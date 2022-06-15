using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using Presentation.Utility;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User")]
    public class CourseObjectivesEffectivenessTrainingController : Controller
    {
        private EffectivenessTrainingProvider _EffectivenessTrainingProvider;
        private CourseObjectivesEffectivenessTrainingProvider _CourseObjectivesEffectivenessTrainingProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public CourseObjectivesEffectivenessTrainingController()
        {
            _EffectivenessTrainingProvider = new EffectivenessTrainingProvider();
            _CourseObjectivesEffectivenessTrainingProvider = new CourseObjectivesEffectivenessTrainingProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: CourseObjectivesEffectivenessTraining
        public ActionResult Index(int ID)
        {
            try
            {
                //IDبرابر است با  CourseRegistrationId
                ViewBag.CourseRegistrationId = ID;
                //ViewBag.EffectivenessTrainingId = ID;

                var listEffectivenessTraining = _EffectivenessTrainingProvider.Get(ID);

                if (listEffectivenessTraining != null)
                {
                    ViewBag.EffectivenessTrainingId = listEffectivenessTraining.EffectivenessTrainingId;
                    ViewBag.CourseRegistrationId = listEffectivenessTraining.CourseRegistrationId;
                    ViewBag.SupervisorId = listEffectivenessTraining.SupervisorId;
                    ViewBag.SupervisorName = "شش";//listEffectivenessTraining.SupervisorName;
                    ViewBag.PostGroupName = listEffectivenessTraining.PostGroupName;
                    ViewBag.Correctiveaction = listEffectivenessTraining.Correctiveaction;
                    ViewBag.CorrectiveactionDescription = listEffectivenessTraining.CorrectiveactionDescription;
                    ViewBag.EffectivenessTrainingDate = listEffectivenessTraining.EffectivenessTrainingDate;
                }
                else
                {
                    ViewBag.EffectivenessTrainingId = 0;
                    ViewBag.CourseRegistrationId = 0;
                    ViewBag.SupervisorId = 0;
                    ViewBag.SupervisorName = 0;
                    ViewBag.PostGroupName = 0;
                    ViewBag.Correctiveaction = 0;
                    ViewBag.CorrectiveactionDescription = 0;
                    ViewBag.EffectivenessTrainingDate = null;
                }

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdCourseObjective = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.CourseObjective), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                var list = _CourseObjectivesEffectivenessTrainingProvider.GetAll(1).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseObjectivesEffectivenessTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseObjectivesEffectivenessTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_CourseObjectivesEffectivenessTrainingProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseObjectivesEffectivenessTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(CourseObjectivesEffectivenessTrainingEntity Current)
        {
            try
            {
                _CourseObjectivesEffectivenessTrainingProvider.Add(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseObjectivesEffectivenessTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(CourseObjectivesEffectivenessTrainingEntity Current)
        {
            try
            {
                _CourseObjectivesEffectivenessTrainingProvider.Edit(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseObjectivesEffectivenessTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete( int ID)
        {
            try
            {
                _CourseObjectivesEffectivenessTrainingProvider.Delete(ID);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.CourseObjectivesEffectivenessTraining, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}