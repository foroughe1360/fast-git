using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class EducationEmployemeProvider : IEducationEmployemeProvider
    {
        private EducationEmployemeDAC _EducationEmployemeDAC;
        public EducationEmployemeProvider()
        {
            _EducationEmployemeDAC = new EducationEmployemeDAC();
        }
        public int Add(EducationEmployemeEntity Current)
        {
            General _General = new General();
            Current.DateOfGraduation = _General.ShamsiToMiladi(Current.DateOfGraduationStr);

            EducationEmployeme _EducationEmployeme = new EducationEmployeme(Current.EmployemeId,Current.EducationId,Current.FieldOfStudy,
                Current.AcademicOrientation,Current.DateOfGraduation,Current.LastEducationalCertificate,Current.TableTypeOfUniversityId,Current.NameOfUniversity,Current.ActiveTypeOfUniversity);
            return _EducationEmployemeDAC.Add(_EducationEmployeme);
        }

        public bool Delete(int ID)
        {
            return _EducationEmployemeDAC.Delete(ID);
        }

        public bool Edit(EducationEmployemeEntity Current)
        {
            General _General = new General();
            EducationEmployeme _EducationEmployeme = new EducationEmployeme();
            _EducationEmployeme.EducationEmployemeId = Current.EducationEmployemeId;
            _EducationEmployeme.TimeLastModified = DateTime.Now;
            _EducationEmployeme.EmployemeId=Current.EmployemeId;
            _EducationEmployeme.EducationId=Current.EducationId;
            _EducationEmployeme.FieldOfStudy=Current.FieldOfStudy;
            _EducationEmployeme.AcademicOrientation=Current.AcademicOrientation;
            _EducationEmployeme.DateOfGraduation= _General.ShamsiToMiladi(Current.DateOfGraduationStr);
            _EducationEmployeme.LastEducationalCertificate = Current.LastEducationalCertificate;
            _EducationEmployeme.TableTypeOfUniversityId = Current.TableTypeOfUniversityId;
            _EducationEmployeme.NameOfUniversity = Current.NameOfUniversity;
            _EducationEmployeme.ActiveTypeOfUniversity = Current.ActiveTypeOfUniversity;
            
            return _EducationEmployemeDAC.Edit(_EducationEmployeme);
        }

        public EducationEmployemeEntity Get(int ID)
        {
            EducationEmployemeEntity _EducationEmployemeEntity = new EducationEmployemeEntity();
            var q = _EducationEmployemeDAC.Get(ID);
            _EducationEmployemeEntity.AcademicOrientation = q.AcademicOrientation;
            _EducationEmployemeEntity.DateOfGraduation = q.DateOfGraduation;
            _EducationEmployemeEntity.EducationEmployemeId = q.EducationEmployemeId;
            _EducationEmployemeEntity.EducationId = q.EducationId;
            _EducationEmployemeEntity.EmployemeId = q.EmployemeId;
            _EducationEmployemeEntity.FieldOfStudy = q.FieldOfStudy;
            _EducationEmployemeEntity.LastEducationalCertificate = q.LastEducationalCertificate;
            _EducationEmployemeEntity.TableTypeOfUniversityId = q.TableTypeOfUniversityId;
            _EducationEmployemeEntity.NameOfUniversity = q.NameOfUniversity;
            _EducationEmployemeEntity.ActiveTypeOfUniversity = q.ActiveTypeOfUniversity;
            return _EducationEmployemeEntity;

          //  return (EducationEmployemeEntity)_EducationEmployemeDAC.Get(ID);
        }

        public IQueryable<EducationEmployemeEntity> GetAll()
        {
            return (IQueryable<EducationEmployemeEntity>)_EducationEmployemeDAC.GetAll();
        }

        public IQueryable<EducationEmployemeEntity> GetAll(int ID)
        {
            return _EducationEmployemeDAC.GetAllEducationEmployeme(ID);
        }
    }
}
