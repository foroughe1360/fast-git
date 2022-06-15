using Bussiness;
using InterfaceEntity;
using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers.BasicInformation
{
    [CustomAuthorize(Roles = "Admin")]
    public class FileRepositoryController : Controller
    {
        private FileRepositoryProvider _FileRepositoryProvider;
        private LogErrorProvider _LogErrorProvider;
        private OperationLogProvider _OperationLogProvider;

        public FileRepositoryController()
        {
            _FileRepositoryProvider = new FileRepositoryProvider();
            _LogErrorProvider = new LogErrorProvider();
            _OperationLogProvider = new OperationLogProvider();
        }

        // GET: FileRepository
        public ActionResult Index()
        {
            try
            {
                var list = _FileRepositoryProvider.GetAll().ToList();
                return View(list);
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FileRepository, e.Message, (int)TableInterfaceValueEntity.OperationType.Index, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        //Get: FileRepository Page
        public ActionResult Create(int contentid,int fileformid)
        {
            try
            {
                ViewBag.ContentId = contentid;
                ViewBag.FileFormId = fileformid;

                TableInterfaceValueProvider _TableInterfaceValueProvider = new TableInterfaceValueProvider();
                TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
                ViewBag.TableInterfaceValueIdFileForm = new SelectList(_TableInterfaceValueProvider.GetTableInterfaceValueDPD((int)TableInterfaceEntity.TableInterface.FileForm), "TableInterfaceValueId", "TableValue", _TableInterfaceValueEntity.TableInterfaceValueId);

                FileRepositoryEntity _FileRepositoryEntity = new FileRepositoryEntity();
                _FileRepositoryEntity = _FileRepositoryProvider.Get(contentid, fileformid);
                if (_FileRepositoryEntity != null)
                {
                    ViewBag.FileRepositoryId = _FileRepositoryEntity.FileRepositoryId;
                    return View(_FileRepositoryEntity);
                }
                else
                {
                    ViewBag.FileRepositoryId = 0;
                    FileRepositoryEntity _FileRepositoryEntity1 = new FileRepositoryEntity();
                    _FileRepositoryEntity1.ContentLength = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                    return View(_FileRepositoryEntity1);
                }
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FileRepository, e.Message, (int)TableInterfaceValueEntity.OperationType.CreateGet, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult GetData(int contentid, int fileformid)
        {
            try
            {
                FileRepositoryEntity _FileRepositoryEntity = new FileRepositoryEntity();
                _FileRepositoryEntity = _FileRepositoryProvider.Get(contentid, fileformid);
                if (_FileRepositoryEntity != null)
                {
                    FileRepositoryEntity _FileRepositoryEntity1 = new FileRepositoryEntity();

                    string base64String = Convert.ToBase64String(_FileRepositoryEntity.ContentLength, 0, _FileRepositoryEntity.ContentLength.Length);
                    _FileRepositoryEntity1.ImageUrl = "data:application/pdf;base64," + base64String;
                    _FileRepositoryEntity1.FileRepositoryId = _FileRepositoryEntity.FileRepositoryId;
                    _FileRepositoryEntity1.ContentId = contentid;
                    _FileRepositoryEntity1.FileFormId = fileformid;
                    _FileRepositoryEntity1.FileName = _FileRepositoryEntity.FileName;
                    return Json(_FileRepositoryEntity1);
                }
                else
                {
                    ViewBag.FileRepositoryId = 0;
                    FileRepositoryEntity _FileRepositoryEntity1 = new FileRepositoryEntity();
                    _FileRepositoryEntity1.ContentLength = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                    _FileRepositoryEntity1.ImageUrl = "/Content/Image/White.jpg";
                    _FileRepositoryEntity1.FileRepositoryId = 0;
                    _FileRepositoryEntity1.ContentId = contentid;
                    _FileRepositoryEntity1.FileFormId = fileformid;
                    return Json(_FileRepositoryEntity1);
                }
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FileRepository, e.Message, (int)TableInterfaceValueEntity.OperationType.Get, "GetData");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase UploadedFile,int FileRepositoryId, int ContentId, int fileformid)
        {
            try
            {
                int resultCreate;
                bool resultEdit;

                FileRepositoryEntity _FileRepositoryEntity = new FileRepositoryEntity();
                _FileRepositoryEntity.FileRepositoryId = FileRepositoryId;
                _FileRepositoryEntity.TimeLastModified = DateTime.Now;
                _FileRepositoryEntity.ContentId = ContentId;
                _FileRepositoryEntity.FileFormId = fileformid;
                _FileRepositoryEntity.FileName = UploadedFile.FileName;
                _FileRepositoryEntity.ContentType = UploadedFile.ContentType;
                byte[] FileByteArray = new byte[UploadedFile.ContentLength];
                UploadedFile.InputStream.Read(FileByteArray, 0, UploadedFile.ContentLength); 
                _FileRepositoryEntity.ContentLength = FileByteArray;
                if (_FileRepositoryProvider.Get(ContentId, fileformid) == null)
                {
                    resultCreate = _FileRepositoryProvider.Add(_FileRepositoryEntity);
                    if (resultCreate > 0)
                    {
                        #region Create Operation Log
                        CustomAuthorizeAttribute _CustomAuthorizeAttribute = new CustomAuthorizeAttribute();
                        OperationLogEntity operationlogentity = new OperationLogEntity(0, "", (int)TableInterfaceValueEntity.OperationType.CreatePost, (int)TableInterfaceValueEntity.Form.FileRepository, _CustomAuthorizeAttribute.UserId(), "", "", resultCreate);
                        _OperationLogProvider.Add(operationlogentity);
                        #endregion

                        return Json(true);
                    }
                    else
                        return Json(false);
                }
                else
                {
                    resultEdit = _FileRepositoryProvider.Edit(_FileRepositoryEntity);
                    return Json(resultEdit);
                }
            }
            catch (Exception e)
            {
                LogErrorEntity logerrorentity = new LogErrorEntity((int)TableInterfaceValueEntity.Form.FileRepository, e.Message, (int)TableInterfaceValueEntity.OperationType.CreatePost, "");
                _LogErrorProvider.Add(logerrorentity);
                return RedirectToAction("PageError", "Home", new { ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int contentid, int fileformid)
        {
            int result = _FileRepositoryProvider.Delete(contentid, fileformid);
            FileRepositoryEntity _FileRepositoryEntity1 = new FileRepositoryEntity();

            _FileRepositoryEntity1.FileRepositoryId = result;
            _FileRepositoryEntity1.ContentId = contentid;
            _FileRepositoryEntity1.FileFormId = fileformid;
            return Json(_FileRepositoryEntity1);
        }

    }
}