using Bussiness.InfraStructre.Traning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceEntity;
using DataAccess.Training;
using DomainModel.Models;

namespace Bussiness.Provider.Training
{
    public class DesignTrainingCourseProvider : IDesignTrainingCourseDateProvider
    {
        DesignTrainingCourseDateDAC _DesignTrainingCourseDateDAC;
        public DesignTrainingCourseProvider()
        {
            _DesignTrainingCourseDateDAC = new DesignTrainingCourseDateDAC();
        }
        public int Add(DesignTrainingCourseDateEntity Current)
        {
            General _General = new General();
            Current.DTCDate = _General.ShamsiToMiladi(Current.DTCDateStr);
            DesignTrainingCourseDate _DesignTrainingCourseDate = new DesignTrainingCourseDate(Current.Description, Current.DTCDate,Current.FinancialYear);
            return _DesignTrainingCourseDateDAC.Add(_DesignTrainingCourseDate);
        }
        public bool Delete(int ID)
        {
            return _DesignTrainingCourseDateDAC.Delete(ID);
        }
        public bool Edit(DesignTrainingCourseDateEntity Current)
        {
            General _General = new General();
            DesignTrainingCourseDate _DesignTrainingCourseDate = new DesignTrainingCourseDate();
            _DesignTrainingCourseDate.DesignTrainingCourseDateId = Current.DesignTrainingCourseDateId;
            _DesignTrainingCourseDate.TimeLastModified = DateTime.Now;
            _DesignTrainingCourseDate.Description = Current.Description;
            _DesignTrainingCourseDate.DTCDate = _General.ShamsiToMiladi(Current.DTCDateStr);
            _DesignTrainingCourseDate.FinancialYear = Current.FinancialYear;

            return _DesignTrainingCourseDateDAC.Edit(_DesignTrainingCourseDate);
        }
        public DesignTrainingCourseDateEntity Get(int ID)
        {
            DesignTrainingCourseDateEntity _DesignTrainingCourseDateEntity = new DesignTrainingCourseDateEntity();
            var q = _DesignTrainingCourseDateDAC.Get(ID);
            _DesignTrainingCourseDateEntity.DesignTrainingCourseDateId = q.DesignTrainingCourseDateId;
            _DesignTrainingCourseDateEntity.Description = q.Description;
            _DesignTrainingCourseDateEntity.DTCDate = q.DTCDate;
            _DesignTrainingCourseDateEntity.FinancialYear = q.FinancialYear;

            return _DesignTrainingCourseDateEntity;
        }
        public IQueryable<DesignTrainingCourseDateEntity> GetAll()
        {
            return _DesignTrainingCourseDateDAC.GetAllDesignTrainingCourseDate();
        }


    }
}
