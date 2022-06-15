using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ListOfCorporateJob
    {
        public int ListOfCorporateJobId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public int ListOfCorporateJobDateId { get; set; }
        public int CollectionId { get; set; }
        public int PostTypeId { get; set; }
        public int NumberOfPeopleEmployed { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool Hidden { get; set; }

        public ListOfCorporateJob()
        {

        }

        public ListOfCorporateJob(int listofcorporatejobdateid,int collectionid,int posttypeid, int numberofpeopleemployed, string description,int year)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            ListOfCorporateJobDateId = listofcorporatejobdateid;
            CollectionId = collectionid;
            PostTypeId = posttypeid;
            NumberOfPeopleEmployed = numberofpeopleemployed;
            Description = description;
            Year = year;
            Hidden = false;
        }
    }
}
