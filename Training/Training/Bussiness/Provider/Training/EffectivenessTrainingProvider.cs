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
    public class EffectivenessTrainingProvider : IEffectivenessTrainingProvider
    {
        private EffectivenessTrainingDAC _EffectivenessTrainingDAC;
        public EffectivenessTrainingProvider()
        {
            _EffectivenessTrainingDAC = new EffectivenessTrainingDAC();
        }
        public int Add(EffectivenessTrainingEntity Current)
        {
            return _EffectivenessTrainingDAC.Add(Current);
        }

        public bool Delete(int ID)
        {
            return _EffectivenessTrainingDAC.Delete(ID);
        }

        public bool Edit(EffectivenessTrainingEntity Current)
        {
            return _EffectivenessTrainingDAC.Edit(Current);
        }

        public EffectivenessTrainingEntity Get(int ID)
        {
            EffectivenessTrainingEntity _EffectivenessTrainingEntity = new EffectivenessTrainingEntity();
            var q = _EffectivenessTrainingDAC.Get(ID);
            _EffectivenessTrainingEntity.Correctiveaction = q.Correctiveaction;
            _EffectivenessTrainingEntity.CorrectiveactionDescription = q.CorrectiveactionDescription;
            _EffectivenessTrainingEntity.EffectivenessTrainingId = q.EffectivenessTrainingId;
            _EffectivenessTrainingEntity.CourseRegistrationId = q.CourseRegistrationId;
            _EffectivenessTrainingEntity.EffectivenessTrainingDate = q.EffectivenessTrainingDate;
            _EffectivenessTrainingEntity.SupervisorId = q.SupervisorId;
            return _EffectivenessTrainingEntity;

            //return (EffectivenessTrainingEntity)_EffectivenessTrainingDAC.Get(ID);
        }

        public IQueryable<EffectivenessTrainingEntity> GetAll()
        {
            return (IQueryable<EffectivenessTrainingEntity>)_EffectivenessTrainingDAC.GetAll();
        }


        public IQueryable<EffectivenessTrainingEntity> GetAll(int ID)
        {
            return _EffectivenessTrainingDAC.GetAllEffectivenessTraining(ID);
        }
    }
}
