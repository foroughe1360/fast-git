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
    public class DepartmentDAC : IDepartmentRepository
    {
        public int Add(Department Current)
        {
            TrainingContext db = new TrainingContext();
            db.Departments.Add(Current);
            db.SaveChanges();
            return Current.DepartmentId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var department = new Department() { DepartmentId = ID, Hidden = true };
                db.Departments.Attach(department);
                db.Entry(department).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Department Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Departments.Attach(Current);
                db.Entry(Current).Property(x => x.DepartmentId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.UnitSCenterId).IsModified = true;
                db.Entry(Current).Property(x => x.Name).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Department Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Departments.SingleOrDefault(x => x.DepartmentId == ID);
        }

        public IQueryable<Department> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Departments select item;
        }

        public IQueryable<DepartmentEntity> GetAllDepartment()
        {
            TrainingContext db = new TrainingContext();
            return
                (from Departments in db.Departments.Where(a => a.Hidden==false)
                 join tableinterfacevalues in db.TableInterfaceValues on Departments.UnitSCenterId equals tableinterfacevalues.TableInterfaceValueId
                 select new DepartmentEntity
                 {
                     DepartmentId = Departments.DepartmentId,
                     Name = Departments.Name,
                     UnitSCenterId = Departments.UnitSCenterId,
                     UnitSCenterName = tableinterfacevalues.TableValue
                 });
        }

        public IQueryable<DepartmentEntity> GetDepartmentDPD(int unitscenterid)
        {
            TrainingContext db = new TrainingContext();
            return 
                (from departments in db.Departments.Where(a => a.Hidden==false && a.UnitSCenterId== unitscenterid)
                select new DepartmentEntity
                {
                    DepartmentId = departments.DepartmentId,
                    Name = departments.Name
                });
        }
    }
}
