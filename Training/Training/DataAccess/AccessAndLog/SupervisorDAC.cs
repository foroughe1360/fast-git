using DataAccess.InfraStructre.AccessAndLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models.AccessAndLog;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess.AccessAndLog
{
    public class SupervisorDAC : ISupervisorRepository
    {
        private TrainingContext db;

        public SupervisorDAC()
        {
            db = new TrainingContext();
        }

        public int Add(Supervisor Current)
        {
            db.Supervisors.Add(Current);
            db.SaveChanges();
            return Current.SupervisorId;
        }

        public bool Delete(int ID)
        {
            bool Result = false;  
            var supervisor = new Supervisor() { SupervisorId = ID, Hidden = true };
            db.Supervisors.Attach(supervisor);
            db.Entry(supervisor).Property(x => x.Hidden).IsModified = true;
            db.SaveChanges();
            Result = true;
            return Result;
        }

        public bool Edit(Supervisor Current)
        {
            bool Result = false;
            db.Supervisors.Attach(Current);
            db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
            db.Entry(Current).Property(x => x.DepartmentId).IsModified = true;
            db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
            db.Entry(Current).Property(x => x.PostTypeId).IsModified = true; 
            db.SaveChanges();
            Result = true;
            return Result;
        }

        public Supervisor Get(int ID)
        {
            return db.Supervisors.SingleOrDefault(x => x.SupervisorId == ID);
        }

        public IQueryable<Supervisor> GetAll()
        {
            return from item in db.Supervisors select item;
        }

        public IQueryable<SupervisorEntity> GetAllSupervisor()
        {
            return
                from supervisors in db.Supervisors.Where(a => a.Hidden == false)
                join employemes in db.Employemes on supervisors.EmployemeId equals employemes.EmployemeId
                join Departments in db.Departments on supervisors.DepartmentId equals Departments.DepartmentId
                join tableinterfacevalues in db.TableInterfaceValues on supervisors.PostTypeId equals tableinterfacevalues.TableInterfaceValueId
                select new SupervisorEntity
                {
                    SupervisorId = supervisors.SupervisorId,
                    DepartmentId = supervisors.DepartmentId,
                    EmployemeId = supervisors.EmployemeId,
                    State = supervisors.State,
                    Department = Departments.Name,
                    Employeme = employemes.FirstName + " " + employemes.LastName,
                    PostTypeId = supervisors.PostTypeId,
                    PostType = tableinterfacevalues.TableValue,
                    EmployemePostType = employemes.FirstName + " " + employemes.LastName + " -- " + tableinterfacevalues.TableValue + " -- " + Departments.Name,
                };
        }
    }
}
