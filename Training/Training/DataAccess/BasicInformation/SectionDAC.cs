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
    public class SectionDAC : ISectionRepository
    {
        public int Add(Section Current)
        {
            TrainingContext db = new TrainingContext();
            db.Sections.Add(Current);
            db.SaveChanges();
            return Current.SectionId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var section = new Section() { SectionId = ID, Hidden = true };
                db.Sections.Attach(section);
                db.Entry(section).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Section Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Sections.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.DepartmentId).IsModified = true;
                db.Entry(Current).Property(x => x.Name).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Section Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Sections.SingleOrDefault(x => x.SectionId == ID);
        }

        public IQueryable<Section> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Sections select item;
        }

        public IQueryable<SectionEntity> GetAllSection(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from sections in db.Sections.Where(a => a.DepartmentId==ID && a.Hidden==false)
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevalues in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevalues.TableInterfaceValueId
                 select new SectionEntity
                 {
                     DepartmentId = sections.DepartmentId,
                     Name = sections.Name,
                     SectionId = sections.SectionId,
                     departmentName = departments.Name,
                     UnitSCenterName = tableinterfacevalues.TableValue
                 });

        }
    }
}
