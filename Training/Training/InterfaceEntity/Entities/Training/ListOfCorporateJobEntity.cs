using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class ListOfCorporateJobEntity: ListOfCorporateJob
    {
        public string collectionName { get; set; }
        public string posttypeName { get; set; }
        public ListOfCorporateJobEntity()
        {

        }

        public ListOfCorporateJobEntity(int listofcorporatejobdateid,int collectionid, int posttypeid, int numberofpeopleemployed, string description,int year)
            :base(listofcorporatejobdateid,collectionid, posttypeid, numberofpeopleemployed, description,year)
        {

        }
    }
}
