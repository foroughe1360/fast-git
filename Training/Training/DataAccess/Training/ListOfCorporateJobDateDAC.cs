using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class ListOfCorporateJobDateDAC : IListOfCorporateJobDateRepository
    {
        public int Add(ListOfCorporateJobDate Current)
        {
            TrainingContext db = new TrainingContext();
            db.ListOfCorporateJobDates.Add(Current);
            db.SaveChanges();
            return Current.ListOfCorporateJobDateId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var listofcorporatejobdate = new ListOfCorporateJobDate() { ListOfCorporateJobDateId = ID, Hidden = true };
                db.ListOfCorporateJobDates.Attach(listofcorporatejobdate);
                db.Entry(listofcorporatejobdate).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(ListOfCorporateJobDate Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.ListOfCorporateJobDates.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Description).IsModified = true;
                db.Entry(Current).Property(x => x.LOCJDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public ListOfCorporateJobDate Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.ListOfCorporateJobDates.SingleOrDefault(x => x.ListOfCorporateJobDateId == ID);
        }

        public IQueryable<ListOfCorporateJobDate> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.ListOfCorporateJobDates select item;
        }

        public IQueryable<ListOfCorporateJobDateEntity> GetAllListOfCorporateJobDate()
        {
            TrainingContext db = new TrainingContext();
            return
                  (from listofcorporatejobdates in db.ListOfCorporateJobDates.Where(a => a.Hidden == false)
                   select new ListOfCorporateJobDateEntity
                   {
                       ListOfCorporateJobDateId= listofcorporatejobdates.ListOfCorporateJobDateId,
                       Description = listofcorporatejobdates.Description,
                       LOCJDate =listofcorporatejobdates.LOCJDate
                   });
        }
    }
}
