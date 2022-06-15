using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Entities;
using InterfaceEntity.Search.IT;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HardwareInformationDAC : IHardwareInformationRepository
    {
        public int Add(HardwareInformation Current)
        {
            using (TrainingContext db = new TrainingContext())
            {
                try
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.HardwareInformations.Add(Current);
                    db.SaveChanges();
                }
                finally
                {
                    db.Configuration.AutoDetectChangesEnabled = true;
                }
            }
            return Current.HardwareInformationId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();

                var HardwareInformation = new HardwareInformation() { HardwareInformationId = ID, Hidden = true };
                db.HardwareInformations.Attach(HardwareInformation);
                db.Entry(HardwareInformation).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(HardwareInformation Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.HardwareInformations.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.HardwareEquipmentId).IsModified = true;
                db.Entry(Current).Property(x => x.NetworkID).IsModified = true;
                db.Entry(Current).Property(x => x.NetworkIP).IsModified = true;
                db.Entry(Current).Property(x => x.Descriptions).IsModified = true;
                db.Entry(Current).Property(x => x.DeliveryDate).IsModified = true;
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

        public HardwareInformation Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.HardwareInformations.SingleOrDefault(x => x.HardwareInformationId == ID);

        }
        public IQueryable<HardwareInformation> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.HardwareInformations select item;
        }

        public IQueryable<HardwareInformationEntity> GetAllHardwareInformation()
        {
         
            TrainingContext db = new TrainingContext();
            var list =
                (from hardwareinformations in db.HardwareInformations.Where(a => a.Hidden == false)
                 join hardwareequipment in db.HardwareEquipments on hardwareinformations.HardwareEquipmentId equals hardwareequipment.HardwareEquipmentId
                 join tableinterfacevalues in db.TableInterfaceValues on hardwareequipment.EquipmentNameId equals tableinterfacevalues.TableInterfaceValueId
                 join employemes in db.Employemes on hardwareinformations.EmployemeId equals employemes.EmployemeId
                 join employemejobs in db.EmployemeJobs on employemes.EmployemeId equals employemejobs.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevaluePostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluePostType.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId

                 select new HardwareInformationEntity
                 {
                     HardwareInformationId= hardwareinformations.HardwareInformationId,
                     EmployemeId = hardwareinformations.EmployemeId,
                     HardwareEquipmentId = hardwareinformations.HardwareEquipmentId,
                     EquipmentName = tableinterfacevalues.TableValue,
                     EquipmentNameId = hardwareequipment.EquipmentNameId,
                     EquipmentModel = hardwareequipment.EquipmentModel,
                     PropertyNumber = hardwareequipment.PropertyNumber,
                     
                     EmployemeName = employemes.FirstName + " " + employemes.LastName,
                     PostGroupName = tableinterfacevaluePostType.TableValue,
                     UnitSCenterName = tableinterfacevaluesUnitSCenter.TableValue,
                     DepartmentName = departments.Name,
                     SectionName = sections.Name,
                     UnitDepartmentSection = tableinterfacevaluePostType.TableValue + "-" + tableinterfacevaluePostType.TableValue + "-" + tableinterfacevaluesUnitSCenter.TableValue,

                     NetworkIP = hardwareinformations.NetworkIP,
                     NetworkID = hardwareinformations.NetworkID,
                     DeliveryDate = hardwareinformations.DeliveryDate,
                     Descriptions = hardwareinformations.Descriptions,
                 });
            return list;
        }

        public IQueryable<HardwareInformationEntity> GetAllHardwareInformationModel(HardwareInformationSearch HardwareInformationsearch)
        {
            TrainingContext db = new TrainingContext();
            var list =
            //(from hardwareinformations in db.HardwareInformations.Where(a => a.Hidden == false)
            // join hardwareequipment in db.HardwareEquipments on hardwareinformations.HardwareEquipmentId equals hardwareequipment.HardwareEquipmentId
            // join employemes in db.Employemes on hardwareinformations.EmployemeId equals employemes.EmployemeId
            // select new HardwareInformationEntity
            // {
            //     EmployemeId = hardwareinformations.EmployemeId,
            //     HardwareEquipmentId = hardwareinformations.HardwareEquipmentId,
            //     EquipmentName = hardwareequipment.EquipmentName,
            //     EmployemeName = employemes.FatherName + " " + employemes.LastName,
            //     NetworkIP = hardwareinformations.NetworkIP,
            //     NetworkID = hardwareinformations.NetworkID,
            //     DeliveryDate = hardwareinformations.DeliveryDate,
            //     Descriptions = hardwareinformations.Descriptions,

            (from hardwareinformations in db.HardwareInformations.Where(a => a.Hidden == false)
             join hardwareequipment in db.HardwareEquipments on hardwareinformations.HardwareEquipmentId equals hardwareequipment.HardwareEquipmentId
             join tableinterfacevalues in db.TableInterfaceValues on hardwareequipment.EquipmentNameId equals tableinterfacevalues.TableInterfaceValueId
             join employemes in db.Employemes on hardwareinformations.EmployemeId equals employemes.EmployemeId
             join employemejobs in db.EmployemeJobs on employemes.EmployemeId equals employemejobs.EmployemeId
             join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
             join tableinterfacevaluePostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluePostType.TableInterfaceValueId
             join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
             join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
             join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId

             select new HardwareInformationEntity
             {
                 HardwareInformationId = hardwareinformations.HardwareInformationId,
                 EmployemeId = hardwareinformations.EmployemeId,
                 HardwareEquipmentId = hardwareinformations.HardwareEquipmentId,
                 EquipmentName = tableinterfacevalues.TableValue,
                 EquipmentNameId = hardwareequipment.EquipmentNameId,
                 EquipmentModel = hardwareequipment.EquipmentModel,
                 PropertyNumber = hardwareequipment.PropertyNumber,

                 EmployemeName = employemes.FirstName + " " + employemes.LastName,
                 PostGroupName = tableinterfacevaluePostType.TableValue,
                 UnitSCenterName = tableinterfacevaluesUnitSCenter.TableValue,
                 DepartmentName = departments.Name,
                 SectionName = sections.Name,

                 NetworkIP = hardwareinformations.NetworkIP,
                 NetworkID = hardwareinformations.NetworkID,
                 DeliveryDate = hardwareinformations.DeliveryDate,
                 Descriptions = hardwareinformations.Descriptions,
             });

            if (HardwareInformationsearch.EmployemeName.Trim() != "")
                list = list.Where(p => p.EmployemeName.Contains(HardwareInformationsearch.EmployemeName));
            
            if (HardwareInformationsearch.HardwareEquipmentName.Trim() != "")
                list = list.Where(p => p.EquipmentName.Contains(HardwareInformationsearch.HardwareEquipmentName));

            if (HardwareInformationsearch.NetworkIP.Trim() != "")
                list = list.Where(p => p.NetworkIP.Contains(HardwareInformationsearch.NetworkIP));

            return list;
        }


        public HardwareInformationEntity GetAllHardwareInformation(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from hardwareinformations in db.HardwareInformations.Where(a => a.Hidden == false && a.HardwareInformationId == ID)
                 join hardwareequipment in db.HardwareEquipments on hardwareinformations.HardwareEquipmentId equals hardwareequipment.HardwareEquipmentId
                 join tableinterfacevalues in db.TableInterfaceValues on hardwareequipment.EquipmentNameId equals tableinterfacevalues.TableInterfaceValueId
                 join employemes in db.Employemes on hardwareinformations.EmployemeId equals employemes.EmployemeId
                 join employemejobs in db.EmployemeJobs on employemes.EmployemeId equals employemejobs.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevaluePostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluePostType.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId

                 select new HardwareInformationEntity
                 {
                     HardwareInformationId = hardwareinformations.HardwareInformationId,
                     EmployemeId = hardwareinformations.EmployemeId,
                     HardwareEquipmentId = hardwareinformations.HardwareEquipmentId,
                     EquipmentName = tableinterfacevalues.TableValue,
                     EquipmentNameId = hardwareequipment.EquipmentNameId,

                     EquipmentModel = hardwareequipment.EquipmentModel,
                     PropertyNumber = hardwareequipment.PropertyNumber,

                     EmployemeName = employemes.FirstName + " " + employemes.LastName,
                     PostGroupName = tableinterfacevaluePostType.TableValue,
                     UnitSCenterName = tableinterfacevaluesUnitSCenter.TableValue,

                     DepartmentName = departments.Name,
                     SectionName = sections.Name,

                     UnitDepartmentSection = tableinterfacevaluePostType.TableValue + "-" + tableinterfacevaluePostType.TableValue + "-" + tableinterfacevaluesUnitSCenter.TableValue,

                     UnitSCenterId = tableinterfacevaluesUnitSCenter.TableInterfaceValueId,
                     PostGroupId = PostGroups.PostGroupId,
                     PostTypeId = PostGroups.PostTypeId,
                     CollectionId = PostGroups.CollectionId,
                     SectionId = sections.SectionId,
                     DepartmentId = departments.DepartmentId,

                     NetworkIP = hardwareinformations.NetworkIP,
                     NetworkID = hardwareinformations.NetworkID,
                     DeliveryDate = hardwareinformations.DeliveryDate,
                     Descriptions = hardwareinformations.Descriptions,

                 }); ; ;
            return _query.SingleOrDefault();
        }

    }
}
