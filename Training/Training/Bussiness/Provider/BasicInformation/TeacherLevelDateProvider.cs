using Bussiness.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess;
using DomainModel.Models;
using System.Globalization;

namespace Bussiness
{
    public class TeacherLevelDateProvider : ITeacherLevelDateProvider
    {
        private TeacherLevelDateDAC _TeacherLevelDateDAC;

        public TeacherLevelDateProvider()
        {
            _TeacherLevelDateDAC = new TeacherLevelDateDAC();
        }

        public int Add(TeacherLevelDateEntity Current)
        {
            General _General = new General();
            Current.LevelDate = _General.ShamsiToMiladi(Current.LevelDateStr);
            TeacherLevelDate _TeacherLevelDate = new TeacherLevelDate(Current.Description,Current.LevelDate);
            return _TeacherLevelDateDAC.Add(_TeacherLevelDate);
            
        }

        public bool Delete(int ID)
        {
            return _TeacherLevelDateDAC.Delete(ID);
        }

        public bool Edit(TeacherLevelDateEntity Current)
        {
            General _General = new General();
            TeacherLevelDate _TeacherLevelDate = new TeacherLevelDate();
            _TeacherLevelDate.TeacherLevelDateId = Current.TeacherLevelDateId;
            _TeacherLevelDate.TimeLastModified = DateTime.Now;
            _TeacherLevelDate.Description = Current.Description;
            _TeacherLevelDate.LevelDate = _General.ShamsiToMiladi(Current.LevelDateStr);
            return _TeacherLevelDateDAC.Edit(_TeacherLevelDate);
        }

        public TeacherLevelDateEntity Get(int ID)
        {
            TeacherLevelDateEntity _TeacherLevelDateEntity = new TeacherLevelDateEntity();
            var q = _TeacherLevelDateDAC.Get(ID);
            _TeacherLevelDateEntity.TeacherLevelDateId = q.TeacherLevelDateId;
            _TeacherLevelDateEntity.Description = q.Description;
            _TeacherLevelDateEntity.LevelDate = q.LevelDate;
            return _TeacherLevelDateEntity;
        }

        public IQueryable<TeacherLevelDateEntity> GetAll()
        {
            return _TeacherLevelDateDAC.GetAllTeacherLevelDate();
        }
    }
}
