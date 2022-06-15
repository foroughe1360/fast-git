using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using InterfaceEntity;

namespace Bussiness
{
    public class CourseObjectivesEffectivenessTrainingProvider : ICourseObjectivesEffectivenessTrainingProvider
    {
        private CourseObjectivesEffectivenessTrainingDAC _CourseObjectivesEffectivenessTrainingDAC;
        public CourseObjectivesEffectivenessTrainingProvider()
        {
            _CourseObjectivesEffectivenessTrainingDAC = new CourseObjectivesEffectivenessTrainingDAC();
        }
        public int Add(CourseObjectivesEffectivenessTrainingEntity Current)
        {
            return _CourseObjectivesEffectivenessTrainingDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _CourseObjectivesEffectivenessTrainingDAC.Delete(ID);
        }

        public bool Edit(CourseObjectivesEffectivenessTrainingEntity Current)
        {
            return _CourseObjectivesEffectivenessTrainingDAC.Edit(Current);
        }

        public CourseObjectivesEffectivenessTrainingEntity Get(int ID)
        {
            CourseObjectivesEffectivenessTrainingEntity _CourseObjectivesEffectivenessTrainingEntity = new CourseObjectivesEffectivenessTrainingEntity();
            var q = _CourseObjectivesEffectivenessTrainingDAC.Get(ID);
            _CourseObjectivesEffectivenessTrainingEntity.CourseObjectiveId = q.CourseObjectiveId;
            _CourseObjectivesEffectivenessTrainingEntity.CourseObjectivesEffectivenessTrainingId = q.CourseObjectivesEffectivenessTrainingId;
            _CourseObjectivesEffectivenessTrainingEntity.EffectivenessTrainingId = q.EffectivenessTrainingId;
            return _CourseObjectivesEffectivenessTrainingEntity;

            //return (CourseObjectivesEffectivenessTrainingEntity)_CourseObjectivesEffectivenessTrainingDAC.Get(ID);
        }

        public IQueryable<CourseObjectivesEffectivenessTrainingEntity> GetAll()
        {
            return (IQueryable<CourseObjectivesEffectivenessTrainingEntity>)_CourseObjectivesEffectivenessTrainingDAC.GetAll();
        }

        public IQueryable<CourseObjectivesEffectivenessTrainingEntity> GetAll(int ID)
        {
            return _CourseObjectivesEffectivenessTrainingDAC.GetAllCourseObjectivesEffectivenessTraining(ID);
        }
    }
}
