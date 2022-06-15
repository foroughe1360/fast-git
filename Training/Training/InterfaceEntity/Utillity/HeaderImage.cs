using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class HeaderImage
    {
        public Byte[] ImageData { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public HeaderImage()
        {

        }

        public HeaderImage(Byte[] imagedata, string imagename, bool isactive)
        {
            ImageData = imagedata;
            ImageName = imagename;
            IsActive = isactive;
        }
    }
}
