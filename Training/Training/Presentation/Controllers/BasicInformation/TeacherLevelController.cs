using Bussiness;
using InterfaceEntity;
using InterfaceEntity.Entities.BasicInformation;
using InterfaceEntity.Search.BasicInformation;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [CustomAuthorize(Roles = "Admin", RolesConfigKey = "9")]
    public class TeacherLevelController : Controller
    {
        private TeacherLevelProvider _TeacherLevelProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public TeacherLevelController()
        {
            _TeacherLevelProvider = new TeacherLevelProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: AccessAndLog List
        public ActionResult Index(int ID)
        {
            try
            {
                string[] tokens;
                ViewBag.TeacherLevelDateId = ID;
                List<TeacherLevelEntity> ListTeacherLevelEntity = new List<TeacherLevelEntity>();

                var listTeacherLevel = _TeacherLevelProvider.GetAll(ID).ToList();

                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                var listTrainingCourse = _TrainingCourseProvider.GetAll().ToList();

                foreach (TeacherLevelEntity item in listTeacherLevel)
                {
                    if (item.TrainingCourse != null)
                    {
                        tokens = item.TrainingCourse.Split(',');
                        foreach (string item1 in tokens)
                        {
                            if (item.TrainingCourseName != null)
                                item.TrainingCourseName += " - ";
                            item.TrainingCourseName += listTrainingCourse.FirstOrDefault(a => a.TrainingCourseId == double.Parse(item1)).CourseName;
                        }
                    }
                    ListTeacherLevelEntity.Add(item);
                }

                return View(ListTeacherLevelEntity);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Create()
        {
            try
            {
                TeacherProvider _TeacherProvider = new TeacherProvider();
                TeacherEntity _TeacherEntity = new TeacherEntity();
                ViewBag.TeacherId = new SelectList(_TeacherProvider.GetAll(), "TeacherId", "TeacherName", _TeacherEntity.TeacherId);

                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                ViewBag.TrainingCourseId = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: AccessAndLog Page
        public ActionResult Edit(int ID)
        {
            try
            {
                TeacherProvider _TeacherProvider = new TeacherProvider();
                TeacherEntity _TeacherEntity = new TeacherEntity();
                ViewBag.TeacherIdTemp = new SelectList(_TeacherProvider.GetAll(), "TeacherId", "TeacherName", _TeacherEntity.TeacherId);

                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                TrainingCourseEntity _TrainingCourseEntity = new TrainingCourseEntity();
                ViewBag.TrainingCourseIdTemp = new SelectList(_TrainingCourseProvider.GetAll(), "TrainingCourseId", "CourseName", _TrainingCourseEntity.TrainingCourseId);

                var listTrainingCourse = _TrainingCourseProvider.GetAll().ToList();

                var TeacherLevel = _TeacherLevelProvider.Get(ID);
                if (TeacherLevel.TrainingCourse != null)
                {
                    string[] tokens = TeacherLevel.TrainingCourse.Split(',');

                    SampleTableCourse _SampleTableCourse;

                    List<SampleTableCourse> _ListSampleTableCourse = new List<SampleTableCourse>();

                    foreach (var item in tokens)
                    {
                        _SampleTableCourse = new SampleTableCourse();
                        _SampleTableCourse.TrainingCourseId = item;
                        _SampleTableCourse.TrainingCourseValue = listTrainingCourse.FirstOrDefault(a => a.TrainingCourseId == int.Parse(item)).CourseName;
                        _ListSampleTableCourse.Add(_SampleTableCourse);
                    }
                    ViewBag.SampleTableCourse = _ListSampleTableCourse;
                }
                else
                    ViewBag.SampleTableCourse = null;


                return View(TeacherLevel);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.EditGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult Print()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.PrintGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult StiReport(int ID)
        {
            try
            {
                List<TeacherLevelEntity> listteacherlevelentity1 = new List<TeacherLevelEntity>();
                List<TeacherLevelEntity> listteacherlevelentity2 = new List<TeacherLevelEntity>();

                NameOfSignatoryProvider nameofsignatoryprovider = new NameOfSignatoryProvider();
                var GetNameOfSignatory = nameofsignatoryprovider.GetListNameOfSignatory().ToList();
                General _General = new General();


                var TeacherLevel = _TeacherLevelProvider.GetAll(ID).ToList();
                foreach (var item in TeacherLevel)
                {
                    if (item.Total >= 80)
                        item.Degree = 1;
                    else if (item.Total >= 60 && item.Total < 80)
                        item.Degree = 2;
                    else
                        item.Degree = 0;
                    listteacherlevelentity1.Add(item);

                }

                string[] tokens;
                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();
                var listTrainingCourse = _TrainingCourseProvider.GetAll().ToList();

                SetDateForReportProvider _SetDateForReportProvider = new SetDateForReportProvider();
                int ReportNameId = (int)ReportName.ReportNames.TeacherLevel;
                var _SetDateForReport = _SetDateForReportProvider.GetAllSetDateForReport(ID, ReportNameId);

                foreach (TeacherLevelEntity item in listteacherlevelentity1)
                {
                    if (item.TrainingCourse != null)
                    {
                        tokens = item.TrainingCourse.Split(',');
                        foreach (string item1 in tokens)
                        {
                            if (item.TrainingCourseName != null)
                                item.TrainingCourseName += " - ";
                            item.TrainingCourseName += listTrainingCourse.FirstOrDefault(a => a.TrainingCourseId == double.Parse(item1)).CourseName;
                        }
                    }
                    //نمایش تاریخ تایید و تهیه و تصویب
                    item.DateOfApproverStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfApprover);
                    item.DateOfProducerStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfProducer);
                    item.DateOfRegistrarStr = _General.MiladiToShamsi(_SetDateForReport.FirstOrDefault().DateOfRegistrar);
                    //
                    listteacherlevelentity2.Add(item);
                }


                // ایجاد شی جدید
                var mainReport = new Stimulsoft.Report.StiReport();
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/FilesReport/TeacherLevel.mrt"));
                // 
                mainReport.Compile();
                // معرفی نام business object تعریف شده در فایل استیمول + ارسال مدل
                mainReport.RegBusinessObject("TeacherLevel_business", listteacherlevelentity2);
                // 

                ///mainReport["HeadOfTrainingAndInformation"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;
                mainReport["Teamleadertraining"] = GetNameOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.Teamleadertraining).Specifications;


                EmployemeSignaturyProvider employemesignaturyprovider = new EmployemeSignaturyProvider();
                var GetEmployemeSOfSignatory = employemesignaturyprovider.GetListEmployemeSignatury().ToList();
                mainReport["HeadOfTrainingAndInformation"] = GetEmployemeSOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Specifications;

                //امضاء تائید کننده : راهبر تیم آموزش
                byte[] arraySignature = GetEmployemeSOfSignatory.FirstOrDefault(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.HeadOfTrainingAndInformation).Signature;
                MemoryStream ms = new MemoryStream(arraySignature);
                System.Drawing.Image imageSignature = System.Drawing.Image.FromStream(ms);
                mainReport["SignatureOFHeadOfTrainingAndInformation"] = imageSignature;

                //امضاء تهیه کننده : سرپرست واحد آموزش و اطلاع رسانی
                byte[] arraySignatureOFTeamleadertraining = GetEmployemeSOfSignatory.Where(a => a.SideSignatoryCode == (int)SideSignatoryReport.Signatories.Teamleadertraining).Select(a => a.Signature).FirstOrDefault(); ;
                MemoryStream msSignatureOFTeamleadertraining = new MemoryStream(arraySignatureOFTeamleadertraining);
                System.Drawing.Image imageSignatureOFTeamleadertraining = System.Drawing.Image.FromStream(msSignatureOFTeamleadertraining);
                mainReport["SignatureOFTeamleadertraining"] = imageSignatureOFTeamleadertraining;

                //ارسال دیتا به گزارش ساز را انجام می دهد
                //1400 12 23 ADD COMMENT
                return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportResult(mainReport);
                //return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);


            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.StiReport, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        public ActionResult ViewerEvent()
        {
            try
            {
                //return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
                return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult();
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.ViewerEvent, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(TeacherLevelEntity Current)
        {
            try
            {
                int result;
                result = _TeacherLevelProvider.Add(Current);
                if (result > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.TeacherLevel, _CustomAuthorizeAttribute.UserId(), "", "", result);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(TeacherLevelEntity Current)
        {
            try
            {
                bool result;
                result = _TeacherLevelProvider.Edit(Current);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.EditPost, (int)TableInterfaceValueEntity.Form.TeacherLevel, _CustomAuthorizeAttribute.UserId(), "", "", Current.TeacherLevelId);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.EditPost, "");
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
                result = _TeacherLevelProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.TeacherLevel, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult _GetListTeacherLevel(TeacherLevelSearch teacherlevelsearch)
        {
            try
            {
                string[] tokens;
                ViewBag.TeacherLevelDateId = teacherlevelsearch.TeacherLevelDateId;
                List<TeacherLevelEntity> TeacherLevelEntity = new List<TeacherLevelEntity>();
                List<TeacherLevelEntity> ListTeacherLevelEntity = new List<TeacherLevelEntity>();

                //var listTeacherLevel = _TeacherLevelProvider.GetAll(teacherlevelsearch.TeacherLevelDateId).ToList();

                TrainingCourseProvider _TrainingCourseProvider = new TrainingCourseProvider();


                #region set null to string.Empty
                if (teacherlevelsearch.TeacherName == null)
                    teacherlevelsearch.TeacherName = string.Empty;
                #endregion

                if (teacherlevelsearch.typesearch == (int)TypeSearch.typesearch.WithoutParameter)
                {
                    TeacherLevelEntity = _TeacherLevelProvider.GetAll(teacherlevelsearch.TeacherLevelDateId).ToList();

                }
                else if (teacherlevelsearch.TeacherName.Trim() == "")
                {
                    TeacherLevelEntity = _TeacherLevelProvider.GetAll(teacherlevelsearch.TeacherLevelDateId).ToList();

                }
                else if (teacherlevelsearch.typesearch == (int)TypeSearch.typesearch.WithParameter)
                {
                    TeacherLevelEntity = _TeacherLevelProvider.GetAll(teacherlevelsearch).ToList();
                }



                var listTrainingCourse = _TrainingCourseProvider.GetAll().ToList();

                foreach (TeacherLevelEntity item in TeacherLevelEntity)
                {
                    if (item.TrainingCourse != null)
                    {
                        tokens = item.TrainingCourse.Split(',');
                        foreach (string item1 in tokens)
                        {
                            if (item.TrainingCourseName != null)
                                item.TrainingCourseName += " - ";
                            item.TrainingCourseName += listTrainingCourse.FirstOrDefault(a => a.TrainingCourseId == int.Parse(item1)).CourseName;
                        }
                    }
                    ListTeacherLevelEntity.Add(item);
                }

                return View(ListTeacherLevelEntity);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TeacherLevel, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTeacherLevel");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}