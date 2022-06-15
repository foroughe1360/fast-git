using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;

namespace DataAccess
{
    public class TariffDAC : ITariffRepository
    {
        public int Add(Tariff Current)
        {
            TrainingContext db = new TrainingContext();
            db.Tariffs.Add(Current);
            db.SaveChanges();
            return Current.TariffId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var tariff = new Tariff() { TariffId = ID, Hidden = true };
                db.Tariffs.Attach(tariff);
                db.Entry(tariff).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Tariff Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Tariffs.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Cost).IsModified = true;
                db.Entry(Current).Property(x => x.CourseTypeId).IsModified = true;
                db.Entry(Current).Property(x => x.TariffDate).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Tariff Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Tariffs.SingleOrDefault(x => x.TariffId == ID);
        }

        public IQueryable<Tariff> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Tariffs select item;
        }

        public IQueryable<TariffEntity> GetAllTariff()
        {
            TrainingContext db = new TrainingContext();
            return
                (from tariffs in db.Tariffs.Where(a => a.Hidden == false)
                 join tableinterfacevalues in db.TableInterfaceValues on tariffs.CourseTypeId equals tableinterfacevalues.TableInterfaceValueId
                 select new TariffEntity
                 {
                     TariffId = tariffs.TariffId,
                     Cost=tariffs.Cost,
                     CourseTypeId=tariffs.CourseTypeId,
                     TariffDate=tariffs.TariffDate,
                     CourseTypeName= tableinterfacevalues.TableValue
                 });

        }
    }
}
