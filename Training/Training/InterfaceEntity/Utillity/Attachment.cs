using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class Attachment
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }

        public Attachment()
        {

        }

        public Attachment(string filename, string filetype, byte[] filecontent)
        {
            FileName = filename;
            FileType = filetype;
            FileContent = filecontent;
        }
    }
}
