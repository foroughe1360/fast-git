using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class TeacherProvider : ITeacherProvider
    {
        private TeacherDAC _TeacherDAC;
        public TeacherProvider()
        {
            _TeacherDAC = new TeacherDAC();
        }
        public int Add(TeacherEntity Current)
        {
            General _General = new General();
            Current.DateOfEmployement = _General.ShamsiToMiladi(Current.DateOfEmployementStr);
            Teacher _Teacher = new Teacher(Current.Name,Current.Family,Current.EducationId,Current.Mobile,Current.DateOfEmployement,Current.Email);
            return _TeacherDAC.Add(_Teacher);
        }
        public bool Delete(int ID)
        {
            return _TeacherDAC.Delete(ID);
        }
        public bool Edit(TeacherEntity Current)
        {
            General _General = new General();
            Teacher _Teacher = new Teacher();
            _Teacher.TeacherId = Current.TeacherId; 
            _Teacher.TimeLastModified = DateTime.Now;
            _Teacher.Name = Current.Name;
            _Teacher.Family = Current.Family;
            _Teacher.Mobile = Current.Mobile;
            _Teacher.EducationId = Current.EducationId;
            _Teacher.DateOfEmployement = _General.ShamsiToMiladi(Current.DateOfEmployementStr);
            _Teacher.Email = Current.Email;
            return _TeacherDAC.Edit(_Teacher);
        }
        public TeacherEntity Get(int ID)
        {
            TeacherEntity _TeacherEntity = new TeacherEntity();
            var q = _TeacherDAC.Get(ID);
            _TeacherEntity.TeacherId = q.TeacherId;
            _TeacherEntity.Name = q.Name;
            _TeacherEntity.Family = q.Family;
            _TeacherEntity.Mobile = q.Mobile;
            _TeacherEntity.EducationId = q.EducationId;
            _TeacherEntity.DateOfEmployement = q.DateOfEmployement;
            _TeacherEntity.Email = q.Email;
            return _TeacherEntity;
        }
        public IQueryable<TeacherEntity> GetAll()
        {
            return _TeacherDAC.GetAllTeacher();
        }
        public IQueryable<TeacherEntity> GetAll(TeacherSearch teachersearch)
        {
            return _TeacherDAC.GetAllTeacher(teachersearch);
        }
    }
}
