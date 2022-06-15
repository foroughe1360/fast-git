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
    public class EducationEmployemeDAC : IEducationEmployemeRepository
    {
        public int Add(EducationEmployeme Current)
        {
            TrainingContext db = new TrainingContext();
            db.EducationEmployemes.Add(Current);
            db.SaveChanges();
            return Current.EducationEmployemeId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var educationemployeme = new EducationEmployeme() { EducationEmployemeId = ID, Hidden = true };
                db.EducationEmployemes.Attach(educationemployeme);
                db.Entry(educationemployeme).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(EducationEmployeme Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.EducationEmployemes.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.EducationId).IsModified = true;
                db.Entry(Current).Property(x => x.FieldOfStudy).IsModified = true;
                db.Entry(Current).Property(x => x.AcademicOrientation).IsModified = true;
                db.Entry(Current).Property(x => x.DateOfGraduation).IsModified = true;
                db.Entry(Current).Property(x => x.LastEducationalCertificate).IsModified = true;
                db.Entry(Current).Property(x => x.TableTypeOfUniversityId).IsModified = true;
                db.Entry(Current).Property(x => x.NameOfUniversity).IsModified = true;
                db.Entry(Current).Property(x => x.ActiveTypeOfUniversity).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public EducationEmployeme Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.EducationEmployemes.SingleOrDefault(x => x.EducationEmployemeId == ID);
        }

        public IQueryable<EducationEmployeme> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.EducationEmployemes select item;
        }

        public IQueryable<EducationEmployemeEntity> GetAllEducationEmployeme(int ID)
        {
            TrainingContext db = new TrainingContext();
            var EducationEmployemesQuery =
                (from educationemployemes in db.EducationEmployemes.Where(a => a.EmployemeId == ID && a.Hidden == false)
                 join tableinterfacevalues in db.TableInterfaceValues on educationemployemes.EducationId equals tableinterfacevalues.TableInterfaceValueId
                 select new
                 {
                     AcademicOrientation = educationemployemes.AcademicOrientation,
                     DateOfGraduation = educationemployemes.DateOfGraduation,
                     EducationEmployemeId = educationemployemes.EducationEmployemeId,
                     EducationName = tableinterfacevalues.TableValue,
                     EducationId = educationemployemes.EducationId,
                     EmployemeId = educationemployemes.EmployemeId,
                     FieldOfStudy = educationemployemes.FieldOfStudy,
                     LastEducationalCertificate = educationemployemes.LastEducationalCertificate,
                     TableTypeOfUniversityId = educationemployemes.TableTypeOfUniversityId,
                     NameOfUniversity = educationemployemes.NameOfUniversity,
                     ActiveTypeOfUniversity = educationemployemes.ActiveTypeOfUniversity,
                 });

             
            var Query =
                (from educationemployemesquery in EducationEmployemesQuery
                 join tableinterfacevaluesUniversity in db.TableInterfaceValues on educationemployemesquery.TableTypeOfUniversityId equals tableinterfacevaluesUniversity.TableInterfaceValueId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new EducationEmployemeEntity()
                 {
                     AcademicOrientation = educationemployemesquery.AcademicOrientation,
                     DateOfGraduation = educationemployemesquery.DateOfGraduation,
                     EducationEmployemeId = educationemployemesquery.EducationEmployemeId,
                     EducationName = educationemployemesquery.EducationName,
                     EducationId = educationemployemesquery.EducationId,
                     EmployemeId = educationemployemesquery.EmployemeId,
                     FieldOfStudy = educationemployemesquery.FieldOfStudy,
                     LastEducationalCertificate = educationemployemesquery.LastEducationalCertificate,
                     TableTypeOfUniversityId = (temp.TableInterfaceValueId == 0 ? 0 : educationemployemesquery.TableTypeOfUniversityId),
                     NameOfUniversity = educationemployemesquery.NameOfUniversity,
                     TypeOfUniversityName = temp.TableValue,
                     ActiveTypeOfUniversity = educationemployemesquery.ActiveTypeOfUniversity,
                 });
            return Query;
        }
    }
}
