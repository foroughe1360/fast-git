using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class FileRepository
    {
        public int FileRepositoryId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ContentId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public Byte[] ContentLength { get; set; }
        public int FileFormId { get; set; }
        public bool Hidden { get; set; }

        public FileRepository()
        {

        }

        public FileRepository(int contentid,string filename,string contenttype,Byte[] contentlength,int fileformid)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            ContentId = contentid;
            FileName = filename;
            ContentType = contenttype;
            ContentLength = contentlength;
            FileFormId = fileformid;
            Hidden = false;
        }
    }
}
