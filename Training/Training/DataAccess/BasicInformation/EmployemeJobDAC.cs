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
    public class EmployemeJobDAC : IEmployemeJobRepository
    {
        public int Add(EmployemeJob Current)
        {
            TrainingContext db = new TrainingContext();
            db.EmployemeJobs.Add(Current);
            db.SaveChanges();
            return Current.EmployemeJobId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var employemejob = new EmployemeJob() { EmployemeJobId = ID, Hidden = true };
                db.EmployemeJobs.Attach(employemejob);
                db.Entry(employemejob).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(EmployemeJob Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.EmployemeJobs.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.PostGroupId).IsModified = true;
                db.Entry(Current).Property(x => x.SectionId).IsModified = true;
                db.Entry(Current).Property(x => x.DateStartPostGroupName).IsModified = true;
                db.Entry(Current).Property(x => x.ActivePostGroupName).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public EmployemeJob Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.EmployemeJobs.SingleOrDefault(x => x.EmployemeJobId == ID);
        }

        public EmployemeJobEntity GetCurrentPostGroupInfo(int employemejobid)
        {
            TrainingContext db = new TrainingContext();
            return
                (from employemejobs in db.EmployemeJobs.Where(a => a.EmployemeJobId == employemejobid && a.Hidden == false)
                 join employemes in db.Employemes on employemejobs.EmployemeId equals employemes.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevalues1 in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevalues1.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevalues2 in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevalues2.TableInterfaceValueId
                 select new EmployemeJobEntity
                 {
                     EmployemeId = employemejobs.EmployemeId,
                     DateStartPostGroupName = employemejobs.DateStartPostGroupName,
                     ActivePostGroupName = employemejobs.ActivePostGroupName,
                     EmployemeName = employemes.FirstName,
                     EmployemeJobId = employemejobs.EmployemeJobId,
                     PostGroupId = employemejobs.PostGroupId,
                     PostGroupName = tableinterfacevalues1.TableValue,
                     SectionId = employemejobs.SectionId,
                     SectionName = sections.Name,
                     DepartmentName = departments.Name,
                     UnitSCenterName = tableinterfacevalues2.TableValue,
                     UnitSCenterId = tableinterfacevalues2.TableInterfaceValueId,
                     DepartmentId = departments.DepartmentId
                 }).SingleOrDefault();
        }
        
        public IQueryable<EmployemeJob> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.EmployemeJobs select item;
        }

        public IQueryable<EmployemeJobEntity> GetAllEmployemeJob(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from employemejobs in db.EmployemeJobs.Where(a => a.EmployemeId == ID && a.Hidden == false)
                 join employemes in db.Employemes on employemejobs.EmployemeId equals employemes.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevalues1 in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevalues1.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevalues2 in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevalues2.TableInterfaceValueId
                 select new EmployemeJobEntity
                 {
                     EmployemeId = employemejobs.EmployemeId,
                     DateStartPostGroupName = employemejobs.DateStartPostGroupName,
                     ActivePostGroupName = employemejobs.ActivePostGroupName,
                     EmployemeName = employemes.FirstName,
                     EmployemeJobId = employemejobs.EmployemeJobId,
                     PostGroupId = employemejobs.PostGroupId,
                     PostGroupName = tableinterfacevalues1.TableValue,
                     SectionId = employemejobs.SectionId,
                     SectionName = sections.Name,
                     DepartmentName = departments.Name,
                     UnitSCenterName = tableinterfacevalues2.TableValue,
                     UnitSCenterId = tableinterfacevalues2.TableInterfaceValueId,
                     DepartmentId = departments.DepartmentId
                 });
        }

        public IQueryable<EmployemeJobEntity> GetAllActivePostGroupNameDPD(int employemeid)
        {
            TrainingContext db = new TrainingContext();
            return
                (from employemejobs in db.EmployemeJobs.Where(a => a.EmployemeId == employemeid && a.ActivePostGroupName==true && a.Hidden == false)
                 join employemes in db.Employemes on employemejobs.EmployemeId equals employemes.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevaluesPostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluesPostType.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 select new EmployemeJobEntity
                 {
                     EmployemeJobId = employemejobs.EmployemeJobId,
                     PostGroupName = tableinterfacevaluesPostType.TableValue +" "+ tableinterfacevaluesUnitSCenter.TableValue+" "+ departments.Name+" "+ sections.Name
                 });
        }

        public IQueryable<EmployemeJobEntity> GetAllPreviousJobs(int employemeid)
        {
            TrainingContext db = new TrainingContext();
            return
                (from employemejobs in db.EmployemeJobs.Where(a => a.EmployemeId == employemeid && a.ActivePostGroupName == false && a.Hidden == false)
                 join employemes in db.Employemes on employemejobs.EmployemeId equals employemes.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevaluesPostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluesPostType.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 select new EmployemeJobEntity
                 {
                     EmployemeId = employemejobs.EmployemeId,
                     EmployemeName = employemes.FirstName,
                     PostGroupName = tableinterfacevaluesPostType.TableValue +" - "+ tableinterfacevaluesUnitSCenter.TableValue +" - " + departments.Name + " - "+sections.Name,
                 });
        }

        public IQueryable<EmployemeJobEntity> GetAllActivePostGroupName(int employemeid)
        {
            TrainingContext db = new TrainingContext();
            return
                (from employemejobs in db.EmployemeJobs.Where(a => a.EmployemeId == employemeid && a.ActivePostGroupName == true && a.Hidden == false)
                 join employemes in db.Employemes on employemejobs.EmployemeId equals employemes.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevaluesPostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluesPostType.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 select new EmployemeJobEntity
                 {
                     PostGroupName = tableinterfacevaluesPostType.TableValue,
                     UnitSCenterName = tableinterfacevaluesUnitSCenter.TableValue,
                     DepartmentName = departments.Name,
                     SectionName = sections.Name
                 });
        }
    }
}
