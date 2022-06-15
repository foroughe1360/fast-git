using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class InventoryjobDAC : IInventoryjobRepository
    {
        public int Add(Inventoryjob Current)
        {
            TrainingContext db = new TrainingContext();
            db.Inventoryjobs.Add(Current);
            db.SaveChanges();
            return Current.InventoryjobId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var inventoryjob = new Inventoryjob() { InventoryjobId = ID, Hidden = true };
                db.Inventoryjobs.Attach(inventoryjob);
                db.Entry(inventoryjob).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Inventoryjob Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Inventoryjobs.Attach(Current);
                db.Entry(Current).Property(x => x.InventoryjobId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.SectionId).IsModified = true;
                db.Entry(Current).Property(x => x.PostGroupName).IsModified = true;
                db.Entry(Current).Property(x => x.NumberEmployees).IsModified = true;
                db.Entry(Current).Property(x => x.AsJobs2).IsModified = true;
                db.Entry(Current).Property(x => x.AsJobs3).IsModified = true;
                db.Entry(Current).Property(x => x.Education).IsModified = true;
                db.Entry(Current).Property(x => x.Experience).IsModified = true;
                db.Entry(Current).Property(x => x.ListResponsibilitiePowerId).IsModified = true;
                db.Entry(Current).Property(x => x.PercentPhysicalActivity).IsModified = true;
                db.Entry(Current).Property(x => x.PercentMentalActivity).IsModified = true;
                db.Entry(Current).Property(x => x.TheoreticalKnowledge).IsModified = true;
                db.Entry(Current).Property(x => x.Qualified).IsModified = true;
                db.Entry(Current).Property(x => x.OtherTraining).IsModified = true;
                db.Entry(Current).Property(x => x.OtherAbilityRequiredJob).IsModified = true;
                db.Entry(Current).Property(x => x.ListCommunityOrganizationComment).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Inventoryjob Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Inventoryjobs.SingleOrDefault(x => x.InventoryjobId == ID);
        }

        public InventoryjobEntity GetInventoryjob(int ID)
        {
            TrainingContext db = new TrainingContext();

            var _query =
                 (
                 from inventoryjob in db.Inventoryjobs.Where(x => x.InventoryjobId == ID)
                 join section in db.Sections on inventoryjob.SectionId equals section.SectionId
                 join departments in db.Departments on section.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 select new InventoryjobEntity
                 {
                     UnitSCenterId = tableinterfacevaluesUnitSCenter.TableInterfaceValueId,
                     UnitSCenterName = tableinterfacevaluesUnitSCenter.TableValue,
                     DepartmentId = departments.DepartmentId,
                     DepartmentName = departments.Name,
                     SectionId = inventoryjob.SectionId,
                     SectionName = section.Name,
                     AsJobs2 = inventoryjob.AsJobs2,
                     AsJobs3 = inventoryjob.AsJobs3,
                     Education = inventoryjob.Education,
                     Experience = inventoryjob.Experience,
                     InventoryjobId = inventoryjob.InventoryjobId,
                     NumberEmployees = inventoryjob.NumberEmployees,
                     OtherTraining = inventoryjob.OtherTraining,
                     PercentMentalActivity = inventoryjob.PercentMentalActivity,
                     PercentPhysicalActivity = inventoryjob.PercentPhysicalActivity,
                     PostGroupName = inventoryjob.PostGroupName,
                     Qualified = inventoryjob.Qualified,
                     ListResponsibilitiePowerId = inventoryjob.ListResponsibilitiePowerId,
                     TheoreticalKnowledge = inventoryjob.TheoreticalKnowledge,
                     OtherAbilityRequiredJob = inventoryjob.OtherAbilityRequiredJob,
                     ListCommunityOrganizationComment = inventoryjob.ListCommunityOrganizationComment
                 }
                );

            return _query.SingleOrDefault();

        }

        public InventoryjobsReport GetInventoryjobsReport(int ID)
        {
            TrainingContext db = new TrainingContext();

            var _query =
                 (
                 from inventoryjob in db.Inventoryjobs.Where(x => x.InventoryjobId == ID)
                 join section in db.Sections on inventoryjob.SectionId equals section.SectionId
                 join departments in db.Departments on section.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 join listresponsibilitiepowers in db.ListResponsibilitiePowers on inventoryjob.ListResponsibilitiePowerId equals listresponsibilitiepowers.ListResponsibilitiePowerId
                 select new InventoryjobsReport
                 {
                     UnitCenter = tableinterfacevaluesUnitSCenter.TableValue,
                     Department = departments.Name,
                     Section = section.Name,
                     PostGroupName = inventoryjob.PostGroupName,
                     AsJobs2 = inventoryjob.AsJobs2,
                     AsJobs3 = inventoryjob.AsJobs3,
                     Education = inventoryjob.Education,
                     Experience = inventoryjob.Experience,
                     ListResponsibilitiePower = listresponsibilitiepowers.Description,
                     PercentPhysicalActivity = inventoryjob.PercentPhysicalActivity,
                     PercentMentalActivity = inventoryjob.PercentMentalActivity,
                     TheoreticalKnowledge = inventoryjob.TheoreticalKnowledge,
                     Qualified = inventoryjob.Qualified,
                     OtherTraining = inventoryjob.OtherTraining,
                     NumberEmployees = inventoryjob.NumberEmployees,
                     OtherAbilityRequiredJob = inventoryjob.OtherAbilityRequiredJob,
                     ListCommunityOrganizationComment = inventoryjob.ListCommunityOrganizationComment
                 }
                );

            return _query.SingleOrDefault();

        }

        public IQueryable<Inventoryjob> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Inventoryjobs select item;
        }

        public IQueryable<InventoryjobEntity> GetAllInventoryjob()
        {
            TrainingContext db = new TrainingContext();
            var _query =
                 (
                 from inventoryjob in db.Inventoryjobs.Where(a => a.Hidden == false)
                 join section in db.Sections on inventoryjob.SectionId equals section.SectionId
                 join departments in db.Departments on section.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 select new InventoryjobEntity
                 {
                     UnitSCenterId = tableinterfacevaluesUnitSCenter.TableInterfaceValueId,
                     UnitSCenterName = tableinterfacevaluesUnitSCenter.TableValue,
                     DepartmentId = departments.DepartmentId,
                     DepartmentName = departments.Name,
                     SectionId = inventoryjob.SectionId,
                     SectionName = section.Name,
                     AsJobs2 = inventoryjob.AsJobs2,
                     AsJobs3 = inventoryjob.AsJobs3,
                     Education = inventoryjob.Education,
                     Experience = inventoryjob.Experience,
                     InventoryjobId = inventoryjob.InventoryjobId,
                     NumberEmployees = inventoryjob.NumberEmployees,
                     OtherTraining = inventoryjob.OtherTraining,
                     PercentMentalActivity = inventoryjob.PercentMentalActivity,
                     PercentPhysicalActivity = inventoryjob.PercentPhysicalActivity,
                     PostGroupName = inventoryjob.PostGroupName,
                     Qualified = inventoryjob.Qualified,
                     ListResponsibilitiePowerId = inventoryjob.ListResponsibilitiePowerId,
                     TheoreticalKnowledge = inventoryjob.TheoreticalKnowledge,
                     OtherAbilityRequiredJob = inventoryjob.OtherAbilityRequiredJob,
                     ListCommunityOrganizationComment = inventoryjob.ListCommunityOrganizationComment
                 }
                );
            return _query;
        }
        public bool CopyDataInventoryjob(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();

                var query = db.Database.SqlQuery<InventoryjobEntity>(
                "InventoryjobCopyRow @CurrentInventoryjobId",
                new System.Data.SqlClient.SqlParameter("CurrentInventoryjobId", ID)
                ).ToList();
                return true;
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

    }
}
