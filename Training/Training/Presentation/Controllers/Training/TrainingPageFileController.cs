using Bussiness;
using Bussiness.Provider.Training;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.Training
{
    [CustomAuthorize(Roles = "Admin,User", RolesConfigKey = "29")]
    public class TrainingPageFileController : Controller
    {
        private TrainingPageFileProvider _TrainingPageFileProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public TrainingPageFileController()
        {
            _TrainingPageFileProvider = new TrainingPageFileProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: TrainingPageFile
        //public ActionResult Index(int ID)
        //{
        //    try
        //    {
        //        //ViewBag.DetialHistoryTrainingUploadPageId = ID;
        //        //var list = _TrainingPageFileProvider.GetAll(ID).ToList();
        //        //return View(list);
        //        TrainingPageFileEntity _TrainingPageFileEntity;
        //        List<TrainingPageFileEntity> listtrainingpagefileentity = new List<TrainingPageFileEntity>();
        //        ViewBag.DetialHistoryTrainingUploadPageId = ID;
        //        var list = _TrainingPageFileProvider.GetAll(ID).ToList();
        //        foreach (TrainingPageFileEntity item in list)
        //        {
        //            _TrainingPageFileEntity = new TrainingPageFileEntity();
        //            _TrainingPageFileEntity.TimeCreated = item.TimeCreated;
        //            _TrainingPageFileEntity.TrainingPageFileId = item.TrainingPageFileId;
        //            _TrainingPageFileEntity.DetialHistoryTrainingUploadPageId = item.DetialHistoryTrainingUploadPageId;
        //            _TrainingPageFileEntity.FileScan = item.FileScan;
        //            _TrainingPageFileEntity.TrainingPageFileDesc = item.TrainingPageFileDesc;
        //            string base64String = Convert.ToBase64String(item.FileScan, 0, item.FileScan.Length);
        //            _TrainingPageFileEntity.ImageUrl = "data:application/pdf;base64," + base64String;
        //            listtrainingpagefileentity.Add(_TrainingPageFileEntity);
        //        }
        //        return View(listtrainingpagefileentity);
        //    }
        //    catch (Exception e)
        //    {
        //        LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingPageFile, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
        //        _LogErrorProvider.Add(logerrorentity);
        //        return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
        //    }
        //}

        public ActionResult Index(int pageid,int ID)
        {
            try
            {
                int RecordCount = 10;
                int skip = (pageid - 1) * RecordCount;

                TrainingPageFileEntity _TrainingPageFileEntity;
                List<TrainingPageFileEntity> listtrainingpagefileentity = new List<TrainingPageFileEntity>();
                ViewBag.DetialHistoryTrainingUploadPageId = ID;
                var list = _TrainingPageFileProvider.GetAll(ID);

                var list1 = list.OrderBy(a => a.TimeCreated).Skip(skip).Take(RecordCount).ToList();
                foreach (TrainingPageFileEntity item in list1)
                {
                    _TrainingPageFileEntity = new TrainingPageFileEntity();
                    _TrainingPageFileEntity.TimeCreated = item.TimeCreated;
                    _TrainingPageFileEntity.TrainingPageFileId = item.TrainingPageFileId;
                    _TrainingPageFileEntity.DetialHistoryTrainingUploadPageId = item.DetialHistoryTrainingUploadPageId;
                    _TrainingPageFileEntity.FileScan = item.FileScan;
                    _TrainingPageFileEntity.TrainingPageFileDesc = item.TrainingPageFileDesc;
                    string base64String = Convert.ToBase64String(item.FileScan, 0, item.FileScan.Length);
                    _TrainingPageFileEntity.ImageUrl = "data:application/pdf;base64," + base64String;
                    listtrainingpagefileentity.Add(_TrainingPageFileEntity);
                }

                int count = list.Count();
                ViewBag.PageID = pageid;
                ViewBag.Skip = skip + 1;
                int pagecount = count / RecordCount;
                if (pagecount < ((double)count / RecordCount))
                    ViewBag.PageCount = (count / RecordCount) + 1;
                else
                    ViewBag.PageCount = count / RecordCount;

                var list2 = listtrainingpagefileentity.ToList();

                return View(list2);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //[HttpGet]
        //public ActionResult _GetListTrainingPageFile(int ID)
        //{
        //    try
        //    {
        //        TrainingPageFileEntity _TrainingPageFileEntity;
        //        List<TrainingPageFileEntity> listtrainingpagefileentity = new List<TrainingPageFileEntity>();
        //        ViewBag.DetialHistoryTrainingUploadPageId = ID;
        //        var list = _TrainingPageFileProvider.GetAll(ID).ToList();
        //        foreach (TrainingPageFileEntity item in list)
        //        {
        //            _TrainingPageFileEntity = new TrainingPageFileEntity();
        //            _TrainingPageFileEntity.TimeCreated = item.TimeCreated;
        //            _TrainingPageFileEntity.TrainingPageFileId = item.TrainingPageFileId;
        //            _TrainingPageFileEntity.DetialHistoryTrainingUploadPageId = item.DetialHistoryTrainingUploadPageId;
        //            _TrainingPageFileEntity.FileScan = item.FileScan;
        //            _TrainingPageFileEntity.TrainingPageFileDesc = item.TrainingPageFileDesc;
        //            string base64String = Convert.ToBase64String(item.FileScan, 0, item.FileScan.Length);
        //            _TrainingPageFileEntity.ImageUrl = "data:application/pdf;base64," + base64String;
        //            listtrainingpagefileentity.Add(_TrainingPageFileEntity);
        //        }
        //        return View(listtrainingpagefileentity);
        //    }
        //    catch (Exception e)
        //    {
        //        LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingPageFile, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "_GetListTrainingPageFile");
        //        _LogErrorProvider.Add(logerrorentity);
        //        return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
        //    }
        //}

        [HttpGet]
        public ActionResult _GetListTrainingPageFile(int pageid, int ID)
        {
            try
            {
                return this.Index(pageid,ID);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase UploadedFile,int detialhistorytraininguploadpageid,string trainingpagefiledesc)
        {
            try
            {
                int resultCreate;

                TrainingPageFileEntity _TrainingPageFileEntity = new TrainingPageFileEntity();
                _TrainingPageFileEntity.DetialHistoryTrainingUploadPageId = detialhistorytraininguploadpageid;
                _TrainingPageFileEntity.GUID = Guid.NewGuid().ToString();
                _TrainingPageFileEntity.TimeCreated = DateTime.Now;
                _TrainingPageFileEntity.TimeLastModified = DateTime.Now;
                _TrainingPageFileEntity.TrainingPageFileDesc = trainingpagefiledesc;
                byte[] FileByteArray = new byte[UploadedFile.ContentLength];
                UploadedFile.InputStream.Read(FileByteArray, 0, UploadedFile.ContentLength);
                _TrainingPageFileEntity.FileScan = FileByteArray;

                resultCreate = _TrainingPageFileProvider.Add(_TrainingPageFileEntity);
                if (resultCreate > 0)
                {
                    #region Create Operation Log
                    CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                    OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.TrainingPageFile, _CustomAuthorizeAttribute.UserId(), "", "", resultCreate);
                    _OperationLogProvider.Add(operationlogentity);
                    #endregion

                    return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingPageFile, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
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
                result = _TrainingPageFileProvider.Delete(ID);

                #region Create Operation Log
                CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.DeletePost, (int)TableInterfaceValueEntity.Form.TrainingPageFile, _CustomAuthorizeAttribute.UserId(), "", "", ID);
                _OperationLogProvider.Add(operationlogentity);
                #endregion

                return Json(result);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.TrainingPageFile, e.Message, (int)TableInterfaceValueEntity.OperationType.DeletePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }
    }
}