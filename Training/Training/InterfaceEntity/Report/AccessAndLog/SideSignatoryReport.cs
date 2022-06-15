using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class SideSignatoryReport
    {
        public enum Signatories : int
        {
            //کارشناس بخش آموزش
            EducationalExperts = 1,

            //سرپرست واحد منابع انسانی
            HeadOfHumanResources = 2,

            //سرپرست واحد آموزش و اطلاع رسانی
            HeadOfTrainingAndInformation = 3,

            //راهبر تیم آموزش
            Teamleadertraining = 4,

            //سرپرست آزمایشگاه
            laboratorySupervisor = 5,

            //کارمندان
            Employemer = 6,

            //مدیر /مدیر فنی /سرپرست
            Manger = 7
        }
    }
}
