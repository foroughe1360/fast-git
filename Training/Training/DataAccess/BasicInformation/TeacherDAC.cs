using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;

namespace DataAccess
{
    public class TeacherDAC : ITeacherRepository
    {
        public int Add(Teacher Current)
        {
            TrainingContext db = new TrainingContext();
            db.Teachers.Add(Current);
            db.SaveChanges();
            return Current.TeacherId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var teacher = new Teacher() { TeacherId = ID, Hidden = true };
                db.Teachers.Attach(teacher);
                db.Entry(teacher).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Teacher Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Teachers.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Name).IsModified = true;
                db.Entry(Current).Property(x => x.Family).IsModified = true;
                db.Entry(Current).Property(x => x.Mobile).IsModified = true;
                db.Entry(Current).Property(x => x.EducationId).IsModified = true;
                db.Entry(Current).Property(x => x.DateOfEmployement).IsModified = true;
                db.Entry(Current).Property(x => x.Email).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Teacher Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Teachers.SingleOrDefault(x => x.TeacherId == ID);
        }

        public IQueryable<Teacher> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Teachers select item;
        }

        public IQueryable<TeacherEntity> GetAllTeacher()
        {
            TrainingContext db = new TrainingContext();
            return
                (from teachers in db.Teachers.Where(a => a.Hidden==false)
                 join tableinterfacevalues in db.TableInterfaceValues on teachers.EducationId equals tableinterfacevalues.TableInterfaceValueId
                 select new TeacherEntity
                 {
                     TeacherId = teachers.TeacherId,
                     Name = teachers.Name,
                     Family = teachers.Family,
                     Mobile = teachers.Mobile,
                     EducationId = teachers.EducationId,
                     EducationName = tableinterfacevalues.TableValue,
                     DateOfEmployement = teachers.DateOfEmployement,
                     Email=teachers.Email,
                     TeacherName=teachers.Name+" " + teachers.Family

                 });
        }

        public IQueryable<TeacherEntity> GetAllTeacher(TeacherSearch teachersearch)
        {
            TrainingContext db = new TrainingContext();
            var list = 
                (from teachers in db.Teachers.Where(a => a.Hidden == false)
                 join tableinterfacevalues in db.TableInterfaceValues on teachers.EducationId equals tableinterfacevalues.TableInterfaceValueId
                 select new TeacherEntity
                 {
                     TeacherId = teachers.TeacherId,
                     Name = teachers.Name,
                     Family = teachers.Family,
                     Mobile = teachers.Mobile,
                     EducationId = teachers.EducationId,
                     EducationName = tableinterfacevalues.TableValue,
                     DateOfEmployement = teachers.DateOfEmployement,
                     Email = teachers.Email,
                     TeacherName = teachers.Name + " " + teachers.Family

                 });
            if (teachersearch.Name.Trim() != "")
                list = list.Where(p => p.Name.Contains(teachersearch.Name));
            
            if (teachersearch.Family.Trim() != "")
                list = list.Where(p => p.Family.Contains(teachersearch.Family));

            return list;
        }
    }
}
