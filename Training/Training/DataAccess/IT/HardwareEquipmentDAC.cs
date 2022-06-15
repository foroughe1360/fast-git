using DataAccess.InfraStructre;
using DomainModel.Models;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.IT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HardwareEquipmentDAC : IHardwareEquipmentRepository
    {

        public int Add(HardwareEquipment Current)
        {
            using (TrainingContext db = new TrainingContext())
            {
                try
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.HardwareEquipments.Add(Current);
                    db.SaveChanges();
                }
                finally
                {
                    db.Configuration.AutoDetectChangesEnabled = true;
                }
            }
            return Current.HardwareEquipmentId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();

                var HardwareEquipment = new HardwareEquipment() { HardwareEquipmentId = ID, Hidden = true };
                db.HardwareEquipments.Attach(HardwareEquipment);
                db.Entry(HardwareEquipment).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(HardwareEquipment Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.HardwareEquipments.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.EquipmentNameId).IsModified = true;
                db.Entry(Current).Property(x => x.EquipmentModel).IsModified = true;
                db.Entry(Current).Property(x => x.PropertyNumber).IsModified = true;
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

        public HardwareEquipment Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.HardwareEquipments.SingleOrDefault(x => x.HardwareEquipmentId == ID);

        }
        public IQueryable<HardwareEquipment> GetAll()
        {
            TrainingContext db = new TrainingContext();
            var list =
                (from hardwareequipments in db.HardwareEquipments.Where(a => a.Hidden == false)
                 select new HardwareEquipmentEntity
                 {
                     HardwareEquipmentId = hardwareequipments.HardwareEquipmentId,
                     EquipmentNameId = hardwareequipments.EquipmentNameId,
                     EquipmentModel = hardwareequipments.EquipmentModel,
                     PropertyNumber = hardwareequipments.PropertyNumber,
                     State = hardwareequipments.State,
                 });
            return list;
        }

        public IQueryable<HardwareEquipmentEntity> GetAllHardwareEquipment()
        {
            TrainingContext db = new TrainingContext();
            var list =
                (from hardwareequipments in db.HardwareEquipments.Where(a => a.Hidden == false)
                 join tableinterfacevalues in db.TableInterfaceValues on hardwareequipments.EquipmentNameId equals tableinterfacevalues.TableInterfaceValueId
                 select new HardwareEquipmentEntity
                 {
                     HardwareEquipmentId = hardwareequipments.HardwareEquipmentId,
                     EquipmentNameId = hardwareequipments.EquipmentNameId,
                     EquipmentName = tableinterfacevalues.TableValue,
                     EquipmentModel = hardwareequipments.EquipmentModel,
                     PropertyNumber = hardwareequipments.PropertyNumber,
                     State = hardwareequipments.State,
                 });
            return list;
        }

        public IQueryable<HardwareEquipmentEntity> GetAllHardwareEquipmentModel(HardwareEquipmentSearch hardwareequipmentsearch)
        {
            TrainingContext db = new TrainingContext();
            var list =
                (from hardwareequipments in db.HardwareEquipments.Where(a => a.Hidden == false)
                 join tableinterfacevalues in db.TableInterfaceValues on hardwareequipments.EquipmentNameId equals tableinterfacevalues.TableInterfaceValueId

                 select new HardwareEquipmentEntity
                 {
                     HardwareEquipmentId = hardwareequipments.HardwareEquipmentId,
                     EquipmentNameId = hardwareequipments.EquipmentNameId,
                     EquipmentName = tableinterfacevalues.TableValue,
                     EquipmentModel = hardwareequipments.EquipmentModel,
                 });
            if (hardwareequipmentsearch.EquipmentName.Trim() != "")
                list = list.Where(p => p.EquipmentName.Contains(hardwareequipmentsearch.EquipmentName));

            if (hardwareequipmentsearch.EquipmentModel.Trim() != "")
                list = list.Where(p => p.EquipmentModel.Contains(hardwareequipmentsearch.EquipmentModel));

            return list;
        }


        public IQueryable<HardwareEquipmentEntity> GetAllEquipmentModel(int hardwareequipmentid)
        {
            TrainingContext db = new TrainingContext();

            var EquipmentNameId = from h in db.HardwareEquipments
                                  where h.Hidden == false && h.HardwareEquipmentId == hardwareequipmentid
                                  select h.EquipmentNameId;
            int equipmentnameid = EquipmentNameId.First();
            var list =
                (from hardwareequipments in db.HardwareEquipments.Where(a => a.Hidden == false && a.EquipmentNameId == equipmentnameid)
                 join tableinterfacevalues in db.TableInterfaceValues on hardwareequipments.EquipmentNameId equals tableinterfacevalues.TableInterfaceValueId
                 select new HardwareEquipmentEntity
                 {
                     HardwareEquipmentId = hardwareequipments.HardwareEquipmentId,
                     EquipmentModel = hardwareequipments.EquipmentModel,
                 });

            return list;
        }

    }
}
