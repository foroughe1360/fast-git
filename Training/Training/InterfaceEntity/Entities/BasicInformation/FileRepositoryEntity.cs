using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class FileRepositoryEntity: FileRepository
    {
        public string fileformName { get; set; }
        public string ImageUrl { get; set; }
        public FileRepositoryEntity()
        {

        }

        public FileRepositoryEntity(int contentid, string filename, string contenttype, Byte[] contentlength, int fileformid)
            :base(contentid,filename, contenttype, contentlength, fileformid)
        {

        }
    }
}
