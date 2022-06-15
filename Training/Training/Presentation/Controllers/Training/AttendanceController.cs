using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using InterfaceEntity;
using System.Transactions;
using Presentation.Utility;
using InterfaceEntity.Search.Trianing;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin,User")]
    public class AttendanceController : Controller
    {
        private AttendanceProvider _AttendanceProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public AttendanceController()
        {
            _AttendanceProvider = new AttendanceProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }
        
        // GET: Attendance
        public ActionResult Index(int attendancedateid,int designtrainingcourseid,int designtrainingcoursedateid)
        {
            try
            {
                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TypeAttendanceIdTemp = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.TypeAttendance), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);
                ViewBag.DesignTrainingCourseId = designtrainingcourseid;
                ViewBag.DesignTrainingCourseDateId = designtrainingcoursedateid;
                ViewBag.AttendanceDateId = attendancedateid;
                AttendanceDateProvider _AttendanceDateProvider = new AttendanceDateProvider();
                var _CourseDate = _AttendanceDateProvider.getCourseDate(attendancedateid);
                ViewBag.CourseDate = _CourseDate.AttendanceAbsenceDateStr + " نام دوره : " + _CourseDate.CourceName;
                var list = _AttendanceProvider.GetAll(attendancedateid, designtrainingcourseid).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
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
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                return View(_AttendanceProvider.Get(ID));
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(AttendanceEntity Current)
        {
            try
            {
                _AttendanceProvider.Add(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Createlist(List<AttendanceEntity> Current)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _AttendanceProvider.Addlist(Current);
                    scope.Complete();
                }
                return Json(true);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "Createlist");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
        
        [HttpPost]
        public ActionResult Edit(AttendanceEntity Current)
        {
            try
            {
                _AttendanceProvider.Edit(Current);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                _AttendanceProvider.Delete(ID);
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListAttendance(AttendanceSearch attendancesearch)
        {
            try
            {
                var list = _AttendanceProvider.GetAll(attendancesearch.attendancedateid, attendancesearch.designtrainingcourseid).ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.Attendance, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListAttendance");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

    }
}