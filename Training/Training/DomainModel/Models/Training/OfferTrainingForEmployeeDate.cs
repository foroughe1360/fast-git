﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OfferTrainingForEmployeeDate
    {
        public int OfferTrainingForEmployeeDateId { get; set; }
        public string GUID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public string Description { get; set; }
        public DateTime OTFJDate { get; set; }
        public bool Hidden { get; set; }

        public OfferTrainingForEmployeeDate(string description, DateTime otfjdate)
        {
            GUID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now;
            TimeLastModified = DateTime.Now;
            Description = description;
            OTFJDate = otfjdate;
            Hidden = false;
        }

        public OfferTrainingForEmployeeDate()
        {

        }
    }
}
