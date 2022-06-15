using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  public  class HardwareNameDAC : IHardwareNameRepository
    {

        public int Add( HardwareName Current)
        {
            using (TrainingContext db = new TrainingContext())
            {
                try
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.HardwareNames.Add(Current);
                    db.SaveChanges();
                }
                finally
                {
                    db.Configuration.AutoDetectChangesEnabled = true;
                }
            }
            return Current. HardwareNameId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();

                var  HardwareName = new  HardwareName() {  HardwareNameId = ID, Hidden = true };
                db.HardwareNames.Attach( HardwareName);
                db.Entry( HardwareName).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit( HardwareName Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.HardwareNames.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.HardwareTitle).IsModified = true;
                db.Entry(Current).Property(x => x.State).IsModified = true;
                db.Entry(Current).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public  HardwareName Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.HardwareNames.SingleOrDefault(x => x. HardwareNameId == ID);

        }
        public IQueryable< HardwareName> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.HardwareNames select item;
        }

        //public IQueryable< HardwareNameEntity> GetAll HardwareNameModel( HardwareNameSearch  HardwareNamesearch)
        //{
        //    TrainingContext db = new TrainingContext();
        //    var list =
        //        (from  HardwareNames in db. HardwareNames.Where(a => a.Hidden == false)
        //         select new  HardwareNameEntity
        //         {
        //              HardwareNameId =  HardwareNames. HardwareNameId,
        //             HardwareTitle =  HardwareNames.HardwareTitle,
                     
        //         });
        //    if ( HardwareNamesearch.EquipmentName.Trim() != "")
        //        list = list.Where(p => p.EquipmentName.Contains( HardwareNamesearch.EquipmentName));

        //    if ( HardwareNamesearch.EquipmentModel.Trim() != "")
        //        list = list.Where(p => p.EquipmentModel.Contains( HardwareNamesearch.EquipmentModel));

        //    return list;
        //}


    }
}
